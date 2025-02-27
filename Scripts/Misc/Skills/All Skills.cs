using UnityEngine;
using System.Collections.Generic;

public class AllSkills : MonoBehaviour
{
    [SerializeField] StatsController StatsController;
    [SerializeField] SkillsController SkillsController;
    [SerializeField] SkillData SkillData;
    [SerializeField] Skill Skill;
    [SerializeField] List<SkillData> Skills = new List<SkillData>();
    public List<SkillData> allSkills = new List<SkillData>();


    // Upgradeable Skills
    SkillData DamageBoost = new SkillData("Damage Boost", "Increases Damage", Float: 0.1f);
    SkillData SpeedBoost = new SkillData("Speed Boost", "Increase Movement Speed", Float: 0.1f);
    SkillData AmmoIncrease = new SkillData("Larger Ammo Capacity", " Increase Ammo Capacity", Float: 0.1f);
    SkillData LifeSteal = new SkillData("Life Steal", "Steal a Portion of your enemies health on hit", Float: 0.2f);
    SkillData HealthIncrease = new SkillData("Health Boost", "Increases maximum Health", Float: 0.1f);
    SkillData AttackSpeed = new SkillData("Attack Speed", "Increase All Weapon Attack", Float: 0.1f);
    SkillData XPBuff = new SkillData("XP Buff", "Increase The Maximum Amount of XP Gained Per Kill", "5", Float: 5);
    SkillData ExtraLife = new SkillData("Extra Life", "Gain An Extra Life", "1", Float: 1);
    SkillData ProjectileSpeed = new SkillData("Projectile Speed", "Increase All Weapon Proctile Speed", Float: 0.1f);
    SkillData Spread = new SkillData("Bullet Spread", "Reduces Bullet Spread", Float: 0.1f);

    // One time Skills
    SkillData DoubleShot = new SkillData("Double Shot", "Allows You To Shoot Two Bullets At Once, Reduces Damage By 40%", "Unlocks Double Shot", Bool: true);
    SkillData BackwardsFire = new SkillData("Backwards Fire", "Shoot An Extra Bullet Behind You, Reduces Damage By 20%", "Unlocks Backwards Fire", Bool: true);
    SkillData MultiShot = new SkillData("Multishot", "Each Shot Is Followed Up By Another Shot, Reduces Damage By 40%", "Unlocks Multishot", Bool: true);

    // Heavy Weapons
    SkillData Nuke = new SkillData("Nuke", "Gain A Nuke As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Nuke", Bool: true);
    SkillData Flak = new SkillData("Flak", "Gain A Flak As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Flak", Bool: true);

    // Homing Weapons
    SkillData Drone = new SkillData("Drone", "Gain Seeker Drones As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Drone", Bool: true);
    SkillData HomingMissile = new SkillData("Homing Missile", "Gain A Homing Missile As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Homing Missile", Bool: true);

    // Rapid Fire Weapons
    SkillData MiniGun = new SkillData("Minigun", "Gain A Minigun As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Minigun", Bool: true);
    SkillData LaserGun = new SkillData("Laser", "Gain A Laser Gun As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Laser gun", Bool: true);

    // Class Specific Skills

    // Rapid Fire
    SkillData BurstAmount = new SkillData("increased burst amount", "Increases Minigun Burst Amount", "5", Float: 5f, isMultipleTime: true, MaxLevel: 4);
    SkillData BurstDelay = new SkillData("decreased burst delay", "Decreases The Burst Delay", "10%", Float: 0.1f, isMultipleTime: true, MaxLevel: 3);
    SkillData RapidFire = new SkillData("Rapid fire", "Swaps Out The Burst For Rapid Fire (Minigun Only)", "Unlock Rapid Fire", Bool: true);

    // Idle Skills
    SkillData ArrayShot = new SkillData("Array Shot", "An Auto Weapon that Shoots A Burst Of Bullet Every 5s, Reduces Damage By 50%", "Unlocks Array Shot", Bool: true);
    SkillData ArrayDelay = new SkillData("Array Delay", "Decreases The Dely Between Each Array Shot", "1s Shorter Delay", Float: 1);
    SkillData ArrayDoubleShot = new SkillData("Array Double Shot", "Makes The Array Shot Shoot Twice, Reduces Damage By 50%", "Unlock Array Double Shot", Bool: true);


