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
            StaminaSlider.maxValue = playerController.maxStamina;
            StaminaSlider.value = playerController.playerStamina;
        }
    }
    void Update()
    {
        if (playerController != null)
        {
            StaminaSlider.value = playerController.playerStamina;
            StaminaSlider.maxValue = playerController.maxStamina;
        }
    }
}
