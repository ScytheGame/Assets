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
    [SerializeField] public string SkillNameText;
    [SerializeField] public string skillDescriptionText;
    [SerializeField] public string CelestialCostText;
    [SerializeField] public string SolarCostText;
    [SerializeField] public string UpgradeLevelText;
    [SerializeField] Button UnlockButton;

    [SerializeField] GameObject[] UnlockButtonSprite;

    [SerializeField] Image ButtonSpriteColor;
    [SerializeField] Color[] SkillColour;

    [SerializeField] Upgradepoints Stats;
    [SerializeField] public SkillPrefabController PreviousSkill;
    [SerializeField] Weapon SkillWeapon;
    [SerializeField] float SkillWeaponFloat;
    [SerializeField] ID skillID;
    [SerializeField] string SkillID;


    [Space(10)]
    [Header("Skill Requirments")]
    [SerializeField] float CelestialCost;
    [SerializeField] float SolarCost;
    [SerializeField] float SkillValue;
    [SerializeField] float CelestialCostIncreasePerLevel;
    [SerializeField] float SolarCostIncreasePerLevel;
    float CostIncrease = 0;
    [SerializeField] float UpgradeLevel;
    [SerializeField] float MaxUpgradeLevel;
    [SerializeField] public bool IsOwned;
    [SerializeField] public bool IsLocked;
    [SerializeField] public bool IsHidden;
    [SerializeField] bool CanAfford;
    [SerializeField] bool CanBuy;
    [SerializeField] public bool IsMouseOver;
    [SerializeField] public bool ShowLine;

    private void Start()
    {

        SkillID = skillID.ToString();

        if (SkillWeapon == Weapon.None)
            SkillWeaponFloat = 0;
        if (SkillWeapon == Weapon.Missile)
            SkillWeaponFloat = 1;
        if (SkillWeapon == Weapon.Nuke)
            SkillWeaponFloat = 2;
        if (SkillWeapon == Weapon.Minigun)
            SkillWeaponFloat = 3;
        if (SkillWeapon == Weapon.Homing_Missile)
            SkillWeaponFloat = 4;
        if (SkillWeapon == Weapon.Flak)
            SkillWeaponFloat = 5;
        if (SkillWeapon == Weapon.Drone)
            SkillWeaponFloat = 6;
        if (SkillWeapon == Weapon.Laser)
            SkillWeaponFloat = 7;
        if (SkillWeapon == Weapon.Heavy)
            SkillWeaponFloat = 8;
        if (SkillWeapon == Weapon.Rapid)
            SkillWeaponFloat = 9;
        if (SkillWeapon == Weapon.Homing)
            SkillWeaponFloat = 10;
        if (SkillWeapon == Weapon.Heavy_Mine)
            SkillWeaponFloat = 11;
        if (SkillWeapon == Weapon.Rapid_Mine)
            SkillWeaponFloat = 12;
        if (SkillWeapon == Weapon.Homing_Mine)
            SkillWeaponFloat = 13;

        SkillName();
        SkillDescription();

        for (float i = CostIncrease; i <= UpgradeLevel; i++)
        {
            CelestialCost += CelestialCostIncreasePerLevel;
            SolarCost += SolarCostIncreasePerLevel;
        }


        Load();
    }
    void SkillName()
    {

        if (SkillID.Equals("Start"))
            SkillNameText = ("Start");

        if (SkillID.Equals("DB"))
            SkillNameText = ("Damage Boost");

        if (SkillID.Equals("SB"))
            SkillNameText = ("Speed Boost");

        if (SkillID.Equals("AS"))
            SkillNameText = ("Attack Speed Boost");

        if (SkillID.Equals("PS"))
            SkillNameText = ("Projectile Speed Boost");

        if (SkillID.Equals("HB"))
            SkillNameText = ("Health Boost");

        if (SkillID.Equals("AB"))
            SkillNameText = ("Ammo Boost");

        if (SkillID.Equals("EB"))
            SkillNameText = ("Experience Boost");

        if (SkillID.Equals("SVB"))
            SkillNameText = ("Skill Value Boost");

        if (SkillID.Equals("SCB"))
            SkillNameText = ("Skill Chance Boost");

        if (SkillID.Equals("MS"))
            SkillNameText = ("Multi shot");

        if (SkillID.Equals("DS"))
            SkillNameText = ("Double shot");

        if (SkillID.Equals("BF"))
            SkillNameText = ("Backwards Fire");

        if (SkillID.Equals("ArrS"))
            SkillNameText = ("Array Shot");

        if (SkillID.Equals("ArrSD"))
            SkillNameText = ("Array Shot Double Shot");

        if (SkillID.Equals("RF"))
            SkillNameText = ("Rapid Fire");


        if (SkillID.Equals("Heavy"))
            SkillNameText = ("Heavy Class");

        if (SkillID.Equals("Rapid"))
            SkillNameText = ("Rapid Class");

        if (SkillID.Equals("Homing"))
            SkillNameText = ("Homing Class");


        if (SkillID.Equals("Nuke"))
            SkillNameText = ("Nuke Weapon");

        if (SkillID.Equals("Flak"))
            SkillNameText = ("Flak Weapon");

        if (SkillID.Equals("Laser"))
            SkillNameText = ("Laser Weapon");

        if (SkillID.Equals("HomingMissile"))
            SkillNameText = ("Homing Missile Weapon");

        if (SkillID.Equals("MineH"))
            SkillNameText = ("Heavy Mine Weapon");

        if (SkillID.Equals("MineR"))
            SkillNameText = ("Rapid Mine Weapon");

        if (SkillID.Equals("MineHO"))
            SkillNameText = ("Homing Mine Weapon");

    }
    void SkillDescription()
    {

        if (SkillID.Equals("Start"))
            skillDescriptionText = ("This is the start of your journey, hope you enjoy!");

        if (SkillID.Equals("DB"))
            skillDescriptionText = ("Boosts " + SkillWeapon + " Damage By " + SkillValue * 100 + "%");

        if (SkillID.Equals("SB"))
            skillDescriptionText = ("Boosts Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("AS"))
            skillDescriptionText = ("Boosts " + SkillWeapon + " Attack Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("PS"))
            skillDescriptionText = ("Boosts " + SkillWeapon + " Projectile Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("HB"))
            skillDescriptionText = ("Boosts Health By " + SkillValue);

        if (SkillID.Equals("AB"))
            skillDescriptionText = ("Boosts Ammo By " + SkillValue);

        if (SkillID.Equals("EB"))
            skillDescriptionText = ("Boosts Experience Gain By " + SkillValue);

        if (SkillID.Equals("SVB"))
            skillDescriptionText = ("Boosts Max Level Up Percent by 5%");

        if (SkillID.Equals("SCB"))
            skillDescriptionText = ("Boosts Level Up Value Rates to be higher");

        if (SkillID.Equals("MS"))
            skillDescriptionText = ("Unlocks Multishot");

        if (SkillID.Equals("DS"))
            skillDescriptionText = ("Unlocks Doubleshot");

        if (SkillID.Equals("BF"))
            skillDescriptionText = ("Unlocks Backwards Fire");

        if (SkillID.Equals("RF"))
            skillDescriptionText = ("Unlocks Rapid Fire");

        if (SkillID.Equals("Heavy"))
            skillDescriptionText = ("Unlocks The Heavy Class Skill Tree");

        if (SkillID.Equals("Rapid"))
            skillDescriptionText = ("Unlocks The Rapid Class, And Skill Tree");

        if (SkillID.Equals("Homing"))
            skillDescriptionText = ("Unlocks the homing Class, And Skill Tree");

        if (SkillID.Equals("Nuke"))
            skillDescriptionText = ("Unlocks The Nuke Weapon");

        if (SkillID.Equals("Flak"))
            skillDescriptionText = ("Unlocks The Flak Weapon");

        if (SkillID.Equals("Laser"))
            skillDescriptionText = ("Unlocks The Laser Weapon");

        if (SkillID.Equals("HomingMissile"))
            skillDescriptionText = ("Unlocks The Homing Missile Weapon");

        if (SkillID.Equals("MineH"))
            skillDescriptionText = ("Unlocks the Heavy Mine Weapon");

        if (SkillID.Equals("MineR"))
            skillDescriptionText = ("Unlocks the Rapid Mine Weapon");

        if (SkillID.Equals("MineHO"))
            skillDescriptionText = ("Unlocks the Homing Mine Weapon");

    }
    private void Update()
    {
        if (!IsOwned)
        {
            if (CelestialCost != 0)
                CelestialCostText = ("Celestial Cost:" + Stats.CelestialPoints + " / " + CelestialCost);
            if (SolarCost != 0)
                SolarCostText = ("Solar Cost:" + Stats.SolarPoints + " / " + SolarCost);

                UpgradeLevelText = ( UpgradeLevel + " / " + MaxUpgradeLevel);

            if (CelestialCost == 0)
                ShowLine = true;
            else
                ShowLine = false;

            if (Stats.CelestialPoints >= CelestialCost && Stats.SolarPoints >= SolarCost)
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
            CelestialCostText = "";
            SolarCostText = "";
            UpgradeLevelText = "";
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
                if (UpgradeLevel < MaxUpgradeLevel)
                {
                    UpgradeLevel++;
                    Stats.CelestialPoints -= CelestialCost;
                    Stats.SolarPoints -= SolarCost;
                    if (UpgradeLevel >= MaxUpgradeLevel)
                        IsOwned = true;

                    for (float i = CostIncrease; i <= UpgradeLevel; i++)
                    {
                        CelestialCost += CelestialCostIncreasePerLevel;
                        SolarCost += SolarCostIncreasePerLevel;
                    }
                    SkillTreeData skillData = SkillTreeData.Load();
                    skillData.Apply(SkillID,SkillWeaponFloat,SkillValue);

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
        skillData.Save(gameObject.name, SkillID, SkillValue, IsOwned, UpgradeLevel);
    }

    void Load()
    {
        SkillTreeSkillData skillData = SkillTreeSkillData.LoadSkill();
        SkillEntry SkillEntry = skillData.Load(gameObject.name, SkillID, SkillValue);
        if (SkillEntry != null)
        {
            IsOwned = SkillEntry.IsOwned;
            UpgradeLevel = SkillEntry.UpgradeLevel;
        }
        else
        {
            Debug.LogWarning( gameObject.name + "_ID_" + SkillID + "_Value_" + SkillValue + " not found default values will be used");
            IsOwned = false;
            UpgradeLevel = 0;
        }
    }
}
