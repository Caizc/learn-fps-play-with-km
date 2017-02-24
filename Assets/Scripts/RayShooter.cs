using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    [SerializeField]
    private GameObject fireballPrefab;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip hitWallSound;
    [SerializeField]
    private AudioClip hitEnemySound;

    void Start()
    {
        _camera = this.GetComponent<Camera>();

        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hitInfo;
            bool isHit = Physics.Raycast(ray, out hitInfo);
            if (isHit)
            {
                GameObject hitObject = hitInfo.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (null != target)
                {
                    GameObject _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    _fireball.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = this.transform.rotation;

                    soundSource.PlayOneShot(hitEnemySound);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hitInfo.point));

                    soundSource.PlayOneShot(hitWallSound);
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.position = position;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
