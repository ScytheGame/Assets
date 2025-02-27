using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillPrefabController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject SkillCard;
    [SerializeField] TextMeshProUGUI SkillNameText;
    [SerializeField] TextMeshProUGUI skillDescriptionText;
    [SerializeField] TextMeshProUGUI CelestialCostText;
    [SerializeField] TextMeshProUGUI SolarCostText;
    [SerializeField] GameObject CelestialCostGameObject;
    [SerializeField] GameObject SolarCostGameObject;
    [SerializeField] TextMeshProUGUI UpgradeLevelText;
    [SerializeField] GameObject UnlockButtonGameObject;
    [SerializeField] Button UnlockButton;
    [SerializeField] TextMeshProUGUI UnlockButtonText;
    [SerializeField] Upgradepoints Stats;
    [SerializeField] SkillTreeController Skill;
    [SerializeField] List<SkillPrefabController> PreviousSkills;
    [SerializeField] List<SkillPrefabController> OtherSkillTypes;
    [SerializeField] List<SkillPrefabController> DisableCards;
    [SerializeField] enum Weapon { None = 0, Missile = 1, Nuke = 2, Minigun = 3, HomingMissile = 4, Flak = 5, Drone = 6, Laser = 7, Heavy = 8, Rapid = 9, Homing = 10 };
    [SerializeField] Weapon SkillWeapon;
    [SerializeField] float SkillWeaponFloat;
    [SerializeField] enum ID { None = 0, DB = 1, SB = 2, AS = 3, PS = 4, HB = 5, EB = 6, MS = 7, DS = 8, BF = 9, ArrS = 10, ArrSB = 11, RF = 12, Rapid = 13, Homing = 14, Nuke = 15, FLak = 16, Laser = 17, HomingMissile = 18};
    [SerializeField] ID skillID;
    [SerializeField] string SkillID;


    [Space(10)]
    [Header("Skill Requirments")]
    [SerializeField] float CelestialCost;
    [SerializeField] float SolarCost;
    [SerializeField] float SkillValue;
    [SerializeField] public bool IsOwned;
    [SerializeField] bool IsLocked;
    [SerializeField] bool IsUpgradable;
    [SerializeField] float UpgradeLevel;
    [SerializeField] float MaxUpgradeLevel;
    [SerializeField] bool CanAfford;
    [SerializeField] bool NonEnding;
    [SerializeField] float RandomValue;
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
        if (SkillWeapon == Weapon.HomingMissile)
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

        if (CelestialCost == 0)
        {
            CelestialCostGameObject.SetActive(false);
        }
        else
        {
            CelestialCostText.text = (":" + CelestialCost);
            CelestialCostGameObject.SetActive(true);
        }
        if (SolarCost == 0)
        {
            SolarCostGameObject.SetActive(false);
        }
        else
        {
            SolarCostText.text = (":" + SolarCost);
            SolarCostGameObject.SetActive(true);
        }



        if (Stats.CelestialPoints >= CelestialCost && Stats.SolarPoints >= SolarCost)
        {
            CanAfford = true;
        }
        else
        {
            CanAfford = false;
        }
        SkillName();
        SkillDescription();

        IsOwned = (PlayerPrefs.GetInt("IsOwnedST") != 0);
        UpgradeLevel = PlayerPrefs.GetFloat("UpgradeLevelST", 0);

        Debug.Log(IsOwned);
        Debug.Log(UpgradeLevel);
    }
    void SkillName()
    {
        if (!SkillID.Equals("MS") || !SkillID.Equals("DS") || !SkillID.Equals("BF") || !SkillID.Equals("ArrS") || !SkillID.Equals("ArrSD") || !SkillID.Equals("Rapid") || !SkillID.Equals("Homing") || !SkillID.Equals("Nuke") || !SkillID.Equals("Flak") || !SkillID.Equals("Laser") || !SkillID.Equals("HomingMissile"))
        {

            if (SkillID.Equals("DB"))
                SkillNameText.text = ("Damage Boost");

            if (SkillID.Equals("SB"))
                SkillNameText.text = ("Speed Boost");

            if (SkillID.Equals("AS"))
                SkillNameText.text = ("Attack Speed Boost");

            if (SkillID.Equals("PS"))
                SkillNameText.text = ("Projectile Speed Boost");

            if (SkillID.Equals("HB"))
                SkillNameText.text = ("Health Boost");

            if (SkillID.Equals("EB"))
                SkillNameText.text = ("Experience Boost");
        }
        else
        {
            if (SkillID.Equals("MS"))
                SkillNameText.text = ("Multi shot");

            if (SkillID.Equals("DS"))
                SkillNameText.text = ("Double shot");

            if (SkillID.Equals("BF"))
                SkillNameText.text = ("Backwards Fire");

            if (SkillID.Equals("ArrS"))
                SkillNameText.text = ("Array Shot");

            if (SkillID.Equals("ArrSD"))
                SkillNameText.text = ("Array Shot Double Shot");

            if (SkillID.Equals("RF"))
                SkillNameText.text = ("Rapid Fire");


            if (SkillID.Equals("Rapid"))
                SkillNameText.text = ("Rapid Class");

            if (SkillID.Equals("Homing"))
                SkillNameText.text = ("Homing Class");


            if (SkillID.Equals("Nuke"))
                SkillNameText.text = ("Nuke Weapon");

            if (SkillID.Equals("Flak"))
                SkillNameText.text = ("Flak Weapon");

            if (SkillID.Equals("Laser"))
                SkillNameText.text = ("Laser Weapon");

            if (SkillID.Equals("HomingMissile"))
                SkillNameText.text = ("Homing Missile Weapon");
        }
    }
    void SkillDescription()
    {
        if (SkillID.Equals("DB"))
            skillDescriptionText.text = ("Boosts " + SkillWeapon + " Damage By " + SkillValue * 100 + "%");

        if (SkillID.Equals("SB"))
            skillDescriptionText.text = ("Boosts Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("AS"))
            skillDescriptionText.text = ("Boosts " + SkillWeapon + " Attack Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("PS"))
            skillDescriptionText.text = ("Boosts " + SkillWeapon + " Projectile Speed By " + SkillValue * 100 + "%");

        if (SkillID.Equals("HB"))
            skillDescriptionText.text = ("Boosts Health By " + SkillValue);

        if (SkillID.Equals("EB"))
            skillDescriptionText.text = ("Boosts Experience Gain By " + SkillValue);

        if (SkillID.Equals("MS"))
            skillDescriptionText.text = ("Unlocks Multishot");

        if (SkillID.Equals("DS"))
            skillDescriptionText.text = ("Unlocks Doubleshot");

        if (SkillID.Equals("BF"))
            skillDescriptionText.text = ("Unlocks Backwards Fire");

        if (SkillID.Equals("RF"))
            skillDescriptionText.text = ("Unlocks Rapid Fire");

        if (SkillID.Equals("Rapid"))
            skillDescriptionText.text = ("Unlocks The Rapid Class");

        if (SkillID.Equals("Homing"))
            skillDescriptionText.text = ("Unlocks the homing Class");

        if (SkillID.Equals("Nuke"))
            skillDescriptionText.text = ("Unlocks The Nuke Weapon");

        if (SkillID.Equals("Flak"))
            skillDescriptionText.text = ("Unlocks The Flak Weapon");

        if (SkillID.Equals("Laser"))
            skillDescriptionText.text = ("Unlocks The Laser Weapon");

        if (SkillID.Equals("HomingMissile"))
            skillDescriptionText.text = ("Unlocks The Homing Missile Weapon");

    }

    void Update()
    {
        if (!IsOwned)
        {
            foreach (SkillPrefabController PreviousSkill in PreviousSkills)
            {
                if (PreviousSkill != null)
                {
                    if (PreviousSkill.IsOwned)
                    {
                        UnlockButton.interactable = true;
                        UnlockButtonText.text = ("Unlock");
                    }
                    else
                    {
                        UnlockButton.interactable = false;
                        UnlockButtonText.text = ("Locked");
                        break;
                    }
                }
            }
        }
        if (NonEnding)
        {
            UpgradeLevelText.text = ("");
        }
        else
        {
            UpgradeLevelText.text = (UpgradeLevel + "/" + MaxUpgradeLevel);
        }
        foreach (SkillPrefabController OtherSkillTypes in OtherSkillTypes)
        {
            if (OtherSkillTypes != null)
            {
                if (OtherSkillTypes.IsOwned)
                {
                    Disable();
                }
            }
        }
    }

    public void Unlock()
    {
        if (Stats.CelestialPoints >= CelestialCost && Stats.SolarPoints >= SolarCost)
        {
            if (DisableCards != null)
            {
                foreach (SkillPrefabController Card in DisableCards)
                {
                    DisableCard(Card);
                }
            }
            Stats.CelestialPoints -= CelestialCost;
            Stats.SolarPoints -= SolarCost;

            Skill.Upgrade(SkillID, SkillWeaponFloat, SkillValue);
            if (NonEnding)
            {

            }
            else
            {
                UpgradeLevel++;
            }
            if (UpgradeLevel >= MaxUpgradeLevel)
            {
                IsUpgradable = false;
            }
            else
            {
                IsUpgradable = true;
            }
            if (!IsUpgradable)
            {
                IsOwned = true;
                UnlockButtonText.text = ("Owned");
                UnlockButton.interactable = false;
            }
            else
            {
                if (IsLocked)
                {
                    if (!IsUpgradable)
                    {
                        IsLocked = false;
                    }
                }
                else
                {
                    IsOwned = true;
                }
                UnlockButtonText.text = ("Upgrade");
            }
            Stats.Save();
            Save();
        }
        else
        {
            UnlockButtonText.text = ("Can't afford");
        }

    }

    public void Disable()
    {
        UnlockButton.interactable = false;
        UnlockButtonText.text = ("Cannot Unlock");
    }
    void DisableCard(SkillPrefabController Card)
    {
        Card.Disable();
    }

    void Save()
    {
        Debug.Log(IsOwned);
        Debug.Log(UpgradeLevel);
        PlayerPrefs.SetFloat("UpgradeLevelST", UpgradeLevel);
        PlayerPrefs.SetInt("IsOwnedST", (IsOwned ? 1 : 0));
        Debug.Log("Saved Skill Tree");

    }
}
