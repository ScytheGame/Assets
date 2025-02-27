using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeController : MonoBehaviour
{
    private void Start()
    {
        // classes

        RapidClass = (PlayerPrefs.GetInt("RapidClass") != 0);

        HomingClass = (PlayerPrefs.GetInt("HomingClass") != 0);

        // Weapons : Heavy

        Nuke = (PlayerPrefs.GetInt("Nuke") != 0);

        Flak = (PlayerPrefs.GetInt("Flak") != 0);

        // Weapons : Rapid

        Laser = (PlayerPrefs.GetInt("Laser") != 0);

        // Weapons : Homing

        HomingMissile = (PlayerPrefs.GetInt("HomingMissile") != 0);

        // Skills : Heavy

        DoubleShotH = (PlayerPrefs.GetInt("DoubleShotH") != 0);

        BackwardsFireH = (PlayerPrefs.GetInt("BackwardsFireH") != 0);

        MultiShotH = (PlayerPrefs.GetInt("MultiShotH") != 0);

        ArrayShotH = (PlayerPrefs.GetInt("ArrayShotH") != 0);

        ArrayShotDoubleShotH = (PlayerPrefs.GetInt("ArrayShotDoubleShotH") != 0);

        // Skills : Rapid

        DoubleShotR = (PlayerPrefs.GetInt("DoubleShotR") != 0);

        BackwardsFireR = (PlayerPrefs.GetInt("BackwardsFireR") != 0);

        MultiShotR = (PlayerPrefs.GetInt("MultiShotR") != 0);

        RapidFireR = (PlayerPrefs.GetInt("RapidFireR") != 0);

        ArrayShotR = (PlayerPrefs.GetInt("ArrayShotR") != 0);

        ArrayShotDoubleShotR = (PlayerPrefs.GetInt("ArrayShotDoubleShotR") != 0);

        // Skills : Homing

        DoubleShotHO = (PlayerPrefs.GetInt("DoubleShotHO") != 0);

        BackwardsFireHO = (PlayerPrefs.GetInt("BackwardsFireHO") != 0);

        MultiShotHO = (PlayerPrefs.GetInt("MultiShotHO") != 0);

        ArrayShotHO = (PlayerPrefs.GetInt("ArrayShotHO") != 0);

        ArrayShotDoubleShotHO = (PlayerPrefs.GetInt("ArrayShotDoubleShotHO") != 0);


        // Stat Boosts


        SpeedBoost = PlayerPrefs.GetFloat("SpeedBoostST", SpeedBoost);

        HealthBoost = PlayerPrefs.GetFloat("HealthBoostST", HealthBoost);

        AmmoBoost = PlayerPrefs.GetFloat("AmmoBoostST", AmmoBoost);

        ExperienceBoost = PlayerPrefs.GetFloat("ExperienceBoostST", ExperienceBoost);

        // Damage Boost

        DamageBoostMissile = PlayerPrefs.GetFloat("DamageBoostMissileST", DamageBoostMissile);

        DamageBoostNuke = PlayerPrefs.GetFloat("DamageBoostNukeST", DamageBoostNuke);

        DamageBoostMinigun = PlayerPrefs.GetFloat("DamageBoostMinigunST", DamageBoostMinigun);

        DamageBoostHomingMissile = PlayerPrefs.GetFloat("DamageBoostHomingMissileST", DamageBoostHomingMissile);

        DamageBoostFlak = PlayerPrefs.GetFloat("DamageBoostFlakST", DamageBoostFlak);

        DamageBoostDrone = PlayerPrefs.GetFloat("DamageBoostDroneST", DamageBoostDrone);

        DamageBoostLaser = PlayerPrefs.GetFloat("DamageBoostLaserST", DamageBoostLaser);


        // Attack Speed

        AttackSpeedMissile = PlayerPrefs.GetFloat("AttackSpeedMissileST", AttackSpeedMissile);

        AttackSpeedNuke = PlayerPrefs.GetFloat("AttackSpeedNukeST", AttackSpeedNuke);

        AttackSpeedMinigun = PlayerPrefs.GetFloat("AttackSpeedMinigunST", AttackSpeedMinigun);

        AttackSpeedHomingMissile = PlayerPrefs.GetFloat("AttackSpeedHomingMissileST", AttackSpeedHomingMissile);

        AttackSpeedFlak = PlayerPrefs.GetFloat("AttackSpeedFlakST", AttackSpeedFlak);

        AttackSpeedDrone = PlayerPrefs.GetFloat("AttackSpeedDroneST", AttackSpeedDrone);

        AttackSpeedLaser = PlayerPrefs.GetFloat("AttackSpeedLaserST", AttackSpeedLaser);


        // Projectile Speed

        ProjectileSpeedMissile = PlayerPrefs.GetFloat("ProjectileSpeedMissileST", ProjectileSpeedMissile);

        ProjectileSpeedNuke = PlayerPrefs.GetFloat("ProjectileSpeedNukeST", ProjectileSpeedNuke);

        ProjectileSpeedMinigun = PlayerPrefs.GetFloat("ProjectileSpeedMinigunST", ProjectileSpeedMinigun);

        ProjectileSpeedHomingMissile = PlayerPrefs.GetFloat("ProjectileSpeedHomingMissileST", ProjectileSpeedHomingMissile);

        ProjectileSpeedFlak = PlayerPrefs.GetFloat("ProjectileSpeedFlakST", ProjectileSpeedFlak);

        ProjectileSpeedDrone = PlayerPrefs.GetFloat("ProjectileSpeedDroneST", ProjectileSpeedDrone);

        ProjectileSpeedLaser = PlayerPrefs.GetFloat("ProjectileSpeedLaserST", ProjectileSpeedLaser);


    }
    public void Upgrade(string ID, float Weapon, float Value)
    {

        // Classes

        if (ID.Equals("Rapid"))
        {
            RapidClass = true;
        }
        if (ID.Equals("Homing"))
        {
            HomingClass = true;
        }

        // Weapons
        if (ID.Equals("Nuke"))
        {
            Nuke = true;
        }

        if (ID.Equals("Flak"))
        {
            Flak = true;
        }

        if (ID.Equals("Laser"))
        {
            Laser = true;
        }

        if (ID.Equals("HomingMissile"))
        {
            HomingMissile = true;
        }


        // Skills

        if (ID.Equals("DB")) // DB = Damage Boost
        {
            if (Weapon == 1)
            {
                DamageBoostMissile += Value;
            }
            if (Weapon == 2)
            {
                DamageBoostNuke += Value;
            }
            if (Weapon == 3)
            {
                DamageBoostMinigun += Value;
            }
            if (Weapon == 4)
            {
                DamageBoostHomingMissile += Value;
            }
            if (Weapon == 5)
            {
                DamageBoostFlak += Value;
            }
            if (Weapon == 6)
            {
                DamageBoostDrone += Value;
            }
            if (Weapon == 7)
            {
                DamageBoostLaser += Value;
            }
        }

        if (ID.Equals("SB")) // SB = Speed Boost
        {
            SpeedBoost += SpeedBoost;
        }

        if (ID.Equals("AS")) // AS = Attack Speed
        {
            if (Weapon == 1)
            {
                AttackSpeedMissile += Value;
            }
            if (Weapon == 2)
            {
                AttackSpeedNuke += Value;
            }
            if (Weapon == 3)
            {
                AttackSpeedMinigun += Value;
            }
            if (Weapon == 4)
            {
                AttackSpeedHomingMissile += Value;
            }
            if (Weapon == 5)
            {
                AttackSpeedFlak += Value;
            }
            if (Weapon == 6)
            {
                AttackSpeedDrone += Value;
            }
            if (Weapon == 7)
            {
                AttackSpeedLaser += Value;
            }
        }

        if (ID.Equals("PS")) // Projectile Speed
        {
            if (Weapon == 1)
            {
                ProjectileSpeedMissile += Value;
            }
            if (Weapon == 2)
            {
                ProjectileSpeedNuke += Value;
            }
            if (Weapon == 3)
            {
                ProjectileSpeedMinigun += Value;
            }
            if (Weapon == 4)
            {
                ProjectileSpeedHomingMissile += Value;
            }
            if (Weapon == 5)
            {
                ProjectileSpeedFlak += Value;
            }
            if (Weapon == 6)
            {
                ProjectileSpeedDrone += Value;
            }
            if (Weapon == 7)
            {
                ProjectileSpeedLaser += Value;
            }
        }

        if (ID.Equals("HB")) // Health Boost
        {
            HealthBoost += Value;
        }

        if (ID.Equals("EB")) // Experience Boost
        {
            ExperienceBoost += Value;
        }

        // Skills (bool)

        if (ID.Equals("MS")) // MultiShot
        {
            if (Weapon == 8)
            {
                MultiShotH = true;
            }
            if (Weapon == 9)
            {
                MultiShotR = true;
            }
            if (Weapon == 10)
            {
                MultiShotHO = true;
            }
        }

        if (ID.Equals("DS")) // DoubleShot
        {
            if (Weapon == 8)
            {
                DoubleShotH = true;
            }
            if (Weapon == 9)
            {
                DoubleShotR = true;
            }
            if (Weapon == 10)
            {
                DoubleShotHO = true;
            }
        }

        if (ID.Equals("BF")) // BackwardsFire
        {
            if (Weapon == 8)
            {
                BackwardsFireH = true;
            }
            if (Weapon == 9)
            {
                BackwardsFireR = true;
            }
            if (Weapon == 10)
            {
                BackwardsFireHO = true;
            }
        }

        if (ID.Equals("ArrS")) // ArrayShot
        {
            if (Weapon == 8)
            {
                ArrayShotH = true;
            }
            if (Weapon == 9)
            {
                ArrayShotR = true;
            }
            if (Weapon == 10)
            {
                ArrayShotHO = true;
            }
        }

        if (ID.Equals("ArrSD")) // ArrayShot DoubleShot
        {
            if (Weapon == 8)
            {
                ArrayShotDoubleShotH = true;
            }
            if (Weapon == 9)
            {
                ArrayShotDoubleShotR = true;
            }
            if (Weapon == 10)
            {
                ArrayShotDoubleShotHO = true;
            }
        }

        if (ID.Equals("RapidFire"))
        {
            if (Weapon == 9)
            {
                RapidFireR = true;
            }
        }

        Save();
    }

    // classes

    bool RapidClass;

    bool HomingClass;

    // weapons : Heavy Class

    bool Nuke;

    bool Flak;


    // weapons : Rapid Class

    bool Laser;


    // weapons : Homing Class

    bool HomingMissile;


    // skills : Heavy Class

    bool DoubleShotH;

    bool BackwardsFireH;

    bool MultiShotH;

    bool ArrayShotH;

    bool ArrayShotDoubleShotH;


    // skills : Rapid Class

    bool DoubleShotR;

    bool BackwardsFireR;

    bool MultiShotR;

    bool RapidFireR;

    bool ArrayShotR;

    bool ArrayShotDoubleShotR;


    // skills : Homing Class

    bool DoubleShotHO;

    bool BackwardsFireHO;

    bool MultiShotHO;

    bool ArrayShotHO;

    bool ArrayShotDoubleShotHO;


    // Stat Boosts

    float SpeedBoost = 1;

    float HealthBoost;

    float AmmoBoost;

    float ExperienceBoost;

    // Damage Boost


    float DamageBoostMissile = 1;

    float DamageBoostNuke = 1;

    float DamageBoostMinigun = 1;

    float DamageBoostHomingMissile = 1;

    float DamageBoostFlak = 1;

    float DamageBoostDrone = 1;

    float DamageBoostLaser = 1;

    // Attack Speed

    float AttackSpeedMissile = 1;

    float AttackSpeedNuke = 1;

    float AttackSpeedMinigun = 1;

    float AttackSpeedHomingMissile = 1;

    float AttackSpeedFlak = 1;

    float AttackSpeedDrone = 1;

    float AttackSpeedLaser = 1;

    // Projectile Speed

    float ProjectileSpeedMissile = 1;

    float ProjectileSpeedNuke = 1;

    float ProjectileSpeedMinigun = 1;

    float ProjectileSpeedHomingMissile = 1;

    float ProjectileSpeedFlak = 1;

    float ProjectileSpeedDrone = 1;

    float ProjectileSpeedLaser = 1;


    // Enemy Stats Changes



    void Save()
    {
        // classes

        PlayerPrefs.SetInt("RapidClass", (RapidClass ? 1 : 0));

        PlayerPrefs.SetInt("HomingClass", (HomingClass ? 1 : 0));

        // Weapons : Heavy

        PlayerPrefs.SetInt("Nuke", (Nuke ? 1 : 0));

        PlayerPrefs.SetInt("Flak", (Flak ? 1 : 0));

        // Weapons : Rapid

        PlayerPrefs.SetInt("Laser", (Laser ? 1 : 0));

        // Weapons : Homing

        PlayerPrefs.SetInt("HomingMissile", (HomingMissile ? 1 : 0));

        // Skills : Heavy

        PlayerPrefs.SetInt("DoubleShotH", (DoubleShotH ? 1 : 0));

        PlayerPrefs.SetInt("BackwardsFireH", (BackwardsFireH ? 1 : 0));

        PlayerPrefs.SetInt("MultiShotH", (MultiShotH ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotH", (ArrayShotH ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotDoubleShotH", (ArrayShotDoubleShotH ? 1 : 0));

        // Skills : Rapid

        PlayerPrefs.SetInt("DoubleShotR", (DoubleShotR ? 1 : 0));

        PlayerPrefs.SetInt("BackwardsFireR", (BackwardsFireR ? 1 : 0));

        PlayerPrefs.SetInt("MultiShotR", (MultiShotR ? 1 : 0));

        PlayerPrefs.SetInt("RapidFireR", (RapidFireR ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotR", (ArrayShotR ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotDoubleShotR", (ArrayShotDoubleShotR ? 1 : 0));

        // Skills : Homing

        PlayerPrefs.SetInt("DoubleShotHO", (DoubleShotHO ? 1 : 0));

        PlayerPrefs.SetInt("BackwardsFireHO", (BackwardsFireHO ? 1 : 0));

        PlayerPrefs.SetInt("MultiShotHO", (MultiShotHO ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotHO", (ArrayShotHO ? 1 : 0));

        PlayerPrefs.SetInt("ArrayShotDoubleShotHO", (ArrayShotDoubleShotHO ? 1 : 0));


        // Stat Boosts


        PlayerPrefs.SetFloat("SpeedBoostST", SpeedBoost);

        PlayerPrefs.SetFloat("HealthBoostST", HealthBoost);

        PlayerPrefs.SetFloat("AmmoBoostST", AmmoBoost);

        PlayerPrefs.SetFloat("ExperienceBoostST", ExperienceBoost);

        // Damage Boost

        PlayerPrefs.SetFloat("DamageBoostMissileST", DamageBoostMissile);

        PlayerPrefs.SetFloat("DamageBoostNukeST", DamageBoostNuke);

        PlayerPrefs.SetFloat("DamageBoostMinigunST", DamageBoostMinigun);

        PlayerPrefs.SetFloat("DamageBoostHomingMissileST", DamageBoostHomingMissile);

        PlayerPrefs.SetFloat("DamageBoostFlakST", DamageBoostFlak);

        PlayerPrefs.SetFloat("DamageBoostDroneST", DamageBoostDrone);

        PlayerPrefs.SetFloat("DamageBoostLaserST", DamageBoostLaser);


        // Attack Speed

        PlayerPrefs.SetFloat("AttackSpeedMissileST", AttackSpeedMissile);

        PlayerPrefs.SetFloat("AttackSpeedNukeST", AttackSpeedNuke);

        PlayerPrefs.SetFloat("AttackSpeedMinigunST", AttackSpeedMinigun);

        PlayerPrefs.SetFloat("AttackSpeedHomingMissileST", AttackSpeedHomingMissile);

        PlayerPrefs.SetFloat("AttackSpeedFlakST", AttackSpeedFlak);

        PlayerPrefs.SetFloat("AttackSpeedDroneST", AttackSpeedDrone);

        PlayerPrefs.SetFloat("AttackSpeedLaserST", AttackSpeedLaser);


        // Projectile Speed

        PlayerPrefs.SetFloat("ProjectileSpeedMissileST", ProjectileSpeedMissile);

        PlayerPrefs.SetFloat("ProjectileSpeedNukeST", ProjectileSpeedNuke);

        PlayerPrefs.SetFloat("ProjectileSpeedMinigunST", ProjectileSpeedMinigun);

        PlayerPrefs.SetFloat("ProjectileSpeedHomingMissileST", ProjectileSpeedHomingMissile);

        PlayerPrefs.SetFloat("ProjectileSpeedFlakST", ProjectileSpeedFlak);

        PlayerPrefs.SetFloat("ProjectileSpeedDroneST", ProjectileSpeedDrone);

        PlayerPrefs.SetFloat("ProjectileSpeedLaserST", ProjectileSpeedLaser);


    }
}
