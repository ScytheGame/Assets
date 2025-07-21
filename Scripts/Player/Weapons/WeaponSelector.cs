using System.IO;
using TMPro;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] SkillsController SkillsController;
    [SerializeField] AllSkills AllSkills;
    [SerializeField] string Class;
    [SerializeField] TextMeshProUGUI UnlockButton;
    bool RapidClass;
    bool HomingClass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");

        if (Player != null )
        {
            SkillsController = Player.GetComponent<SkillsController>();
            AllSkills = Player.GetComponent<AllSkills>();
        }
        CheckForClasses();

        if (Class.Equals("Rapid") && !RapidClass)
        {
            UnlockButton.text = ("Locked");
        }
        else if (Class.Equals("Homing") && !HomingClass)
        {
            UnlockButton.text = ("Locked");
        }
        else
        {
            UnlockButton.text = ("Select");
        }
    }

    public void HeavyWeapon()
    {
        Time.timeScale = 1;
        SkillsController.SkillPanel.SetActive(false);
        SkillsController.SelectedWeapon = BaseWeapon.Heavy;
        SkillsController.WeaponSelected = true;
        AllSkills.SelectedWeapon(0);
    }
    public void RapidWeapon()
    {
        if (RapidClass)
        {
            Time.timeScale = 1;
            SkillsController.SkillPanel.SetActive(false);
            SkillsController.SelectedWeapon = BaseWeapon.Rapid;
            SkillsController.WeaponSelected = true;
            AllSkills.SelectedWeapon(1);
        }
    }
    public void HomingWeapon()
    {
        if (HomingClass)
        {
            Time.timeScale = 1;
            SkillsController.SkillPanel.SetActive(false);
            SkillsController.SelectedWeapon = BaseWeapon.Homing;
            SkillsController.WeaponSelected = true;
            AllSkills.SelectedWeapon(2);
        }
    }

    void CheckForClasses()
    {
        string FilePath = Path.Combine(Application.persistentDataPath, "SkillTreeData.json");
        var SkillTree = new SkillTreeData();
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            SkillTree = JsonUtility.FromJson<SkillTreeData>(json);
        }
        RapidClass = SkillTree.RapidClass;
        HomingClass = SkillTree.HomingClass;

    }
}
