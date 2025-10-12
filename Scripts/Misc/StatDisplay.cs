using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI Ammo;
    [SerializeField] TextMeshProUGUI Speed;
    [SerializeField] TextMeshProUGUI ExtraLives;
    [SerializeField] TextMeshProUGUI ExpBuff;

    [Space(10)]
    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] SkillsController skillController;
    [SerializeField] LevelsManager levelsManager;
    [SerializeField] StatsController StatsController;


    float ExpGain { get => StatsController.ExpGain; }

    void Update()
    {
        Health.text = "Health " + Mathf.Round(playerController.PlayerHealth) + "/" + playerController.MaxHealth;
        Ammo.text = "Ammo " + Mathf.Round(playerController.PlayerStamina) + "/" + playerController.MaxStamina;
        Speed.text = "Speed " + Mathf.Round(playerController.MoveSpeed);
        ExtraLives.text = "Extra lives " + StatsController.ExtraLives;
        ExpBuff.text = "XP gain " + ExpGain;
    }

}
