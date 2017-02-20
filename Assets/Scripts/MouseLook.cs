using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 2.0f;
    public float sensitivityVert = 2.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;

    void Update()
    {
        switch (axes)
        {

            case RotationAxes.MouseXAndY:
                _rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                _rotationY = this.transform.localEulerAngles.y + delta;

                this.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
                break;

            case RotationAxes.MouseX:
                this.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                break;

            case RotationAxes.MouseY:
                _rotationX = _rotationX - Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                _rotationY = this.transform.localEulerAngles.y;

                this.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
                break;

            default:
                break;
        }
    }
}
