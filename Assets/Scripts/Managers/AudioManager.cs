using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField]
    private AudioSource soundSource;

    [SerializeField]
    private AudioSource music1Source;
    [SerializeField]
    private AudioSource music2Source;

    [SerializeField]
    private string introBGMusic;
    [SerializeField]
    private string levelBGMusic;

    private AudioSource _activeMusic;
    private AudioSource _inactiveMusic;

    public float crossFadeRate = 1.5f;
    private bool _isCrossFading;

    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    private float _musiceVolume;

    public float musicVolume
    {
        get { return _musiceVolume; }
        set
        {
            _musiceVolume = value;
            if (null != music1Source && !_isCrossFading)
            {
                music1Source.volume = _musiceVolume;
                music2Source.volume = _musiceVolume;
            }
        }
    }

    public bool musicMute
    {
        get
        {
            if (null != music1Source)
            {
                return music1Source.mute;
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (null != music1Source && null != music2Source)
            {
                music1Source.mute = value;
                music2Source.mute = value;
            }
        }
    }

    public void Startup()
    {
        Debug.Log("Audio Manager starting...");

        music1Source.ignoreListenerVolume = true;
        music1Source.ignoreListenerPause = true;
        music2Source.ignoreListenerVolume = true;
        music2Source.ignoreListenerPause = true;

        soundVolume = 1.0f;
        musicVolume = 1.0f;

        _activeMusic = music1Source;
        _inactiveMusic = music2Source;

        status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load("Music/" + introBGMusic) as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }

    public void StopMusic()
    {
        _activeMusic.Stop();
        _inactiveMusic.Stop();
    }

    private void PlayMusic(AudioClip clip)
    {
        if (_isCrossFading)
        {
            return;
        }
        else
        {
            StartCoroutine(CrossFadeMusic(clip));
        }
    }

    private IEnumerator CrossFadeMusic(AudioClip clip)
    {
        _isCrossFading = true;

        _inactiveMusic.clip = clip;
        _inactiveMusic.volume = 0;
        _inactiveMusic.Play();

        float scaleRate = crossFadeRate * _musiceVolume;

        while (_activeMusic.volume > 0)
        {
            _activeMusic.volume = _activeMusic.volume - (scaleRate * Time.deltaTime);
            _inactiveMusic.volume = _inactiveMusic.volume + (scaleRate * Time.deltaTime);

            yield return null;
        }

        AudioSource temp = _activeMusic;
        _activeMusic = _inactiveMusic;
        _inactiveMusic = temp;

        _inactiveMusic.Stop();

        _isCrossFading = false;
    }
}
