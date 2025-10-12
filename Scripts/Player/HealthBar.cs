using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerController playerController;

    void Start()
    {
        if (playerController != null)
        {
            healthSlider.maxValue = playerController.MaxHealth;
            healthSlider.value = playerController.PlayerHealth;
        }
    }

    void Update()
    {
        if (playerController != null)
        {
            healthSlider.value = playerController.PlayerHealth;
            healthSlider.maxValue = playerController.MaxHealth;
        }
    }
}
