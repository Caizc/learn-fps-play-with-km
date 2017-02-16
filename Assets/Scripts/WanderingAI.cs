using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public float speed = 2.0f;
    public float obstacleRange = 3.0f;

    private bool _isAlive;

    [SerializeField]
    private GameObject fireballPrefab;
    private GameObject _fireball;

    public void SetIsAlive(bool isAlive)
    {
        this._isAlive = isAlive;
    }

    // Use this for initialization
    void Start()
    {
        _isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAlive)
        {
            return;
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hitInfo;

        bool isHit = Physics.SphereCast(ray, 0.75f, out hitInfo);
        if (isHit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>() && null == _fireball)
            {
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);
                _fireball.transform.rotation = this.transform.rotation;
            }
            else if (hitInfo.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                this.transform.Rotate(0, angle, 0);
            }
        }
    }
}
