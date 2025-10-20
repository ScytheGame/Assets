using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SkillTreeDataGenerator : SerializedMonoBehaviour
{

    [OdinSerialize, DictionaryDrawerSettings(KeyLabel = "Skill Icon Name", ValueLabel = "Skill Icon")] public Dictionary<string, Sprite> SkillIcons = new Dictionary<string, Sprite>();

    void Start()
    {
        Weapon[] WeaponList = Resources.LoadAll<Weapon>("Scriptable Objects/Weapons");
        for (int i = 0; i < WeaponList.Length; i++)
        {
            string Name = WeaponList[i].WeaponName;
            string Class = WeaponList[i].Class.ToString();
            string FolderPath = "Assets/Resources/Scriptable Objects/Skill Tree";

            if (AssetDatabase.IsValidFolder(FolderPath + "/" + Class + "/Weapons/" + Name))
                Debug.Log(Name + " folder already exists. Skipping creation.");
            else
            {

                if (!AssetDatabase.IsValidFolder(FolderPath + "/" + Class))
                    AssetDatabase.CreateFolder((FolderPath), (Class));
                if (!AssetDatabase.IsValidFolder(FolderPath + "/" + Class + "/Weapons/"))
                    AssetDatabase.CreateFolder((FolderPath + "/" + Class), ("Weapons"));
                AssetDatabase.CreateFolder((FolderPath + "/" + Class + "/Weapons"), Name);

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                CreateWeapons(WeaponList, i);
                CreateSkills(WeaponList, i);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    void CreateWeapons(Weapon[] WeaponList, int i)
    {
        string Name = WeaponList[i].WeaponName;
        string Class = WeaponList[i].Class.ToString();
        string FolderPath = "Assets/Resources/Scriptable Objects/Skill Tree/" + Class + "/Weapons/";

        SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
        NewSkill.SkillNameText = WeaponList[i].WeaponName;
        NewSkill.SkillDescriptionText = $"Unlocks the {WeaponList[i].WeaponName}";
        NewSkill.SkillIcon = SkillIcons.ContainsKey(Name) ? SkillIcons[Name] : null;
        NewSkill.BaseSkillType = BaseSkillType.AttackSpeed;
        NewSkill.CelestialCost = 25;
        NewSkill.SolarCost = 1;
        NewSkill.CelestialCostIncreasePerLevel = 0;
        NewSkill.SolarCostIncreasePerLevel = 0;
        NewSkill.MaxUpgradeLevel = 1;
        NewSkill.SkillValue = 1;
        NewSkill.Weapon = WeaponList[i];

        string assetPath = $"{FolderPath}{NewSkill.SkillNameText}.asset";
        if (!File.Exists(assetPath))
        {
            AssetDatabase.CreateAsset(NewSkill, assetPath);
            Debug.Log($"Created {assetPath}");
        }
        
    }
    void CreateSkills(Weapon[] WeaponList, int i)
    {
        string Name = WeaponList[i].WeaponName;
        string Class = WeaponList[i].Class.ToString();
        string FolderPath = "Assets/Resources/Scriptable Objects/Skill Tree/" + Class + "/Weapons/" + Name;

        //AssetDatabase.CreateFolder("Assets/Resources/Scriptable Objects/Skill Tree/" + Class + "/Weapons", Name);
        //Debug.Log("Created folder: " + Name);

        for (int j = 1; j <= 4; j++) // Attack Speed
        {
            string Skill = "Attack Speed";
            string SV = $"{j * 5}%";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Increases the " + Skill + " for " + Name + " By " + SV;
            NewSkill.BaseSkillType = BaseSkillType.AttackSpeed;
            NewSkill.CelestialCost = 10;
            NewSkill.SolarCost = 0;
            NewSkill.CelestialCostIncreasePerLevel = 5;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 5;
            NewSkill.SkillValue = (0.05f * j);
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText + SV}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }

        }


        for (int j = 1; j <= 4; j++) // Damage
        {
            string Skill = "Damage Boost";
            string SV = $"{j * 5}%";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Increases the " + Skill + " for " + Name + " By " + SV;
            NewSkill.BaseSkillType = BaseSkillType.Damage;
            NewSkill.CelestialCost = 10;
            NewSkill.SolarCost = 0;
            NewSkill.CelestialCostIncreasePerLevel = 5;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 5;
            NewSkill.SkillValue = (0.05f * j);
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText + SV}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }


        }


        for (int j = 1; j <= 4; j++) // Porjectile Speed
        {
            string Skill = "Projectile Speed";
            string SV = $"{j * 5}%";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Increases the " + Skill + " for " + Name + " By " + SV;
            NewSkill.BaseSkillType = BaseSkillType.ProjectileSpeed;
            NewSkill.CelestialCost = 10;
            NewSkill.SolarCost = 0;
            NewSkill.CelestialCostIncreasePerLevel = 5;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 5;
            NewSkill.SkillValue = (0.05f * j);
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText + (j*5)}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }

        }

        // Bool: Multishot
        {
            string Skill = "Multi Shot";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Unlocks the " + Skill + " for " + Name;
            NewSkill.BaseSkillType = BaseSkillType.MultiShot;
            NewSkill.CelestialCost = 50;
            NewSkill.SolarCost = 2;
            NewSkill.CelestialCostIncreasePerLevel = 0;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 1;
            NewSkill.SkillValue = 1;
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }

        }

        // Bool: Backwards Fire
        {
            string Skill = "Backwards Fire";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Unlocks the " + Skill + " for " + Name;
            NewSkill.BaseSkillType = BaseSkillType.BackwardsFire;
            NewSkill.CelestialCost = 50;
            NewSkill.SolarCost = 2;
            NewSkill.CelestialCostIncreasePerLevel = 0;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 1;
            NewSkill.SkillValue = 1;
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }
        }

        // Bool: Doubleshot
        {
            string Skill = "Double Shot";
            SkillTree NewSkill = ScriptableObject.CreateInstance<SkillTree>();
            NewSkill.SkillNameText = WeaponList[i].WeaponName + " " + Skill;
            NewSkill.SkillDescriptionText = "Unlocks the " + Skill + " for " + Name;
            NewSkill.BaseSkillType = BaseSkillType.DoubleShot;
            NewSkill.CelestialCost = 50;
            NewSkill.SolarCost = 2;
            NewSkill.CelestialCostIncreasePerLevel = 0;
            NewSkill.SolarCostIncreasePerLevel = 0;
            NewSkill.MaxUpgradeLevel = 1;
            NewSkill.SkillValue = 1;
            NewSkill.Weapon = WeaponList[i];

            string assetPath = $"{FolderPath}/{NewSkill.SkillNameText}.asset";
            if (!File.Exists(assetPath))
            {
                AssetDatabase.CreateAsset(NewSkill, assetPath);
                Debug.Log($"Created {assetPath}");
            }
        }

        
    }
}
