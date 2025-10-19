using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SkillTree", menuName = "Scriptable Objects/SkillTree")]
public class SkillTree : ScriptableObject
{
    [SerializeField, BoxGroup("Base")] public string SkillNameText;
    [SerializeField, BoxGroup("Base")] public string skillDescriptionText;
    [SerializeField, BoxGroup("base")] public Sprite SkillIcon;
    [SerializeField, BoxGroup("Base")] public string CelestialCostText;
    [SerializeField, BoxGroup("Base")] public string SolarCostText;
    [SerializeField, BoxGroup("Base")] public string UpgradeLevelText;

    [SerializeField] public BaseSkillType BaseSkillType;
    [ShowIf("BaseSkillTypeIsWeapon")] public Weapon Weapon; 

    [SerializeField, BoxGroup("Skill Cost")] public float CelestialCost;
    [SerializeField, BoxGroup("Skill Cost")] public float SolarCost;

    [SerializeField, BoxGroup("Skill Cost")] public float CelestialCostIncreasePerLevel;
    [SerializeField, BoxGroup("Skill Cost")] public float SolarCostIncreasePerLevel;

    [SerializeField, BoxGroup("Skill Value")] public float UpgradeLevel;
    [SerializeField, BoxGroup("Skill Value")] public float MaxUpgradeLevel;
    [SerializeField, BoxGroup("Skill Value")] public float SkillValue;

    public bool BaseSkillTypeIsWeapon()
    {
        return BaseSkillType == BaseSkillType.Weapon;
    }
}
