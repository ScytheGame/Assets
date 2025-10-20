using Radishmouse;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillPrefabController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject SkillCard;
    [SerializeField] GameObject UI;
    [SerializeField] UILineRenderer UILine;
    [SerializeField] Button UnlockButton;
    [SerializeField] public SkillTree SkillTree;
    SkillTree SkillTreeObject;


    [SerializeField] GameObject[] UnlockButtonSprite;
    [SerializeField] Image ButtonSpriteColor;
    [SerializeField] Color[] SkillColour;

    [SerializeField] Upgradepoints Stats;
    [SerializeField] public SkillPrefabController PreviousSkill;


    [Space(10)]
    [Header("Skill Requirments")]
    [SerializeField] public bool IsOwned;
    [SerializeField] public bool IsLocked;
    [SerializeField] public bool IsHidden;
    [SerializeField] bool CanAfford;
    [SerializeField] bool CanBuy;
    [SerializeField] public bool IsMouseOver;
    [SerializeField] public bool ShowLine;

    private void Start()
    {
        SkillTreeObject = SkillTree;
        SkillTree = ScriptableObject.Instantiate(SkillTree);
        SkillTreeObject.SkillTreeInstance = SkillTree;
        
        for (float i = 1; i <= SkillTree.UpgradeLevel; i++)
        {
            SkillTree.CelestialCost += SkillTree.CelestialCostIncreasePerLevel;
            SkillTree.SolarCost += SkillTree.SolarCostIncreasePerLevel;
        }


        Load();
    }
    private void Update()
    {
        if (!IsOwned)
        {
            if (SkillTree.CelestialCost != 0)
                SkillTree.CelestialCostText = ("Celestial Cost:" + Stats.CelestialPoints + " / " + SkillTree.CelestialCost);
            if (SkillTree.SolarCost != 0)
                SkillTree.SolarCostText = ("Solar Cost:" + Stats.SolarPoints + " / " + SkillTree.SolarCost);

            SkillTree.UpgradeLevelText = (SkillTree.UpgradeLevel + " / " + SkillTree.MaxUpgradeLevel);

            if (SkillTree.CelestialCost == 0)
                ShowLine = true;
            else
                ShowLine = false;

            if (Stats.CelestialPoints >= SkillTree.CelestialCost && Stats.SolarPoints >= SkillTree.SolarCost)
                CanAfford = true;

            else
                CanAfford = false;

            if (PreviousSkill != null)
            {
                if (PreviousSkill.IsOwned)
                    CanBuy = true;
                else
                    CanBuy = false;
            }
            else
            {
                CanBuy = true;
            }
        }
        else
        {
            SkillTree.CelestialCostText = "";
            SkillTree.SolarCostText = "";
            SkillTree.UpgradeLevelText = "";
        }
        if (PreviousSkill != null)
        {
            if (PreviousSkill.IsLocked)
            {
                IsHidden = true;
            }
            else
            {
                IsHidden = false;
            }
        }
        else
        {
            IsHidden = false;
        }

        if (PreviousSkill != null)
        {
            if (PreviousSkill.IsOwned)
            {
                IsLocked = false;
            }
            else
            {
                IsLocked = true;
            }
        }
        else
        {
            IsLocked = false;
        }


        if (!CanAfford || !CanBuy || IsOwned || IsLocked)
        {
            Disable();
        }
        if (CanAfford && CanBuy && !IsOwned)
        {
            Enable();
        }

        if (IsMouseOver)
        {
            UILine.color = SkillColour[2];
            ButtonSpriteColor.color = SkillColour[2];
        }
        else if (IsOwned)
        {
            UILine.color = SkillColour[1];
            ButtonSpriteColor.color = SkillColour[1];
        }
        else
        {
            UILine.color = SkillColour[0];
            ButtonSpriteColor.color = SkillColour[0];
        }




        UnlockButtonSprite[0].SetActive(IsLocked); // if true will be true 
        UnlockButtonSprite[1].SetActive(!IsLocked); // if true will be false

        UI.SetActive(!IsHidden);
        UILine.enabled = !IsHidden;
    }

    public void Unlock()
    {
        if (CanAfford && IsOwned == false)
        {
            if (CanBuy)
            {
                if (SkillTree.UpgradeLevel < SkillTree.MaxUpgradeLevel)
                {
                    SkillTree.UpgradeLevel++;
                    
                    Stats.RemoveCelestialPoints((int)SkillTree.CelestialCost);
                    Stats.RemoveSolarPoints((int)SkillTree.SolarCost);

                    if (SkillTree.UpgradeLevel >= SkillTree.MaxUpgradeLevel)
                        IsOwned = true;

                    SkillTree.CelestialCost += SkillTree.CelestialCostIncreasePerLevel;
                    SkillTree.SolarCost += SkillTree.SolarCostIncreasePerLevel;
                    
                    SkillTreeData skillData = SkillTreeData.Load();
                    if (SkillTree.Weapon  != null)
                        skillData.Apply(SkillTree.BaseSkillType, SkillTree.SkillValue, SkillTree.Weapon.WeaponName, SkillTree.Weapon);
                    else 
                        skillData.Apply(SkillTree.BaseSkillType, SkillTree.SkillValue, "N/A", null);
                    //Skill.Upgrade(SkillID, SkillWeaponFloat, SkillValue); // SkillId, Float Weapon, Float Value
                    Save();
                    Stats.Save();
                }
            }
        }
    }

    void Enable()
    {
        UnlockButton.interactable = true;
    }

    void Disable()
    {
        UnlockButton.interactable = false;
    }

    void Save()
    {
        SkillTreeSkillData skillData = SkillTreeSkillData.LoadSkill();
        skillData.Save(gameObject.name, SkillTree.BaseSkillType.ToString(), SkillTree.SkillValue, IsOwned, SkillTree.UpgradeLevel);
    }

    void Load()
    {
        SkillTreeSkillData skillData = SkillTreeSkillData.LoadSkill();
        SkillEntry SkillEntry = skillData.Load(gameObject.name, SkillTree.BaseSkillType.ToString(), SkillTree.SkillValue);
        if (SkillEntry != null)
        {
            IsOwned = SkillEntry.IsOwned;
            SkillTree.UpgradeLevel = SkillEntry.UpgradeLevel;
        }
        else
        {
            Debug.LogWarning( gameObject.name + "_ID_" + SkillTree.BaseSkillType + "_Value_" + SkillTree.SkillValue + " not found default values will be used");
            IsOwned = false;
            SkillTree.UpgradeLevel = 0;
        }
    }
}
