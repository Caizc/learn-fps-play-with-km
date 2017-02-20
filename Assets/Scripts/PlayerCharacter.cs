using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int _health;

    public void Hurt(int damage)
    {
        _health = _health - damage;
        Debug.Log("Player Health: " + _health);
    }
}
