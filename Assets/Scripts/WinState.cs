using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public static Action WinEvent;

    public GameObject endPanel;

    private bool gameEnded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Send the event so everyone knows the key was collected.
            WinEvent?.Invoke();
            endPanel.SetActive(true);
            gameEnded = true;
        }
    }

    private void Update()
    {
        // If game ended then press R to reload the game.
        if (Input.GetKeyDown(KeyCode.R) && gameEnded)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
