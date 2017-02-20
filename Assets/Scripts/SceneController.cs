using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject _enemy;

    private float _speed;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Update()
    {
        if (null == _enemy)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;

            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

            WanderingAI wanderingAI = _enemy.GetComponent<WanderingAI>();
            if (null != wanderingAI)
            {
                wanderingAI.speed = _speed;
            }
        }
    }

    private void OnSpeedChanged(float value)
    {
        _speed = value;
    }
}
