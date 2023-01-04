using UnityEngine;

public class Cursor : MonoBehaviour
{
    void Start() => UnityEngine.Cursor.lockState = CursorLockMode.Locked;
}
