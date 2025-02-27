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
        RapidClass = (PlayerPrefs.GetInt("RapidClass") != 0);
        HomingClass = (PlayerPrefs.GetInt("HomingClass") != 0);

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
        SkillsController.SelectedWeapon = SkillsController.BaseWeapon.Heavy;
        SkillsController.WeaponSelected = true;
        AllSkills.SelectedWeapon(0);
    }
    public void RapidWeapon()
    {
        if (RapidClass)
        {
            Time.timeScale = 1;
            SkillsController.SkillPanel.SetActive(false);
            SkillsController.SelectedWeapon = SkillsController.BaseWeapon.Rapid;
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
            SkillsController.SelectedWeapon = SkillsController.BaseWeapon.Homing;
            SkillsController.WeaponSelected = true;
            AllSkills.SelectedWeapon(2);
        }
    }
}
