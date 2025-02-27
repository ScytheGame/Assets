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
    [SerializeField] StatsController Stats;
    [SerializeField] SkillTreeController Skill;
    [SerializeField] List<SkillPrefabController> PreviousSkills;
    [SerializeField] List<SkillPrefabController> OtherSkillTypes;
    [SerializeField] List<SkillPrefabController> DisableCards;


    [Space(10)]
    [Header("Skill Requirments")]
    [SerializeField] float CelestialCost;
    [SerializeField] float SolarCost;
    [SerializeField] public string SkillID;
    [SerializeField] float SkillValue;
    [SerializeField] public bool IsOwned;
    [SerializeField] bool IsLocked;
    [SerializeField] bool IsUpgradable;
    [SerializeField] float UpgradeLevel;
    [SerializeField] float MaxUpgradeLevel;
    [SerializeField] bool CanAfford;
    [SerializeField] bool NonEnding;
    [SerializeField] bool IsRandomSkill;
    [SerializeField] float RandomValue;
    private void Start()
    {
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
    }
    void SkillName()
    {
        if (!SkillID.Equals("MS") || !SkillID.Equals("DS") || !SkillID.Equals("AA") || !SkillID.Equals("HC") || !SkillID.Equals("PS"))
        {
            if (SkillValue == 0);

            else if (SkillValue <= 0.15)
            {
                SkillNameText.text = ("Weak ");
            }
            else if (SkillValue <= 0.3)
            {
                SkillNameText.text = ("Moderate ");
            }
            else if (SkillValue <= 0.5)
            {
                SkillNameText.text = ("Strong ");
            }
            else if (SkillValue > 0.5)
            {
                SkillNameText.text = ("Greatest ");
            }

            if (SkillID.Equals("DB"))
                SkillNameText.text += ("Damage Boost");

            if (SkillID.Equals("SB"))
                SkillNameText.text += ("Speed Boost");

            if (SkillID.Equals("AS"))
                SkillNameText.text += ("Attack Speed Boost");

            if (SkillID.Equals("PS"))
                SkillNameText.text += ("Projectile Speed Boost");

            if (SkillID.Equals("HB"))
                SkillNameText.text += ("Health Boost");

            if (SkillID.Equals("ER"))
                SkillNameText.text += ("Explosion Radius Boost");

            if (SkillID.Equals("EB"))
                SkillNameText.text += ("Experience Boost");
        }
        else
        {
            if (SkillID.Equals("MS"))
                SkillNameText.text = ("Multishot");

            if (SkillID.Equals("DS"))
                SkillNameText.text = ("Doubleshot");

            if (SkillID.Equals("AA"))
                SkillNameText.text = ("Aim Assist");

            if (SkillID.Equals("HC"))
                SkillNameText.text = ("Homing");

            if (SkillID.Equals("PS"))
                SkillNameText.text = ("Poison Bullets");

            if (SkillID.Equals("DP"))
                SkillNameText.text = ("Double Points");
        }
    }
    void SkillDescription()
    {
        if (SkillID.Equals("DB"))
                skillDescriptionText.text = ("Boosts Damage By " + SkillValue * 100 + "%");

            if (SkillID.Equals("SB"))
                skillDescriptionText.text = ("Boosts Speed By " + SkillValue * 100 + "%");

            if (SkillID.Equals("AS"))
                skillDescriptionText.text = ("Boosts Attack Speed By " + SkillValue * 100 + "%");

            if (SkillID.Equals("PS"))
                skillDescriptionText.text = ("Boosts Projectile Speed By " + SkillValue * 100 + "%");

            if (SkillID.Equals("HB"))
                skillDescriptionText.text = ("Boosts Health By " + SkillValue * 100 + "%");

            if (SkillID.Equals("ER"))
                skillDescriptionText.text = ("Boosts Explosion Radius By " + SkillValue * 100 + "%");

            if (SkillID.Equals("EB"))
                skillDescriptionText.text = ("Boosts Experience Gain By " + SkillValue * 100 + "%");

            if (SkillID.Equals("MS"))
                skillDescriptionText.text = ("Unlocks Multishot");

            if (SkillID.Equals("DS"))
                skillDescriptionText.text = ("Unlocks Doubleshot");

            if (SkillID.Equals("AA"))
                skillDescriptionText.text = ("Unlocks Aim Assist");

            if (SkillID.Equals("HC"))
                skillDescriptionText.text = ("Unlocks Homing");

            if (SkillID.Equals("PS"))
                skillDescriptionText.text = ("Poison Bullets");

            if (SkillID.Equals("DP"))
                skillDescriptionText.text = ("Gain 2 points per level");

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

            if (IsRandomSkill)
            {
                RandomValue = Random.Range(0, 11);
                SkillValue = Random.Range(0f, 0.6f);
                RandomBoost();
            }
                Skill.Upgrade(SkillID, SkillValue);
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
    void RandomBoost()
    {

        RandomValue = Mathf.Floor(RandomValue);
        if (RandomValue == 0 || RandomValue == 6)
        {
            SkillID = ("DB");
        }
        if (RandomValue == 1 || RandomValue == 7)
        {
            SkillID = ("SB");
        }
        if (RandomValue == 2 || RandomValue == 8)
        {
            SkillID = ("AS");
        }
        if (RandomValue == 3 || RandomValue == 9)
        {
            SkillID = ("PS");
        }
        if (RandomValue == 4 || RandomValue == 10)
        {
            SkillID = ("HB");
        }
        if (RandomValue == 5 || RandomValue == 11)
        {
            SkillID = ("EB");
        }
        SkillName();
        SkillDescription();
    }
    void DisableCard(SkillPrefabController Card)
    {
        Card.Disable();
    }
}
