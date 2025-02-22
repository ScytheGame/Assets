using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] SkillsController SkillsController;
    [SerializeField] AllSkills AllSkills;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");

        if (Player != null )
        {
            SkillsController = Player.GetComponent<SkillsController>();
            AllSkills = Player.GetComponent<AllSkills>();
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
        Time.timeScale = 1;
        SkillsController.SkillPanel.SetActive(false);
        SkillsController.SelectedWeapon = SkillsController.BaseWeapon.Rapid;
        SkillsController.WeaponSelected = true;
        AllSkills.SelectedWeapon(1);
    }
    public void HomingWeapon()
    {
        Time.timeScale = 1;
        SkillsController.SkillPanel.SetActive(false);
        SkillsController.SelectedWeapon = SkillsController.BaseWeapon.Homing;
        SkillsController.WeaponSelected = true;
        AllSkills.SelectedWeapon(2);
    }
}