    void Start()
    {
        // Skill Requirements
        DoubleShot.requiredLevel = 15;
        MultiShot.requiredLevel = 20;
        ExtraLife.requiredLevel = 15;
        BackwardsFire.requiredLevel = 5;
        ArrayDelay.requiredLevel = 20;
        ArrayDoubleShot.requiredLevel = 20;
        LifeSteal.requiredLevel = 10;
        LifeSteal.prerequisites.Add(HealthIncrease);
        LifeSteal.requiredSkillLevel = 3;
        XPBuff.requiredLevel = 5;
        Spread.requiredLevel = 5;

        //Weapon Skills

        //heavy 
        Nuke.prerequisites.Add(DamageBoost);
        Nuke.requiredSkillLevel = 2;
        Nuke.requiredLevel = 10;
        Flak.requiredLevel = 15;
        ArrayShot.requiredLevel = 10;

        //rapid
        BurstAmount.requiredLevel = 5;
        BurstDelay.requiredLevel = 10;
        RapidFire.prerequisites.Add(BurstDelay);
        RapidFire.requiredSkillLevel = 3;
        RapidFire.requiredLevel = 15;
        LaserGun.requiredLevel = 30;
        ArrayShot.requiredLevel = 5;

        // homing
        HomingMissile.prerequisites.Add(DoubleShot);
        HomingMissile.requiredLevel = 10;
        ArrayShot.requiredLevel = 15;

        // Upgradeable Skills
        allSkills.Add(DamageBoost);
        allSkills.Add(SpeedBoost);
        allSkills.Add(AmmoIncrease);
        allSkills.Add(LifeSteal);
        allSkills.Add(HealthIncrease);
        allSkills.Add(AttackSpeed);
        allSkills.Add(XPBuff);
        allSkills.Add(ExtraLife);
        allSkills.Add(ProjectileSpeed);
        // allSkills.Add(Spread);






        Debug.Log("Number of skills: " + allSkills.Count);
        foreach (SkillData skillData in allSkills)
        {
            Debug.Log("Skill Name: " + skillData.skillName);
        }

        SkillsController.allSkills = allSkills;
    }
    public void SelectedWeapon(float Weapon)
    {
        if (Weapon == 0)
        {
            StatsController.Missile = true;
            Skill.mainWeapon = Skill.WeaponCode.Missile;

            allSkills.Add(Nuke);
            allSkills.Add(Flak);


            // One Time Skills
            if ((PlayerPrefs.GetInt("DoubleShotH") != 0))
                allSkills.Add(DoubleShot);

            if ((PlayerPrefs.GetInt("BackwardsFireH") != 0))
                allSkills.Add(BackwardsFire);
            
            if ((PlayerPrefs.GetInt("MultiShotH") != 0))
                allSkills.Add(MultiShot);

            // Idle Skills
            if ((PlayerPrefs.GetInt("ArrayShotH") != 0))
                allSkills.Add(ArrayShot);
            
            if ((PlayerPrefs.GetInt("ArrayShotH") != 0))
                allSkills.Add(ArrayDelay);
            
            if ((PlayerPrefs.GetInt("ArrayShotDoubleShotH") != 0))
                allSkills.Add(ArrayDoubleShot);


        }
        if (Weapon == 1)
        {
            StatsController.Minigun = true;
            Skill.mainWeapon = Skill.WeaponCode.MiniGun;

            allSkills.Add(LaserGun);
            allSkills.Add(BurstDelay);
            allSkills.Add(BurstAmount);
            if ((PlayerPrefs.GetInt("RapidFireR") != 0))
                allSkills.Add(RapidFire);


            // One Time Skills
            if ((PlayerPrefs.GetInt("DoubleShotR") != 0))
                allSkills.Add(DoubleShot);

            if ((PlayerPrefs.GetInt("BackwardsFireR") != 0))
                allSkills.Add(BackwardsFire);

            if ((PlayerPrefs.GetInt("MultiShotR") != 0))
                allSkills.Add(MultiShot);

            // Idle Skills
            if ((PlayerPrefs.GetInt("ArrayShotR") != 0))
                allSkills.Add(ArrayShot);

            if ((PlayerPrefs.GetInt("ArrayShotR") != 0))
                allSkills.Add(ArrayDelay);

            if ((PlayerPrefs.GetInt("ArrayShotDoubleShot") != 0))
                allSkills.Add(ArrayDoubleShot);

        }
        if (Weapon == 2)
        {
            StatsController.Drone = true;
            Skill.mainWeapon = Skill.WeaponCode.Drone;

            allSkills.Add(HomingMissile);


            if ((PlayerPrefs.GetInt("DoubleShotHO") != 0))
                allSkills.Add(DoubleShot);

            if ((PlayerPrefs.GetInt("BackwardsFireHO") != 0))
                allSkills.Add(BackwardsFire);

            if ((PlayerPrefs.GetInt("MultiShotHO") != 0))
                allSkills.Add(MultiShot);

            // Idle Skills
            if ((PlayerPrefs.GetInt("ArrayShotHO") != 0))
                allSkills.Add(ArrayShot);

            if ((PlayerPrefs.GetInt("ArrayShotHO") != 0))
                allSkills.Add(ArrayDelay);

            if ((PlayerPrefs.GetInt("ArrayShotDoubleShotHO") != 0))
                allSkills.Add(ArrayDoubleShot);
        }
    }

    public void UpdateSkills()
    {

        DamageBoost.SkillUpdate("Damage Boost", ValueUpdate());

        SpeedBoost.SkillUpdate("Speed Boost", ValueUpdate());

        AmmoIncrease.SkillUpdate("Ammo Increase", ValueUpdate());

        LifeSteal.SkillUpdate("life Steal", ValueUpdate());

        HealthIncrease.SkillUpdate("Health Increase", ValueUpdate());

        AttackSpeed.SkillUpdate("Attack Speed", ValueUpdate());

        ProjectileSpeed.SkillUpdate("Bullet Speed", ValueUpdate());
    }
    public float ValueUpdate()
    {
        float[] values = { 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.5f, 0.55f, 0.6f };

        float randomValue = Random.Range(0, 100);

        if (randomValue <= 35)
        {
            return values[0];
        }
        else if (randomValue <= 45)
        {
            return values[1];
        }
        else if (randomValue <= 50)
        {
            return values[2];
        }
        else if (randomValue <= 60)
        {
            return values[3];
        }
        else if (randomValue <= 70)
        {
            return values[4];
        }
        else if (randomValue <= 75)
        {
            return values[5];
        }
        else if (randomValue <= 85)
        {
            return values[6];
        }
        else if (randomValue <= 95)
        {
            return values[7];
        }
        else if (randomValue <= 100)
        {
            return values[8];
        }
        else
        {
            return values[0];
        }
    }
}
