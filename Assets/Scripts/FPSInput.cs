using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{

    public float speed = 6f;

    private CharacterController _charactorController;

	public float gravity = -9.8f;

    // Use this for initialization
    void Start()
    {
        _charactorController = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;

        movement = movement * Time.deltaTime;
        movement = this.transform.TransformDirection(movement);
        _charactorController.Move(movement);

        // this.transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}
