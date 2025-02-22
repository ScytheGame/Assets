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
            healthSlider.maxValue = playerController.maxHealth;
            healthSlider.value = playerController.playerHealth;
        }
    }

    void Update()
    {
        if (playerController != null)
        {
            healthSlider.value = playerController.playerHealth;
            healthSlider.maxValue = playerController.maxHealth;
        }
    }
}
