using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StaminaSlider;
    public PlayerController playerController;

    void Start()
    {
        if (playerController != null)
        {
            StaminaSlider.maxValue = playerController.MaxStamina;
            StaminaSlider.value = playerController.PlayerStamina;
        }
    }
    void Update()
    {
        if (playerController != null)
        {
            StaminaSlider.value = playerController.PlayerStamina;
            StaminaSlider.maxValue = playerController.MaxStamina;
        }
    }
}
