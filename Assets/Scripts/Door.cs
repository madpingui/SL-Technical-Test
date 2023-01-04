using UnityEngine;

public class Door : MonoBehaviour
{
    // If the key was picked up then deactivate the door out of the way to the finish line (don't destroy to avoid GC).
    private void Start() => Key.KeyCollectedEvent += () => gameObject.SetActive(false);
}
