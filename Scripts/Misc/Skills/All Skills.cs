using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI;

public class AllSkills : MonoBehaviour
{
    [SerializeField] StatsController StatsController;
    [SerializeField] SkillsController SkillsController;
    [SerializeField] SkillData SkillData;
    [SerializeField] Skill Skill;
    [SerializeField] float BiasFactor;
    [SerializeField] float MaxValue;
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
    SkillData MineHeavy = new SkillData("Heavy Mine", "Gain A Mine As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Mine", Bool: true);

    // Homing Weapons
    SkillData Drone = new SkillData("Drone", "Gain Seeker Drones As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Drone", Bool: true);
    SkillData HomingMissile = new SkillData("Homing Missile", "Gain A Homing Missile As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Homing Missile", Bool: true);
    SkillData MineHoming = new SkillData("Homing Mine", "Gain A Mine As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Mine", Bool: true);

    // Rapid Fire Weapons
    SkillData MiniGun = new SkillData("Minigun", "Gain A Minigun As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Minigun", Bool: true);
    SkillData LaserGun = new SkillData("Laser", "Gain A Laser Gun As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Laser gun", Bool: true);
    SkillData MineRapid = new SkillData("Rapid Mine", "Gain A Mine As An Extra Weapon, Reduces (Damage, Attack Speed, Projectile Speed) All By 50%", "Unlocks Mine", Bool: true);

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






        //Debug.Log("Number of skills: " + allSkills.Count);
        foreach (SkillData skillData in allSkills)
        {
            //Debug.Log("Skill Name: " + skillData.skillName);
        }

        SkillsController.allSkills = allSkills;
    }
    public void SelectedWeapon(float Weapon)
    {
        SkillTreeData SkillData = SkillTreeData.Load();

        //Weapon Skills




        if (Weapon == 0)
        {
            StatsController.Missile = true;
            Skill.mainWeapon = Skill.WeaponCode.Missile;

            //heavy 
            Nuke.prerequisites.Add(DamageBoost);
            Nuke.requiredSkillLevel = 2;
            Nuke.requiredLevel = 10;

            if (SkillData.Nuke)
                Flak.requiredLevel = 20;
            else
                Flak.requiredLevel = 15;

            ArrayShot.requiredLevel = 10;

            MineHeavy.requiredLevel = 25;


            if (SkillData.Nuke)
                allSkills.Add(Nuke);

            if (SkillData.Flak)
                allSkills.Add(Flak);

            if (SkillData.MineHeavy)
                allSkills.Add(MineHeavy);


            // One Time Skills
            if (SkillData.DoubleShotH)
                allSkills.Add(DoubleShot);

            if (SkillData.BackwardsFireH)
                allSkills.Add(BackwardsFire);
            
            if (SkillData.MultiShotH)
                allSkills.Add(MultiShot);

            // Idle Skills
            if (SkillData.ArrayShotH)
                allSkills.Add(ArrayShot);
            
            if (SkillData.ArrayShotH)
                allSkills.Add(ArrayDelay);
            
            if (SkillData.ArrayShotDoubleShotH)
                allSkills.Add(ArrayDoubleShot);


            //Debug.Log("Number of skills: " + allSkills.Count);
            foreach (SkillData skillData in allSkills)
            {
                //Debug.Log("Skill Name: " + skillData.skillName);
            }
        }
        if (Weapon == 1)
        {
            StatsController.Minigun = true;
            Skill.mainWeapon = Skill.WeaponCode.MiniGun;

            //rapid
            BurstAmount.requiredLevel = 5;
            BurstDelay.requiredLevel = 10;
            RapidFire.prerequisites.Add(BurstDelay);
            RapidFire.requiredSkillLevel = 3;
            RapidFire.requiredLevel = 15;
            LaserGun.requiredLevel = 35;
            ArrayShot.requiredLevel = 5;
            MineRapid.requiredLevel = 20;

            allSkills.Add(BurstDelay);
            allSkills.Add(BurstAmount);

            if (SkillData.Laser)
                allSkills.Add(LaserGun);

            if (SkillData.MineRapid)
                allSkills.Add(MineRapid);

            if (SkillData.RapidFireR)
                allSkills.Add(RapidFire);


            // One Time Skills
            if (SkillData.DoubleShotR)
                allSkills.Add(DoubleShot);

            if (SkillData.BackwardsFireR)
                allSkills.Add(BackwardsFire);

            if (SkillData.MultiShotR)
                allSkills.Add(MultiShot);

            // Idle Skills
            if (SkillData.ArrayShotR)
                allSkills.Add(ArrayShot);

            if (SkillData.ArrayShotR)
                allSkills.Add(ArrayDelay);

            if (SkillData.ArrayShotDoubleShotR)
                allSkills.Add(ArrayDoubleShot);

            //Debug.Log("Number of skills: " + allSkills.Count);
            foreach (SkillData skillData in allSkills)
            {
                //Debug.Log("Skill Name: " + skillData.skillName);
            }
        }
        if (Weapon == 2)
        {
            StatsController.Drone = true;
            Skill.mainWeapon = Skill.WeaponCode.Drone;

            // homing
            HomingMissile.prerequisites.Add(DoubleShot);
            HomingMissile.requiredLevel = 10;
            MineHoming.requiredLevel = 20;
            ArrayShot.requiredLevel = 15;

            if (SkillData.HomingMissile)
                allSkills.Add(HomingMissile);

            if (SkillData.MineHoming)
                allSkills.Add(MineHoming);


            // One Time Skills
            if (SkillData.DoubleShotHO)
                allSkills.Add(DoubleShot);

            if (SkillData.BackwardsFireHO)
                allSkills.Add(BackwardsFire);

            if (SkillData.MultiShotHO)
                allSkills.Add(MultiShot);

            // Idle Skills
            if (SkillData.ArrayShotHO)
                allSkills.Add(ArrayShot);

            if (SkillData.ArrayShotHO)
                allSkills.Add(ArrayDelay);

            if (SkillData.ArrayShotDoubleShotHO)
                allSkills.Add(ArrayDoubleShot);

            //Debug.Log("Number of skills: " + allSkills.Count);
            foreach (SkillData skillData in allSkills)
            {
                //Debug.Log("Skill Name: " + skillData.skillName);
            }
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
        SkillTreeData skillData = SkillTreeData.Load();
        BiasFactor = skillData.SkillChanceBias;
        List<float> Values = GeneratedValues();

        if (Values.Count == 0) 
            return 0;

        float TotalWeight = 0f;

        List<float> CumulativeWeights = new List<float>();

        for (int i = 0; i < Values.Count; i++)
        {
            TotalWeight += Mathf.Pow(i + 1, BiasFactor);
            CumulativeWeights.Add(TotalWeight);
        }

        for (int i = 0; i < Values.Count; i++)
        {
            CumulativeWeights[i] /= TotalWeight;
        }

        float RandomValue = Random.Range(0f, 1f);

        for (int i = 0; i < Values.Count; i ++)
        {
            if (RandomValue <= CumulativeWeights[i])
            {
                return Values[i];
            }
        }

        return Values[0];

    }

    List<float> GeneratedValues()
    {
        SkillTreeData skillData = SkillTreeData.Load();
        MaxValue = skillData.SkillValueBoost;
        List<float> Values = new List<float>();

        for (float i = MaxValue; i >= 0.05f; i -= 0.05f)
        {
            float roundedValue = Mathf.Round(i * 100f) / 100f;
            //Debug.Log(" Available skill percent: " + roundedValue);
            Values.Add(roundedValue);
        }
        return Values;
    }
}
