using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Lock the mouse in the middle of the screen so TPV can be handled correctly (press ESC to free mouse).
    void Start() => UnityEngine.Cursor.lockState = CursorLockMode.Locked;
}
