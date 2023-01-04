using UnityEngine;
using UnityEngine.UI;

public class FuelIndicator : MonoBehaviour
{
    public PlayerMovement player;
    public Slider slider;
    public Image sliderFill;

    void Update()
    {
        slider.value = player.currentFuel / player.maxFuel;                  // Move slider based on jetpack fuel.
        sliderFill.color = Color.Lerp(Color.red, Color.green, slider.value); // Change color based on jetpack fuel.
    }
}
