using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static Action KeyCollectedEvent;
    private const int SpeedRotation = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollectedEvent?.Invoke(); // Send the event so everyone knows the key was collected.
            gameObject.SetActive(false); // Deactivate the key game object (don't destroy to avoid GC).
        }
    }

    void Update() => transform.Rotate(0, Time.deltaTime * SpeedRotation, 0); // Little animation for the key
}
