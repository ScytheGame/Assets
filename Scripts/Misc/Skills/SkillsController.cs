
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Rendering;
using Sirenix.Utilities;

public class SkillsController : MonoBehaviour
{
    [Space(10)]
    [Header("Skill Panel")]
    [SerializeField] public GameObject SkillPanel;
    [SerializeField] Transform skillContainer;
    [SerializeField] GameObject skillCardPrefab;
    [SerializeField] StatsController StatsController;

    [Space(10)]
    [Header("Skills List")]
    public List<SkillData> allSkills = new List<SkillData>();
    private List<Button> skillButtons;

    [Space(10)]
    [Header("Base Weapon")]
    [SerializeField] GameObject WeaponCardPrefabHeavy, WeaponCardPrefabHoming, WeaponCardPrefabRapid;
    [SerializeField] public enum BaseWeapon { None = 0, Heavy = 1, Homing = 2, Rapid = 3 };
    [SerializeField] public BaseWeapon SelectedWeapon;
    [SerializeField] Skill Skill;
    [SerializeField] public bool WeaponSelected = false;

    [Space(10)]
    [Header("Skills Controller")]
    [SerializeField] AllSkills AllSkills;

    bool weaponClassSelected = false;
    public float playerLevel;
    public List<SkillData> unlockedSkills = new List<SkillData>();
    public Dictionary<string, int> skillSelectionCounts = new Dictionary<string, int>();


    private void Start()
    {
        SkillPanel.SetActive(false);

        skillButtons = new List<Button>();
        WeaponSelector();
        
    }

    public void AddSkills(List<SkillData> skills)
    {
        allSkills.Clear();
        allSkills = skills;
        Debug.Log("Number of skills: " + allSkills.Count);
        foreach (SkillData skillData in allSkills)
        {
            Debug.Log("Skill Name: " + skillData.skillName);
        }
    }
    void WeaponSelector()
    {
        Time.timeScale = 0;
        SkillPanel.SetActive(true);
        if (weaponClassSelected == false)
        {
            Instantiate(WeaponCardPrefabHeavy, skillContainer);
            Instantiate(WeaponCardPrefabRapid, skillContainer);
            Instantiate(WeaponCardPrefabHoming, skillContainer);
            weaponClassSelected = true;
        }
    }

    public void DisplaySkillPanel()
    {
        Time.timeScale = 0;
        SkillPanel.SetActive(true);
        PopulateSkillChoices();
    }


    private void PopulateSkillChoices()
    {
        AllSkills.UpdateSkills();
        Debug.Log("skillContainer: " + skillContainer);
        Debug.Log("skillCardPrefab: " + skillCardPrefab);
        Debug.Log("skillButtons: " + skillButtons.Count);
        foreach (SkillData skillData in allSkills)
        {
            Debug.Log("Skill Name" + skillData.skillName);
        }

        foreach (Transform child in skillContainer)
        {
            Destroy(child.gameObject);
        }


        int count = 3;


        List<SkillData> selectableSkills = new List<SkillData>();


        foreach (SkillData skill in allSkills)
        {
            Debug.Log("Skill Name: " + skill.skillName);
            Debug.Log("player level " + playerLevel + " : " + skill.requiredLevel);
            Debug.Log("is unlocked skill " + unlockedSkills.Contains(skill));
            Debug.Log("is not skill one time " + !skill.isOneTime);
            Debug.Log("are prerequisites met " + ArePrerequisitesMet(skill));
            Debug.Log("is skill not multiple time " + !skill.isMultipleTime);
            if (skill.isMultipleTime)
            {
                Debug.Log("skill Current level " + skill.currentLevel + " : " + skill.MaxLevel);
            }
            if (playerLevel >= skill.requiredLevel && (!unlockedSkills.Contains(skill)) && ArePrerequisitesMet(skill) && !skill.isMultipleTime)
            {
                selectableSkills.Add(skill);
            }
            else if (playerLevel >= skill.requiredLevel && (!unlockedSkills.Contains(skill)) && ArePrerequisitesMet(skill) && skill.isMultipleTime)
            {
                if (skill.MaxLevel < skill.currentLevel)
                {
                    selectableSkills.Add(skill);
                }
            }
        }


        Shuffle(selectableSkills);


        for (int i = 0; i < Mathf.Min(count, selectableSkills.Count); i++)
        {
            SkillData selectedSkill = selectableSkills[i];
            GameObject skillCardInstance = Instantiate(skillCardPrefab, skillContainer);
            SkillCard skillCard = skillCardInstance.GetComponent<SkillCard>();
            skillCard.Initialize(selectedSkill, this);
            Debug.Log("Selectable Skill List :" + selectableSkills);
        }
    }
    private bool ArePrerequisitesMet(SkillData skill)
    {
        foreach (SkillData prerequisite in skill.prerequisites)
        {
            if (!unlockedSkills.Contains(prerequisite) || prerequisite.currentLevel < skill.requiredSkillLevel)
            {
                Debug.Log("Prerequisite not met for skill: " + skill.skillName + ". Requires: " + prerequisite.skillName + " at level " + skill.requiredSkillLevel);
                return false;
            }
        }
        return true;
    }
    private void Shuffle(List<SkillData> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            SkillData temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void ApplySkill(SkillData SelectedSkill)
    {
        if (SelectedSkill.isOneTime && unlockedSkills.Contains(SelectedSkill))
        {
            Debug.LogError("Skill Already Unlocked: " + SelectedSkill.skillName);
            return;
        }

        if (!SelectedSkill.isOneTime || !unlockedSkills.Contains(SelectedSkill))
        {
            if (!unlockedSkills.Contains(SelectedSkill) && SelectedSkill.isOneTime)
            {
                unlockedSkills.Add(SelectedSkill);
            }
            if (SelectedSkill.BoolSkill == false)
            {
                StatsController.SkillController(SelectedSkill.skillName, SelectedSkill.FloatSkill + 1);
            }
            if (SelectedSkill.BoolSkill == true)
            {
                StatsController.SkillController(SelectedSkill.skillName, Bool: SelectedSkill.BoolSkill);
            }
            SelectedSkill.currentLevel++;

        }
    }

    public void CloseSkillPanel()
    {
        Time.timeScale = 1;
        SkillPanel.SetActive(false);
    }
}
