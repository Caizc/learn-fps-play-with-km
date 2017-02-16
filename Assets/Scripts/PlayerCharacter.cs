using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    // Use this for initialization
    void Start()
    {
        _health = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hurt(int damage)
    {
        _health = _health - damage;
        Debug.Log("Player Health: " + _health);
    }
}
