using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 5.0f;
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
        if (null != player)
        {
            Debug.Log("Player hit!");
            player.Hurt(damage);
        }

        Destroy(this.gameObject);
    }
}
