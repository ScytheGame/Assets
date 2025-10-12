using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.AI;
public class LevelsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI CurrentLevelText;
    [SerializeField] TextMeshProUGUI xpText;
    SkillsController SkillsController;
    StatsController StatsController;
    public Slider XPBar;


    public float TargetXP { get => StatsController.TargetXP; set => StatsController.TargetXP = value; }
    float TargetXpIncrease { get => StatsController.TargetXpIncrease; set => StatsController.TargetXpIncrease = value; }
    public bool LeveledUp { get => StatsController.LeveledUp; set => StatsController.LeveledUp = value; }

    public int CurrentLevel { get => StatsController.CurrentLevel; set => StatsController.CurrentLevel = value; }
    public float CurrentXP { get => StatsController.CurrentXP; set => StatsController.CurrentXP = value; }


    private void Start()
    {
        SkillsController = GameObject.FindWithTag("Player").GetComponent<SkillsController>();
        StatsController = GameObject.FindWithTag("Player").GetComponent<StatsController>();
        CurrentLevel = 1;
        UpdateHUD();
    }


    public void FixedUpdate()
    {
        CheckForLevelUp();
        UpdateHUD();
    }

    private void CheckForLevelUp()
    {

        if (CurrentXP >= TargetXP)
        {
            CurrentLevel++;
            CurrentXP = 0;
            TargetXP += TargetXpIncrease;
            LeveledUp = true;
            LeveledUp = true;
        }

        if (LeveledUp == true)
        {
            SkillsController.DisplaySkillPanel();
        }
        LeveledUp = false;
    }

    private void UpdateHUD()
    {
        CurrentLevelText.text = "Level " + CurrentLevel;
        xpText.text = CurrentXP + "/" + TargetXP;
        XPBar.maxValue = TargetXP;
        XPBar.value = CurrentXP;
    }
}
