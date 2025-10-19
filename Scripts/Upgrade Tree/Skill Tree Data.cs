using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class SkillTreeData
{
    private static string FilePath = Path.Combine(Application.persistentDataPath, "SkillTreeData.json");

    public Dictionary<string, Weapon> WeaponList = new Dictionary<string, Weapon>();
    public Dictionary<string, SkillClassData> ClassList = new Dictionary<string, SkillClassData>();
    public Dictionary<string, SkillWeaponData> WeaponSkillList = new Dictionary<string, SkillWeaponData>();

    public float SpeedBoost = 1, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost = 0.2f, SkillChanceBias = 0.55f;

    public SkillTreeData()
    {

    }

    public void Apply(BaseSkillType SkillType, float Value, Weapon Weapon)
    {

        switch (SkillType)
        {
            case BaseSkillType.None:
                break;

            case BaseSkillType.Weapon:
                WeaponList.Add(Weapon.WeaponName, Weapon);
                break;

            case BaseSkillType.Damage:
                WeaponSkillList[Weapon.WeaponName].DamageBoost += Value; break;
            
            case BaseSkillType.Speed:
                SpeedBoost += Value; break;

            case BaseSkillType.AmmoCapacity:
                AmmoBoost += Value; break;
            
            case BaseSkillType.Health:
                HealthBoost += Value; break;
            
            case BaseSkillType.AttackSpeed:
                WeaponSkillList[Weapon.WeaponName].AttackSpeed += Value; break;
            
            case BaseSkillType.Experience:
                ExperienceBoost += Value; break;
            
            case BaseSkillType.ProjectileSpeed:
                WeaponSkillList[Weapon.WeaponName].ProjectileSpeed += Value; break;
            
            case BaseSkillType.DoubleShot:
                WeaponSkillList[Weapon.WeaponName].DoubleShot = true; break;
            
            case BaseSkillType.BackwardsFire:
                WeaponSkillList[Weapon.WeaponName].BackwardsFire = true; break;
            
            case BaseSkillType.MultiShot:
                WeaponSkillList[Weapon.WeaponName].MultiShot = true; break;

            case BaseSkillType.SkillValueBoost:
                SkillValueBoost += Value; break;
            
            case BaseSkillType.SkillChanceBias:
                SkillChanceBias += Value; break;
            
        }


        SkillTreeData.Save(this);
    }

    public static void Save(SkillTreeData Data)
    {
        SerializableDictionary<string, SkillWeaponData> SerializableWeaponSkillList = new SerializableDictionary<string, SkillWeaponData>(Data.WeaponSkillList);

        string Json = JsonUtility.ToJson(new SkillTreeDataWrapper(Data, SerializableWeaponSkillList), true);
        File.WriteAllText(FilePath, Json);
    }

    public static SkillTreeData Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            SkillTreeDataWrapper wrapper = JsonUtility.FromJson<SkillTreeDataWrapper>(json);

            SkillTreeData data = wrapper.ToSkillTreeData();
            return data;
        }
        return new SkillTreeData();
    }
}
[System.Serializable]
public class SkillTreeDataWrapper
{
    public Dictionary<string, Weapon> WeaponList;
    public Dictionary<string, SkillClassData> ClassList;
    public SerializableDictionary<string, SkillWeaponData> WeaponSkillList;

    public float SpeedBoost, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost, SkillChanceBias;

    public SkillTreeDataWrapper(SkillTreeData data, SerializableDictionary<string, SkillWeaponData> serializableWeaponSkillList)
    {
        WeaponList = data.WeaponList;
        ClassList = data.ClassList;
        WeaponSkillList = serializableWeaponSkillList;

        SpeedBoost = data.SpeedBoost;
        HealthBoost = data.HealthBoost;
        AmmoBoost = data.AmmoBoost;
        ExperienceBoost = data.ExperienceBoost;
        SkillValueBoost = data.SkillValueBoost;
        SkillChanceBias = data.SkillChanceBias;
    }

    public SkillTreeData ToSkillTreeData()
    {
        SkillTreeData data = new SkillTreeData
        {
            WeaponList = WeaponList,
            ClassList = ClassList,
            WeaponSkillList = WeaponSkillList.ToDictionary(),
            SpeedBoost = SpeedBoost,
            HealthBoost = HealthBoost,
            AmmoBoost = AmmoBoost,
            ExperienceBoost = ExperienceBoost,
            SkillValueBoost = SkillValueBoost,
            SkillChanceBias = SkillChanceBias
        };
        return data;
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
