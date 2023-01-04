using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    // If the key was picked up then remove the door out of the way to the finish line.
    private void Start() => Key.KeyCollectedEvent += () => Destroy(this.gameObject);
}
