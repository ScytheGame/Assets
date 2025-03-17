using UnityEngine;
using System.IO;
using System.Collections.Generic;
public class SkillTreeData
{
    private static string FilePath = Path.Combine(Application.persistentDataPath, "SkillTreeData.json");



    public bool RapidClass;
    public bool HomingClass;

    public bool Nuke;
    public bool Flak;
    public bool Laser;
    public bool HomingMissile;
    public bool MineHeavy;
    public bool MineRapid;
    public bool MineHoming;


    public bool DoubleShotH, BackwardsFireH, MultiShotH, ArrayShotH, ArrayShotDoubleShotH;
    public bool DoubleShotR, BackwardsFireR, MultiShotR, RapidFireR, ArrayShotR, ArrayShotDoubleShotR;
    public bool DoubleShotHO, BackwardsFireHO, MultiShotHO, ArrayShotHO, ArrayShotDoubleShotHO;

    public float SpeedBoost = 1, HealthBoost, AmmoBoost, ExperienceBoost, SkillValueBoost = 0.2f, SkillChanceBias = 0.55f;
    public float DamageBoostMissile = 1, DamageBoostNuke = 1, DamageBoostMinigun = 1, DamageBoostHomingMissile = 1, DamageBoostFlak = 1, DamageBoostDrone = 1, DamageBoostLaser = 1, DamageBoostMineH = 1, DamageBoostMineR = 1, DamageBoostMineHO = 1;
    public float AttackSpeedMissile = 1, AttackSpeedNuke = 1, AttackSpeedMinigun = 1, AttackSpeedHomingMissile = 1, AttackSpeedFlak = 1, AttackSpeedDrone = 1, AttackSpeedLaser = 1, AttackSpeedMineH = 1, AttackSpeedMineR = 1, AttackSpeedMineHO = 1;
    public float ProjectileSpeedMissile = 1, ProjectileSpeedNuke = 1, ProjectileSpeedMinigun = 1, ProjectileSpeedHomingMissile = 1, ProjectileSpeedFlak = 1, ProjectileSpeedDrone = 1, ProjectileSpeedLaser = 1, ProjectileSpeedMineH = 1, ProjectileSpeedMineR = 1, ProjectileSpeedMineHO = 1;
    public float EnemyBonusLevel = 0;

    public SkillTreeData()
    {

    }

