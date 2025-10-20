using UnityEngine;
using System.IO;
using System.Collections.Generic;
using JetBrains.Annotations;
public class SkillTreeData
{
    private static string FilePath = Path.Combine(Application.persistentDataPath, "SkillTreeData.json");

    public Dictionary<string, Weapon> WeaponList;
    public Dictionary<string, SkillWeaponData> SkillWeaponDataList;

    public float SpeedBoost = 1, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost = 0.2f, SkillChanceBias = 0.55f;

    public SkillTreeData()
    {

    }

    public void Apply(BaseSkillType SkillType, float Value, string WeaponName, Weapon Weapon)
    {
        Load();

        if (WeaponList == null)
            WeaponList = new Dictionary<string, Weapon>();

        if (SkillWeaponDataList == null)
            SkillWeaponDataList = new Dictionary<string, SkillWeaponData>();
        
        switch (SkillType)
        {
            case BaseSkillType.None:
                break;

            case BaseSkillType.Weapon:
                {
                    WeaponList.Add(WeaponName, Weapon);
                    var WeaponStuff = new SkillWeaponData();
                    SkillWeaponDataList.Add(WeaponName, WeaponStuff);
                }
                break;

            case BaseSkillType.Damage:
                SkillWeaponDataList[WeaponName].DamageBoost += Value;
                break;
            
            case BaseSkillType.Speed:
                SpeedBoost += Value; 
                break;

            case BaseSkillType.AmmoCapacity:
                AmmoBoost += Value; 
                break;
            
            case BaseSkillType.Health:
                HealthBoost += Value; 
                break;
            
            case BaseSkillType.AttackSpeed:
                SkillWeaponDataList[WeaponName].AttackSpeed += Value;
                break;
            
            case BaseSkillType.Experience:
                ExperienceBoost += Value; 
                break;
            
            case BaseSkillType.ProjectileSpeed:
                SkillWeaponDataList[WeaponName].ProjectileSpeed += Value;
                break;
            
            case BaseSkillType.DoubleShot:
                SkillWeaponDataList[WeaponName].DoubleShot = true;
                break;
            
            case BaseSkillType.BackwardsFire:
                SkillWeaponDataList[WeaponName].BackwardsFire = true;
                break;
            
            case BaseSkillType.MultiShot:
                SkillWeaponDataList[WeaponName].MultiShot = true;
                break;

            case BaseSkillType.SkillValueBoost:
                SkillValueBoost += Value; 
                break;
            
            case BaseSkillType.SkillChanceBias:
                SkillChanceBias += Value; 
                break;
            
        }


        SkillTreeData.Save(this);
    }

    public static void Save(SkillTreeData Data)
    {
        SerializableDictionary<string, Weapon> SerializebleWeaponList = new SerializableDictionary<string, Weapon>(Data.WeaponList);
        SerializableDictionary<string, SkillWeaponData> SerializebleSkillWeaponDataList = new SerializableDictionary<string, SkillWeaponData>(Data.SkillWeaponDataList);

        string Json = JsonUtility.ToJson(new SkillTreeDataWrapper(Data, SerializebleWeaponList, SerializebleSkillWeaponDataList), true);
        File.WriteAllText(FilePath, Json);
    }

    public static SkillTreeData Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            SkillTreeDataWrapper WeaponListWrapper = JsonUtility.FromJson<SkillTreeDataWrapper>(json);

            SkillTreeData data = WeaponListWrapper.ToSkillTreeData();
            return data;
        }
        return new SkillTreeData();
    }
}
[System.Serializable]
public class SkillTreeDataWrapper
{
    public SerializableDictionary<string, Weapon> WeaponList;
    public SerializableDictionary<string, SkillWeaponData> SkillWeaponData;

    public float SpeedBoost, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost, SkillChanceBias;

    public SkillTreeDataWrapper(SkillTreeData data, SerializableDictionary<string, Weapon> SerializableWeaponList, SerializableDictionary<string, SkillWeaponData> SerializableSkillWeaponDataList )
    {
        WeaponList = SerializableWeaponList;
        SkillWeaponData = SerializableSkillWeaponDataList;

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
            WeaponList = WeaponList.ToDictionary(),
            SkillWeaponDataList = SkillWeaponData.ToDictionary(),
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
