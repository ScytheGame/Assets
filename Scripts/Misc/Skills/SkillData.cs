using UnityEngine;
using System.Collections.Generic;
public class SkillData
{
    public StatsController StatsController;
    public string skillName;
    public string skillDescription;
    public string skillDebuffDescription;
    public string skillBuff1;
    public string skillDebuff1;

    // Skill Type
    public float FloatSkill;
    public bool BoolSkill;

    public List<SkillData> prerequisites;

    public int currentLevel;
    public int requiredSkillLevel;
    public int requiredLevel;
    public bool isOneTime;
    public bool isMultipleTime;
    public float MaxLevel;

    public SkillData(string name,
        string description,
        string Buff = null,
        float Float = 0,
        bool Bool = false,
        bool isMultipleTime = false,
        float MaxLevel = 0,
        int requiredSkillLevel = 0,
        int requiredLevel = 0
        )
    {
        skillName = name;
        skillDescription = description;
        skillBuff1 = Buff;
        this.FloatSkill = Float;
        this.BoolSkill = Bool;
        this.prerequisites = new List<SkillData>();
        this.isOneTime = Bool;
        this.isMultipleTime = isMultipleTime;
        this.currentLevel = 0;
        this.MaxLevel = MaxLevel;
        this.requiredSkillLevel = requiredSkillLevel;
        this.requiredLevel = requiredLevel;
    }

    public void SkillUpdate(string skillName, float SkillValue)
    {
        FloatSkill = SkillValue;
        skillBuff1 = "" + skillName + " : " + SkillValue * 100 + "%";
    }
}