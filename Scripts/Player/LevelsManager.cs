using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.AI;
public class LevelsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currentLevelText;
    [SerializeField] TextMeshProUGUI xpText;
    [SerializeField] SkillsController SkillsController;
    [SerializeField] StatsController StatsController;
    public Slider xpBar;

    [Space(10)]
    [Header("Settings")]
    [SerializeField] public float targetXP;
    [SerializeField] float targetXpIncrease;
    public bool leveledUp = false;

    public float currentLevel;
    public float currentXP;
    private List<Button> skillButtons;


    private void Start()
    {
        StatsController.currentLevel = 1;
        UpdateHUD();
    }


    public void Update()
    {
        CheckForLevelUp();
        UpdateHUD();
        currentLevel = StatsController.currentLevel;
        currentXP = StatsController.currentXP;
        leveledUp = StatsController.leveledUp;
        targetXP = StatsController.targetXP;
        targetXpIncrease = StatsController.targetXpIncrease;
        
    }

    private void CheckForLevelUp()
    {

        if (StatsController.currentXP >= StatsController.targetXP)
        {
            StatsController.currentLevel++;
            StatsController.currentXP = 0;
            StatsController.targetXP += StatsController.targetXpIncrease;
            StatsController.leveledUp = true;
            leveledUp = true;
        }

        if (leveledUp == true)
        {
            SkillsController.DisplaySkillPanel();
        }
        StatsController.leveledUp = false;
    }

    private void UpdateHUD()
    {
        currentLevelText.text = "Level " + StatsController.currentLevel;
        xpText.text = StatsController.currentXP + "/" + StatsController.targetXP;
        xpBar.maxValue = StatsController.targetXP;
        xpBar.value = StatsController.currentXP;
    }
}