    public void Apply(string ID, float Weapon, float Value)
    {

        // Classes

        if (ID.Equals("Rapid"))
        {
            RapidClass = true;
            Debug.Log("Rapid Class Unlocked");
        }
        if (ID.Equals("Homing"))
        {
            HomingClass = true;
            Debug.Log("Homing Class Unlocked");
        }

        // Weapons
        if (ID.Equals("Nuke"))
        {
            Nuke = true;
            Debug.Log("Nuke Unlocked");
        }

        if (ID.Equals("Flak"))
        {
            Flak = true;
            Debug.Log("Flak Unlocked");
        }

        if (ID.Equals("Laser"))
        {
            Laser = true;
            Debug.Log("Laser Unlocked");
        }

        if (ID.Equals("HomingMissile"))
        {
            HomingMissile = true;
            Debug.Log("Homing Missile Unlocked");
        }

        if (ID.Equals("MineH"))
        {
            MineHeavy = true;
            Debug.Log("Heavy Mine Unlocked");
        }

        if (ID.Equals("MineR"))
        {
            MineRapid = true;
            Debug.Log("Rapid Mine Unlocked");
        }

        if (ID.Equals("MineHO"))
        {
            MineHoming = true;
            Debug.Log("Homing Mine Unlocked");
        }


        // Skills

        if (ID.Equals("DB")) // DB = Damage Boost
        {
            if (Weapon == 0) // all
            {
                DamageBoostMissile += Value;
                DamageBoostNuke += Value;
                DamageBoostMinigun += Value;
                DamageBoostHomingMissile += Value;
                DamageBoostFlak += Value;
                DamageBoostDrone += Value;
                DamageBoostLaser += Value;
                DamageBoostMineH += Value;
                DamageBoostMineR += Value;
                DamageBoostMineHO += Value;

                Debug.Log("Damage Boost All");
            }
            if (Weapon == 1) // Missile
            {
                DamageBoostMissile += Value;
                Debug.Log("Damage Boost Missile");
            }
            if (Weapon == 2) // Nuke
            {
                DamageBoostNuke += Value;
                Debug.Log("Damage Boost Nuke");
            }
            if (Weapon == 3) // Minigun
            {
                DamageBoostMinigun += Value;
                Debug.Log("Damage Boost Minigun");
            }
            if (Weapon == 4) // HomingMissile
            {
                DamageBoostHomingMissile += Value;
                Debug.Log("Damage Boost Homing Missile");
            }
            if (Weapon == 5) // Flak
            {
                DamageBoostFlak += Value;
                Debug.Log("Damage Boost Flak");
            }
            if (Weapon == 6) // Drone
            {
                DamageBoostDrone += Value;
                Debug.Log("Damage Boost drone");
            }
            if (Weapon == 7) // Laser
            {
                DamageBoostLaser += Value;
                Debug.Log("Damage Boost Laser");
            }
            if (Weapon == 8) //Heavy
            {
                DamageBoostMissile += Value;
                DamageBoostNuke += Value;
                DamageBoostFlak += Value;
                DamageBoostMineH += Value;
                Debug.Log("Damage Boost Heavy");
            }
            if (Weapon == 9) // Rapid
            {
                DamageBoostMinigun += Value;
                DamageBoostLaser += Value;
                DamageBoostMineR += Value;
                Debug.Log("Damage Boost Rapid");
            }
            if (Weapon == 10) // Homing
            {
                DamageBoostHomingMissile += Value;
                DamageBoostDrone += Value;
                DamageBoostMineHO += Value;
                Debug.Log("Damage Boost Homing");
            }
            if (Weapon == 11) // Heavy Mine
            {
                DamageBoostMineH += Value;
                Debug.Log("Damage Boost Heavy Mine");
            }
            if (Weapon == 12) // Rapid Mine
            {
                DamageBoostMineR += Value;
                Debug.Log("Damage Boost Rapid Mine");
            }
            if (Weapon == 13) // Homing Mine
            {
                DamageBoostMineHO += Value;
                Debug.Log("Damage Boost Homing Mine");
            }
        }

        if (ID.Equals("SB")) // SB = Speed Boost
        {
            SpeedBoost += Value;
            Debug.Log("Speed Boost");
        }

        if (ID.Equals("AS")) // AS = Attack Speed
        {
            if (Weapon == 0) // All
            {
                AttackSpeedMissile += Value;
                AttackSpeedNuke += Value;
                AttackSpeedMinigun += Value;
                AttackSpeedHomingMissile += Value;
                AttackSpeedFlak += Value;
                AttackSpeedDrone += Value;
                AttackSpeedLaser += Value;
                AttackSpeedMineH += Value;
                AttackSpeedMineR += Value;
                AttackSpeedMineHO += Value;
                Debug.Log("Attack Speed Boost All");
            }
            if (Weapon == 1) // Missile
            {
                AttackSpeedMissile += Value;
                Debug.Log("Attack Speed Boost Missile");
            }
            if (Weapon == 2) // Nuke
            {
                AttackSpeedNuke += Value;
                Debug.Log("Attack Speed Boost Nuke");
            }
            if (Weapon == 3) // Minigun
            {
                AttackSpeedMinigun += Value;
                Debug.Log("Attack Speed Boost Minigun");
            }
            if (Weapon == 4) // HomingMissile
            {
                AttackSpeedHomingMissile += Value;
                Debug.Log("Attack Speed Boost Homing Missile");
            }
            if (Weapon == 5) // Flak
            {
                AttackSpeedFlak += Value;
                Debug.Log("Attack Speed Boost Flak");
            }
            if (Weapon == 6) // Drone
            {
                AttackSpeedDrone += Value;
                Debug.Log("Attack Speed Boost Drone");
            }
            if (Weapon == 7) // Laser
            {
                AttackSpeedLaser += Value;
                Debug.Log("Attack Speed Boost Laser");
            }
            if (Weapon == 8) // Heavy
            {
                AttackSpeedMissile += Value;
                AttackSpeedNuke += Value;
                AttackSpeedFlak += Value;
                AttackSpeedMineH += Value;
                Debug.Log("Attack Speed Boost Heavy");
            }
            if (Weapon == 9) // Rapid
            {
                AttackSpeedMinigun += Value;
                AttackSpeedLaser += Value;
                AttackSpeedMineR += Value;
                Debug.Log("Attack Speed Boost Rapid");
            }
            if (Weapon == 10) // Homing
            {
                AttackSpeedHomingMissile += Value;
                AttackSpeedDrone += Value;
                AttackSpeedMineHO += Value;
                Debug.Log("Attack Speed Boost Homing");
            }
            if (Weapon == 11) // Heavy Mine
            {
                AttackSpeedMineH += Value;
                Debug.Log("Attack Speed Boost Heavy Mine");
            }
            if (Weapon == 12) // Rapid Mine
            {
                AttackSpeedMineR += Value;
                Debug.Log("Attack Speed Boost Rapid Mine");
            }
            if (Weapon == 13) // Homing Mine
            {
                AttackSpeedMineHO += Value;
                Debug.Log("Attack Speed Boost Homing Mine");
            }
        }

        if (ID.Equals("PS")) // PS == Projectile Speed
        {
            if (Weapon == 0) // All
            {
                ProjectileSpeedMissile += Value;
                ProjectileSpeedNuke += Value;
                ProjectileSpeedMinigun += Value;
                ProjectileSpeedHomingMissile += Value;
                ProjectileSpeedFlak += Value;
                ProjectileSpeedDrone += Value;
                ProjectileSpeedLaser += Value;
                ProjectileSpeedMineH += Value;
                ProjectileSpeedMineR += Value;
                ProjectileSpeedMineHO += Value;
                Debug.Log("Projectile Speed Boost All");
            }
            if (Weapon == 1) // Missile
            {
                ProjectileSpeedMissile += Value;
                Debug.Log("Projectile Speed Boost Missile");
            }
            if (Weapon == 2) // Nuke
            {
                ProjectileSpeedNuke += Value;
                Debug.Log("Projectile Speed Boost Nuke");
            }
            if (Weapon == 3) // Minigun
            {
                ProjectileSpeedMinigun += Value;
                Debug.Log("Projectile Speed Boost Minigun");
            }
            if (Weapon == 4) // HomingMissile
            {
                ProjectileSpeedHomingMissile += Value;
                Debug.Log("Projectile Speed Boost Homing Missile");
            }
            if (Weapon == 5) // Flak
            {
                ProjectileSpeedFlak += Value;
                Debug.Log("Projectile Speed Boost Flak");
            }
            if (Weapon == 6) // Drone
            {
                ProjectileSpeedDrone += Value;
                Debug.Log("Projectile Speed Boost Drone");
            }
            if (Weapon == 7) // Laser
            {
                ProjectileSpeedLaser += Value;
                Debug.Log("Projectile Speed Boost Laser");
            }
            if (Weapon == 8) // Heavy
            {
                ProjectileSpeedMissile += Value;
                ProjectileSpeedNuke += Value;
                ProjectileSpeedFlak += Value;
                ProjectileSpeedMineH += Value;
                Debug.Log("Projectile Speed Boost Heavy");
            }
            if (Weapon == 9) // Rapid
            {
                ProjectileSpeedMinigun += Value;
                ProjectileSpeedLaser += Value;
                ProjectileSpeedMineR += Value;
                Debug.Log("Projectile Speed Boost Rapid");
            }
            if (Weapon == 10) // Homing
            {
                ProjectileSpeedHomingMissile += Value;
                ProjectileSpeedDrone += Value;
                ProjectileSpeedMineHO += Value;
                Debug.Log("Projectile Speed Boost Homing");
            }
            if (Weapon == 11) // Heavy Mine
            {
                ProjectileSpeedMineH += Value;
                Debug.Log("Projectile Speed Boost Heavy Mine");
            }
            if (Weapon == 12) // Rapid Mine
            {
                ProjectileSpeedMineR += Value;
                Debug.Log("Projectile Speed Boost Rapid Mine");
            }
            if (Weapon == 13) // Homing Mine
            {
                ProjectileSpeedMineHO += Value;
                Debug.Log("Projectile Speed Boost Homing Mine");
            }
        }

        if (ID.Equals("HB")) // Health Boost
        {
            HealthBoost += Value;
            Debug.Log("Health Boost");
        }

        if (ID.Equals("AB")) // Ammo Boost
        {
            AmmoBoost += Value;
            Debug.Log("Ammo Boost");
        }

        if (ID.Equals("EB")) // Experience Boost
        {
            ExperienceBoost += Value;
            Debug.Log("Experience Boost");
        }

        if (ID.Equals("SVB")) // Skill Value Boost
        {
            SkillValueBoost += Value;
            Debug.Log("Skill Value Boost");
        }

        if (ID.Equals("SCB")) // Skill Chance Bias
        {
            SkillChanceBias += Value;
            Debug.Log("Skill Chance Bias");
        }

        // Skills (bool)

        if (ID.Equals("MS")) // MultiShot
        {
            if (Weapon == 8) // Heavy
            {
                MultiShotH = true;
                Debug.Log("MultiShot Heavy Unlocked");
            }
            if (Weapon == 9) // Rapid
            {
                MultiShotR = true;
                Debug.Log("MultiShot Rapid Unlocked");
            }
            if (Weapon == 10) // Homing
            {
                MultiShotHO = true;
                Debug.Log("MultiShot Homing Unlocked");
            }
        }

        if (ID.Equals("DS")) // DoubleShot
        {
            if (Weapon == 8) // Heavy
            {
                DoubleShotH = true;
                Debug.Log("DoubleShot Heavy Unlocked");
            }
            if (Weapon == 9) // Rapid
            {
                DoubleShotR = true;
                Debug.Log("DoubleShot Rapid Unlocked");
            }
            if (Weapon == 10) // Homing
            {
                DoubleShotHO = true;
                Debug.Log("DoubleShot Homing Unlocked");
            }
        }

        if (ID.Equals("BF")) // BackwardsFire
        {
            if (Weapon == 8) // Heavy
            {
                BackwardsFireH = true;
                Debug.Log("BackwardsFire Heavy Unlocked");
            }
            if (Weapon == 9) // Rapid
            {
                BackwardsFireR = true;
                Debug.Log("BackwardsFire Rapid Unlocked");
            }
            if (Weapon == 10) // Homing
            {
                BackwardsFireHO = true;
                Debug.Log("BackwardsFire Homing Unlocked");
            }
        }

        if (ID.Equals("ArrS")) // ArrayShot
        {
            if (Weapon == 8) // Heavy
            {
                ArrayShotH = true;
                Debug.Log("ArrayShot Heavy Unlocked");
            }
            if (Weapon == 9) // Rapid
            {
                ArrayShotR = true;
                Debug.Log("ArrayShot Rapid Unlocked");
            }
            if (Weapon == 10) // Homing
            {
                ArrayShotHO = true;
                Debug.Log("ArrayShot Homing Unlocked");
            }
        }

        if (ID.Equals("ArrSD")) // ArrayShot DoubleShot
        {
            if (Weapon == 8) // Heavy
            {
                ArrayShotDoubleShotH = true;
                Debug.Log("ArrayShot DoubleShot Heavy Unlocked");
            }
            if (Weapon == 9) // Rapid
            {
                ArrayShotDoubleShotR = true;
                Debug.Log("ArrayShot DoubleShot Rapid Unlocked");
            }
            if (Weapon == 10) // Homing
            {
                ArrayShotDoubleShotHO = true;
                Debug.Log("ArrayShot DoubleShot Homing Unlocked");
            }
        }

        if (ID.Equals("RF")) // Rapid Fire
        {
            if (Weapon == 9) // Rapid
            {
                RapidFireR = true;
                Debug.Log("Rapid Fire Rapid Unlocked");
            }
        }
        EnemyBonusLevel += 0.1f;

        SkillTreeData.Save(this);
    }

    public static void Save(SkillTreeData Data)
    {
        string Json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(FilePath, Json);
    }

    public static SkillTreeData Load()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonUtility.FromJson<SkillTreeData>(json);
        }
        return new SkillTreeData();
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
