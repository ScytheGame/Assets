using System.IO;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillDataWeaponGenerator : MonoBehaviour
{
    void Start()
    {
        Weapon[] WeaponList = Resources.LoadAll<Weapon>("Scriptable Objects/Weapons");
        for (int i = 0; i < WeaponList.Length; i++)
        {
            string Name = WeaponList[i].WeaponName;
            string FolderPath = "Assets/Resources/Scriptable Objects/Skills/" + Name;
            if (AssetDatabase.IsValidFolder(FolderPath))
            {
                Debug.Log(Name + " folder already exists. Skipping creation.");
            }
            else
            {
                AssetDatabase.CreateFolder("Assets/Resources/Scriptable Objects/Skills", Name);
                Debug.Log("Created folder: " + Name);

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                // Attack Speed
                {
                    string Skill = " Attack Speed";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Increases the" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = "%";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.AttackSpeed;
                    NewSkill.UseRandomValues = true;
                    NewSkill.IsMultipleTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }

                }

                // Damage
                {
                    string Skill = " Damage Boost";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Increases the" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = "%";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.Damage;
                    NewSkill.UseRandomValues = true;
                    NewSkill.IsMultipleTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }

                }

                // Porjectile Speed
                {
                    string Skill = " Porjectile Speed";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Increases the" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = "%";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.ProjectileSpeed;
                    NewSkill.UseRandomValues = true;
                    NewSkill.IsMultipleTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }
                }

                // Bool: Multishot
                {
                    string Skill = " Multi Shot";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Unlock" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = " ";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.MultiShot;
                    NewSkill.SkillMaxLevel = 1;
                    NewSkill.RequiredPlayerLevel = 10;
                    NewSkill.IsOneTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }
                }

                // Bool: Backwards Fire
                {
                    string Skill = " Backwards Fire";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Unlock" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = " ";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.BackwardsFire;
                    NewSkill.SkillMaxLevel = 1;
                    NewSkill.RequiredPlayerLevel = 5;
                    NewSkill.IsOneTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }
                }

                // Bool: Doubleshot
                {
                    string Skill = " Double Shot";
                    SkillData NewSkill = ScriptableObject.CreateInstance<SkillData>();
                    NewSkill.SkillName = WeaponList[i].WeaponName + Skill;
                    NewSkill.InspectorSkillDescription = "Unlock" + Skill + " for " + Name;
                    NewSkill.DescriptionSymbol = " ";
                    NewSkill.SkillBuff = Name + Skill;
                    NewSkill.SkillType = BaseSkillType.DoubleShot;
                    NewSkill.SkillMaxLevel = 1;
                    NewSkill.RequiredPlayerLevel = 15;
                    NewSkill.IsOneTime = true;
                    NewSkill.Weapon = WeaponList[i];
                    NewSkill.Class = WeaponList[i].Class;

                    string assetPath = $"{FolderPath}/{NewSkill.SkillName}.asset";
                    if (!File.Exists(assetPath))
                    {
                        AssetDatabase.CreateAsset(NewSkill, assetPath);
                        Debug.Log($"Created {assetPath}");
                    }
                }

            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
