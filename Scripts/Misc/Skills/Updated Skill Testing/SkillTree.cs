using UnityEngine;
using System.Collections.Generic;
using static Skill;
/*
public class SkillTree : MonoBehaviour
{
    public List<SkillData> allSkills;
    public SkillsController SkillsController;
    public Skill Skill;
    void Start()
    {


        // upgradable skills
        SkillData damageBoost = new SkillData("Damage Boost", "Increases damage by a random percent");
        damageBoost.AddAttribute("damageBoost", Random.Range(0.1f, 0.5f));
        SkillData speedBoost = new SkillData("Speed Boost", "Increases movement speed by a random percent");
        speedBoost.AddAttribute("speedBoost", Random.Range(0.1f, 0.5f));
        SkillData ammoIncrease = new SkillData("Ammo Efficiency", "Increases ammo by a random percent");
        ammoIncrease.AddAttribute("ammoIncrease", Random.Range(0.1f, 0.5f));
        SkillData lifeSteal = new SkillData("Life Steal", "Gain a random percent of your damage as health per hit");
        lifeSteal.AddAttribute("lifeSteal", Random.Range(0.1f, 0.5f));
        SkillData healthIncrease = new SkillData("Health Increase", "Increases maximum health by a random percent");
        healthIncrease.AddAttribute("healthIncrease", Random.Range(0.1f, 0.5f));
        SkillData AttackSpeed = new SkillData("Attack Speed", "Increases attack speed for all weapons by a random percent");
        AttackSpeed.AddAttribute("AttackSpeed", Random.Range(0.1f, 0.5f));
        SkillData ExpBuff = new SkillData("Exp Buff", "increases the amount of exp gained by 5 per kill");
        ExpBuff.AddAttribute("ExpBuff", 5f);
        SkillData ExtraLife = new SkillData("Extra Life", "Gives you another life");
        ExtraLife.AddAttribute("ExtraLife", 1f);
        SkillData BulletSpeed = new SkillData("Increased Bullet Speed", "increases all bullet speed by a random percent");
        BulletSpeed.AddAttribute("BulletSpeed", Random.Range(0.1f, 0.5f));

        // one time skills
        SkillData DoubleShot = new SkillData("Double Shot", "Allows you to shoot two Missile at once", isOneTime: true);
        SkillData BackwardFire = new SkillData("Backward Fire", "Shots another bullet behind you", isOneTime: true);
        SkillData poisonDamage = new SkillData("Poison Shot", "Shoots poison projectiles that deal extra damage over 5 seconds", isOneTime: true);

        // weapons

        if (SkillsController.SelectedWeapon == SkillsController.BaseWeapon.Heavy)
        {
            // heavy weapons
            SkillData NukeWeapon = new SkillData("Nuke Weapon", "Gain a Nuke as An extra weapon", isOneTime: true);
            SkillData FlakWeapon = new SkillData("Flak Cannon Weapon", "Gain a Flak Cannon as an extra weapon", isOneTime: true);
            SkillsController.playerMissileWeapon = true;
            Skill.mainWeapon = WeaponCode.Missile;

            NukeWeapon.prerequisites.Add(damageBoost);
            NukeWeapon.requiredSkillLevel = 2;
            NukeWeapon.requiredLevel = 10;
            FlakWeapon.requiredLevel = 15;


            allSkills.Add(NukeWeapon);
            allSkills.Add(FlakWeapon);
        }


        if (SkillsController.SelectedWeapon == SkillsController.BaseWeapon.Rapid)
        {

            // rapid fire skills
            SkillData BurstAmount = new SkillData("increased burst amount", "increases minigun burst amount by 5");
            BurstAmount.AddAttribute("BurstAmount", 5f);
            SkillData BurstDelay = new SkillData("decreased burst delay", "Decreases the burst delay by 10%");
            BurstDelay.AddAttribute("BurstDelay", 0.1f);
            SkillData RapidFire = new SkillData("Rapid fire", "swaps out the burst for rapid fire (minigun only)", isOneTime: true);

            // rapid fire weapons
            // SkillData MiniGunWeapon = new SkillData("MiniGun Weapon", "Gain a MiniGun as An extra weapon", MiniGunWeapon: true, isOneTime: true); Is Base Weapon
            SkillsController.playerMiniGunWeapon = true;
            Skill.mainWeapon = WeaponCode.MiniGun;

            // BurstAmount.prerequisites.Add(MiniGunWeapon);
            BurstAmount.requiredLevel = 10;
            // BurstDelay.prerequisites.Add(MiniGunWeapon);
            BurstDelay.requiredLevel = 10;
            RapidFire.prerequisites.Add(BurstDelay);
            RapidFire.requiredSkillLevel = 3;
            // MiniGunWeapon.prerequisites.Add(AttackSpeed);
            // MiniGunWeapon.requiredSkillLevel = 3;
            // MiniGunWeapon.requiredLevel = 10;
            RapidFire.requiredSkillLevel = 3;
            RapidFire.requiredLevel = 15;


            // allSkills.Add(MiniGunWeapon);
            allSkills.Add(RapidFire);
            allSkills.Add(BurstDelay);
            allSkills.Add(BurstAmount);
        }


        if (SkillsController.SelectedWeapon == SkillsController.BaseWeapon.Homing)
        {


            // homing weapons
            // SkillData DroneWeapon = new SkillData("Drone Weapon", "Gain seeker Drones as an extra weapon", DroneWeapon: true, isOneTime: true); Is Base Weapon
            SkillData HomingMissileWeapon = new SkillData("Homing Missile Weapon", "Gain a Homing Missile as an extra weapon", isOneTime: true);

            SkillsController.playerDroneWeapon = true;
            Skill.mainWeapon = WeaponCode.Drone;

            HomingMissileWeapon.prerequisites.Add(DoubleShot);
            HomingMissileWeapon.requiredLevel = 10;
            // DroneWeapon.requiredLevel = 10;


            allSkills.Add(HomingMissileWeapon);
            // allSkills.Add(DroneWeapon);
        }

        DoubleShot.requiredLevel = 10;
        poisonDamage.requiredLevel = 5;
        lifeSteal.prerequisites.Add(healthIncrease);
        lifeSteal.requiredSkillLevel = 3;
        ExtraLife.requiredLevel = 5;
        BackwardFire.requiredLevel = 5;


        // Add the skills to the list
        allSkills.Add(damageBoost);
        allSkills.Add(speedBoost);
        allSkills.Add(ammoIncrease);
        allSkills.Add(DoubleShot);
        allSkills.Add(BackwardFire);
        allSkills.Add(poisonDamage);
        allSkills.Add(lifeSteal);
        allSkills.Add(healthIncrease);
        allSkills.Add(AttackSpeed);
        allSkills.Add(ExtraLife);
        allSkills.Add(ExpBuff);
        allSkills.Add(BulletSpeed);



    }

    public float GetdamageBoost()
    {
        foreach (SkillData skill in allSkills)
        {
            if (skill.SkillName == "damageBoost")
            {
                return skill.attributes["damageBoost"];
            }
        }

        return 0f;
    }
}
*/