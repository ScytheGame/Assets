using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class SkillTreeData
{
    private static string FilePath = Path.Combine(Application.persistentDataPath, "SkillTreeData.json");



    public bool DoubleShot, BackwardsFire, MultiShot;

    public float SpeedBoost = 1, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost = 0.2f, SkillChanceBias = 0.55f;
    public float DamageBoost = 1;
    public float AttackSpeed = 1;
    public float ProjectileSpeed = 1;

    public SkillTreeData()
    {

    }

    public void Apply(BaseSkillType SkillType, float Value)
    {

        switch (SkillType)
        {
            case BaseSkillType.None:
                break;

            case BaseSkillType.Damage:
                DamageBoost += Value; break;
            
            case BaseSkillType.Speed:
                SpeedBoost += Value; break;

            case BaseSkillType.AmmoCapacity:
                AmmoBoost += Value; break;
            
            case BaseSkillType.Health:
                HealthBoost += Value; break;
            
            case BaseSkillType.AttackSpeed:
                AttackSpeed += Value; break;
            
            case BaseSkillType.Experience:
                ExperienceBoost += Value; break;
            
            case BaseSkillType.ProjectileSpeed:
                ProjectileSpeed += Value; break;
            
            case BaseSkillType.DoubleShot:
                DoubleShot = true; break;
            
            case BaseSkillType.BackwardsFire:
                BackwardsFire = true; break;
            
            case BaseSkillType.MultiShot:
                MultiShot = true; break;

            case BaseSkillType.SkillValueBoost:
                SkillValueBoost += Value; break;
            
            case BaseSkillType.SkillChanceBias:
                SkillChanceBias += Value; break;
            
        }


        SkillTreeData.Save(this);
    }

    public static void Save(SkillTreeData Data)
    {
        string Json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(FilePath, Json);
    }

    public static SkillTreeData Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonUtility.FromJson<SkillTreeData>(json);
        }
        return new SkillTreeData();
    }
}

[System.Serializable]
public class SkillTreeSkillData
{
    private static string SkillFilePath = Path.Combine(Application.persistentDataPath, "SkillTreeSkillData.json");

    public List<SkillEntry> skills = new List<SkillEntry>();

    public void Save(string GameObjectName, string SkillID, float SkillValue, bool IsOwned, float UpgradeLevel)
    {
        string SkillKey = GameObjectName + "_ID_" + SkillID + "_Value_" + SkillValue;

        SkillEntry existingSkill = skills.Find(s => s.SkillKey == SkillKey);
        if (existingSkill != null)
        {
            existingSkill.IsOwned = IsOwned;
            existingSkill.UpgradeLevel = UpgradeLevel;
        }
        else
        {
            // Add new skill
            skills.Add(new SkillEntry(SkillKey, SkillValue, IsOwned, UpgradeLevel));
        }

        SaveSkill(this);
    }
    public SkillEntry Load(string GameObjectName, string SkillID, float SkillValue)
    {
        string skillKey = GameObjectName + "_ID_" + SkillID + "_Value_" + SkillValue;
        return skills.Find(s => s.SkillKey == skillKey);
    }
    public static void SaveSkill(SkillTreeSkillData Data)
    {
        string Json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(SkillFilePath, Json);
    }
    public static SkillTreeSkillData LoadSkill()
    {
        if (File.Exists(SkillFilePath))
        {
            string json = File.ReadAllText(SkillFilePath);
            return JsonUtility.FromJson<SkillTreeSkillData>(json);
        }
        return new SkillTreeSkillData();
    }
}

[System.Serializable]
public class SkillEntry
{
    public string SkillKey;
    public float SkillValue;
    public bool IsOwned;
    public float UpgradeLevel;

    public SkillEntry(string SkillKey, float SkillValue, bool IsOwned, float UpgradeLevel)
    {
        this.SkillKey = SkillKey;
        this.SkillValue = SkillValue;
        this.IsOwned = IsOwned;
        this.UpgradeLevel = UpgradeLevel;
    }
}
