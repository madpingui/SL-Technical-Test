using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static Action KeyCollectedEvent;
    private const int SpeedRotation = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Send the event so everyone knows the key was collected.
            KeyCollectedEvent?.Invoke();

            // Destroy the key game object.
            Destroy(gameObject);
        }
    }

    void Update() => transform.Rotate(0, Time.deltaTime * SpeedRotation, 0); // Little animation for the key
}
