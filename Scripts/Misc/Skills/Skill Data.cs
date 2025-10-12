using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    [SerializeField, BoxGroup("Base")] public string SkillName;
    [SerializeField, BoxGroup("Base")] public string InspectorSkillDescription;
    [HideInInspector] public string SkillDescription;

    [SerializeField, BoxGroup("Base")] public string DescriptionSymbol;
    [SerializeField, BoxGroup("Base")] public string SkillBuff;
    [SerializeField, BoxGroup("Base")] public BaseSkillType SkillType;

    [SerializeField, BoxGroup("Base")] public float SkillValue;

    [SerializeField, BoxGroup("Prerequisites")] public List<PrerequisiteSkillData> Prerequisites;


    [SerializeField, BoxGroup("Skill Level")] public int SkillCurrentLevel;
    [SerializeField, BoxGroup("Skill Level")] public int SkillMaxLevel;

    [SerializeField, BoxGroup("Skill Level")] public int RequiredPlayerLevel;

    [SerializeField, BoxGroup("Skill Booleans")] public bool IsOneTime;
    [SerializeField, BoxGroup("Skill Booleans")] public bool UseRandomValues;
    [SerializeField, BoxGroup("Skill Booleans")] public bool IsMultipleTime;

    [SerializeField, BoxGroup("Skill Value Increment")] public bool IncrementalValue;
    [SerializeField, BoxGroup("Skill Value Increment")] float SkillValueIncrement;

    [SerializeField, BoxGroup("Extras")] public Weapon Weapon;
    [SerializeField, BoxGroup("Extras")] public WeaponClass Class;
    public void SkillValueUpdate(float Value)
    {
        SkillValue = Value;

        if (Class != null && Weapon != null)
            SkillDescription = ($"{Weapon.WeaponName} {InspectorSkillDescription} By {Value}{DescriptionSymbol}");

        else
            SkillDescription = ($"{InspectorSkillDescription} By {Value}{DescriptionSymbol}");

    }

    public void SkillValueUpdate()
    {
        SkillValue += SkillValueIncrement;
        SkillDescription = ($"{InspectorSkillDescription} By {SkillValue}{DescriptionSymbol}");
    }
}
