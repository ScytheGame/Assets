
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillsController : MonoBehaviour
{
    [Space(10)]
    [Header("Skill Panel")]
    [SerializeField] public GameObject SkillPanel;
    [SerializeField] Transform SkillContainer;
    [SerializeField] GameObject SkillCardPrefab;
    [SerializeField] StatsController StatsController;

    [Space(10)]
    [Header("Skills List")]
    public List<SkillData> SkillsList = new List<SkillData>();
    private List<Button> SkillButtons;

    [Space(10)]
    [Header("Skills Controller")]
    [SerializeField] AllSkills AllSkills;
    public float PlayerLevel;

    [TableList] public List<SkillData> UnlockedSkills = new List<SkillData>();


    private void Start()
    {
        SkillPanel.SetActive(false);

        SkillButtons = new List<Button>();
        
    }

    public void AddSkills(List<SkillData> skills)
    {
        SkillsList.Clear();
        SkillsList = skills;
        Debug.Log("Number of skills: " + SkillsList.Count);
        foreach (SkillData skillData in SkillsList)
        {
            Debug.Log("Skill Name: " + skillData.SkillName);
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
        Debug.Log("skillContainer: " + SkillContainer);
        Debug.Log("skillCardPrefab: " + SkillCardPrefab);
        Debug.Log("skillButtons: " + SkillButtons.Count);
        foreach (SkillData SkillData in SkillsList)
        {
            Debug.Log("Skill Name" + SkillData.SkillName);
        }

        foreach (Transform Child in SkillContainer)
        {
            Destroy(Child.gameObject);
        }


        int Count = 3;


        List<SkillData> SelectableSkills = new List<SkillData>();


        foreach (SkillData Skill in SkillsList)
        {
            Debug.Log("Skill Name: " + Skill.SkillName);
            Debug.Log("player level " + PlayerLevel + " : " + Skill.RequiredPlayerLevel);
            Debug.Log("is unlocked skill " + UnlockedSkills.Contains(Skill));
            Debug.Log("is not skill one time " + !Skill.IsOneTime);
            Debug.Log("are prerequisites met " + ArePrerequisitesMet(Skill));
            Debug.Log("is skill not multiple time " + !Skill.IsMultipleTime);
            if (Skill.IsMultipleTime)
            {
                Debug.Log("skill Current level " + Skill.SkillCurrentLevel + " : " + Skill.SkillMaxLevel);
            }
            if (PlayerLevel >= Skill.RequiredPlayerLevel && (!UnlockedSkills.Contains(Skill)) && ArePrerequisitesMet(Skill) && !Skill.IsMultipleTime)
            {
                SelectableSkills.Add(Skill);
            }
            else if (PlayerLevel >= Skill.RequiredPlayerLevel && (!UnlockedSkills.Contains(Skill)) && ArePrerequisitesMet(Skill) && Skill.IsMultipleTime)
            {
                if (Skill.SkillCurrentLevel < Skill.SkillMaxLevel || Skill.SkillMaxLevel == 0)
                {
                    SelectableSkills.Add(Skill);
                }
            }
        }


        Shuffle(SelectableSkills);


        for (int i = 0; i < Mathf.Min(Count, SelectableSkills.Count); i++)
        {
            SkillData selectedSkill = SelectableSkills[i];
            GameObject skillCardInstance = Instantiate(SkillCardPrefab, SkillContainer);
            SkillCard skillCard = skillCardInstance.GetComponent<SkillCard>();
            skillCard.Initialize(selectedSkill, this);
            Debug.Log("Selectable Skill List :" + SelectableSkills);
        }
    }
    private bool ArePrerequisitesMet(SkillData skill)
    {
        foreach (PrerequisiteSkillData SkillPrerequisite in skill.Prerequisites)
        {
            if (!UnlockedSkills.Contains(SkillPrerequisite.PrerequisiteSkill) || SkillPrerequisite.PrerequisiteSkill.SkillCurrentLevel <  SkillPrerequisite.RequiredSkillLevel)
            {
                Debug.Log("Prerequisite not met for skill: " + skill.SkillName + ". Requires: " + SkillPrerequisite.PrerequisiteSkill.SkillName + " at level " + SkillPrerequisite.RequiredSkillLevel);
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
        if (SelectedSkill.IsOneTime && UnlockedSkills.Contains(SelectedSkill))
        {
            Debug.LogError("Skill Already Unlocked: " + SelectedSkill.SkillName);
            return;
        }

        if (!SelectedSkill.IsOneTime || !UnlockedSkills.Contains(SelectedSkill))
        {
            if (!UnlockedSkills.Contains(SelectedSkill) && SelectedSkill.IsOneTime)
            {
                UnlockedSkills.Add(SelectedSkill);
            }

            if (!SelectedSkill.IsOneTime)
            {
                StatsController.SkillController(SelectedSkill.SkillType, SelectedSkill.Weapon, SelectedSkill.SkillValue + 1);
            }

            if (SelectedSkill.IsOneTime)
            {
                StatsController.SkillController(SelectedSkill.SkillType, SelectedSkill.Weapon, Bool: true);

                if (SelectedSkill.IncrementalValue)
                    SelectedSkill.SkillValueUpdate();
            }
            SelectedSkill.SkillCurrentLevel++;

        }
    }

    public void CloseSkillPanel()
    {
        Time.timeScale = 1;
        SkillPanel.SetActive(false);
    }
}
