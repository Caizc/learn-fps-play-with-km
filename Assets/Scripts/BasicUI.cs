using UnityEngine;

public class BasicUI : MonoBehaviour
{
    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 20), "Test"))
        {
            Debug.Log("Test button click!");
        }
    }
}
