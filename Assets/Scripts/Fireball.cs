using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 8.0f;
    public int damage = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        ReactiveTarget enemy = other.GetComponent<ReactiveTarget>();

        if (null != player)
        {
            Debug.Log("Player hit!");
            player.Hurt(damage);
        }
        else if (null != enemy)
        {
            Debug.Log("Enemy die!");
            enemy.ReactToHit();
        }

        Destroy(this.gameObject);
    }
}
