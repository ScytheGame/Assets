using UnityEngine;
using UnityEngine.UI;

public class EnemyBossHealthBar : MonoBehaviour
{
    [SerializeField] GameObject BossHealthBar;
    [SerializeField] Slider BossHealthSlider;
    public void UpdateHealthBar(float CurrentBossHealth, float MaxBossHealth)
    {
        BossHealthSlider.value = CurrentBossHealth;
        BossHealthSlider.maxValue = MaxBossHealth;
    }
    public void HideHealthBar()
    {
        BossHealthBar.SetActive(false);
    }
    public void ShowHealthBar()
    {
        BossHealthBar.SetActive(true);
    }
}
