using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 0.5f;

    void Start()
    {
        SayHello();
    }

    void Update()
    {
        this.transform.Rotate(0, speed, 0, Space.Self);
    }

    private void SayHello()
    {
        Debug.Log("Hello World!");
    }
}
