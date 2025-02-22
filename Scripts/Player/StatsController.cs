using UnityEngine;
using Sirenix.OdinInspector;

public class StatsController : MonoBehaviour
{
    [SerializeField] SkillsController SkillsController;
    [SerializeField] RandomEnemySpawn RandomEnemySpawn;
    [SerializeField] GameSettings GameSettings;
    [Space(10)]
    [TabGroup("Player Stats")]
    public float MaxHealth = 2500;
    [TabGroup("Player Stats")]
    public float CurrentHealth = 2500;
    [TabGroup("Player Stats")]
    public float ExtraLives = 0;
    [TabGroup("Player Stats")]
    public float MaxStamina = 100;
    [TabGroup("Player Stats")]
    public float CurrentStamina = 100;
    [TabGroup("Player Stats")]
    public float MoveSpeed = 20;
    [TabGroup("Player Stats")]
    public float ExpGain = 20;

    [Space(10)]
    [TabGroup("Weapon Damage")]
    public float MissileDamage = 300;
    [TabGroup("Weapon Damage")]
    public float NukeDamage = 700;
    [TabGroup("Weapon Damage")]
    public float MinigunDamage = 120;
    [TabGroup("Weapon Damage")]
    public float HomingMissileDamage = 500;
    [TabGroup("Weapon Damage")]
    public float FlakDamage = 350;
    [TabGroup("Weapon Damage")]
    public float DroneDamage = 180;
    [TabGroup("Weapon Damage")]
    public float LaserDamage = 150;
    [TabGroup("Weapon Damage")]
    public float MineDamage = 350;
    [TabGroup("Weapon Damage")]
    public float DamageBonus = 1;
    [Space(10)]
    [TabGroup("Weapon Stats")]
    public float MissileSpeed = 20;
    [TabGroup("Weapon Stats")]
    public float MissileFireDelay = 1;
    [TabGroup("Weapon Stats")]
    public float NukeSpeed = 60;
    [TabGroup("Weapon Stats")]
    public float NukeFireDelay = 5;
    [TabGroup("Weapon Stats")]
    public float MinigunSpeed = 30;
    [TabGroup("Weapon Stats")]
    public float MinigunFireDelay = 0.001f;
    [TabGroup("Weapon Stats")]
    public float HomingMissileSpeed = 5;
    [TabGroup("Weapon Stats")]
    public float HomingMissileFireDelay = 1.5f;
    [TabGroup("Weapon Stats")]
    public float FlakSpeed = 20;
    [TabGroup("Weapon Stats")]
    public float FlakFireDelay = 1.5f;
    [TabGroup("Weapon Stats")]
    public float DroneSpeed = 5;
    [TabGroup("Weapon Stats")]
    public float DroneFireDelay = 1.5f;
    [TabGroup("Weapon Stats")]
    public float LaserSpeed = 50;
    [TabGroup("Weapon Stats")]
    public float LaserFireDelay = 0.01f;
    [TabGroup("Weapon Stats")]
    public float ArrayShotSpeed = 30;
    [TabGroup("Weapon Stats")]
    public float MineSpeed = 5;
    [TabGroup("Weapon Stats")]
    public float MineFireDelay = 2f;

    [Space(10)]
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootMissile;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootNuke;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootMiniGun;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootHoming;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootFlak;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootDrone;
    [TabGroup("Weapon Poison Damage")]
    public float poisonShootLaser;
    [TabGroup("Weapon Poison Damage")]
    public float lifesteal;
    [TabGroup("Weapon Poison Damage")]
    public bool poisonShoot = false;

    [Space(10)]
    [TabGroup("Level Stats")]
    public float targetXP = 100;
    [TabGroup("Level Stats")]
    public float targetXpIncrease = 15;
    [TabGroup("Level Stats")]
    public bool leveledUp = false;
    [TabGroup("Level Stats")]
    public int currentLevel;
    [TabGroup("Level Stats")]
    public float currentXP = 0;

    [Space(10)]
    [TabGroup("Class Specific Skills")]
    public float BurstAmount = 10;
    [TabGroup("Class Specific Skills")]
    public float BurstDelay = 1;


    [Space(10)]
    [TabGroup("Idle Skills")]
    public float ArrayDelay = 10;
    [TabGroup("Idle Skills")]
    public bool ArrayDoubleShot = false;


    [Space(10)]
    [TabGroup("Bool Skills")]
    public bool DoubleShot;
    [TabGroup("Bool Skills")]
    public bool BackwardsFire;
    [TabGroup("Bool Skills")]
    public bool MultiShot;
    [TabGroup("Bool Skills")]
    public bool Missile;
    [TabGroup("Bool Skills")]
    public bool Nuke;
    [TabGroup("Bool Skills")]
    public bool Flak;
    [TabGroup("Bool Skills")]
    public bool Drone;
    [TabGroup("Bool Skills")]
    public bool Laser;
    [TabGroup("Bool Skills")]
    public bool Minigun;
    [TabGroup("Bool Skills")]
    public bool HomingMissile;
    [TabGroup("Bool Skills")]
    public bool RapidFire;
    [TabGroup("Bool Skills")]
    public bool ArrayShot;
    [TabGroup("Bool Skills")]
    public bool Mine;

    int skillCheck = 0;
    float buffAmount;
    int minutes;
    float expTimeBuff = 1;
    float expTime;
    float expTimeBuffCost = 1;
    float expTimeCost;
    float expGain = 20;
    int timeinterval = 5;

    private void Start()
    {
        MaxHealth = PlayerPrefs.GetFloat("PlayerHealth", 2500);
        MaxStamina = PlayerPrefs.GetFloat("PlayerAmmo", 100);
        DamageBonus = PlayerPrefs.GetFloat("PlayerDamageBonus", 1);
        MissileDamage *= DamageBonus;
        NukeDamage *= DamageBonus;
        MinigunDamage *= DamageBonus;
        HomingMissileDamage *= DamageBonus;
        FlakDamage *= DamageBonus;
        DroneDamage *= DamageBonus;
        LaserDamage *= DamageBonus;

        ExpGain = PlayerPrefs.GetFloat("PlayerXPGain", 20);
        targetXpIncrease = PlayerPrefs.GetFloat("PlayerXPIncreaseCost", 15);
        expTimeBuffCost = PlayerPrefs.GetFloat("PlayerXPTimeCost", 1);
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
    }
    void Update()
    {
        minutes = RandomEnemySpawn.minutes;
        SkillsController.playerLevel = currentLevel;

        if (minutes >= timeinterval)
        {
            expTime += expTimeBuff;
            expTimeCost += expTimeBuffCost;
            timeinterval += 2;
        }
    }
    void DamageDebuff(float Value)
    {
        MissileDamage = MissileDamage / Value;
        NukeDamage = NukeDamage / Value;
        HomingMissileDamage = HomingMissileDamage / Value;
        MinigunDamage = MinigunDamage / Value;
        FlakDamage = FlakDamage / Value;
        DroneDamage = DroneDamage / Value;
        LaserDamage = LaserDamage / Value;
    }
    void StatDebuff(float Value)
    {
        MissileDamage = MissileDamage / Value;
        NukeDamage = NukeDamage / Value;
        HomingMissileDamage = HomingMissileDamage / Value;
        MinigunDamage = MinigunDamage / Value;
        FlakDamage = FlakDamage / Value;
        DroneDamage = DroneDamage / Value;
        LaserDamage = LaserDamage / Value;
        MissileFireDelay = MissileFireDelay * Value;
        NukeFireDelay = NukeFireDelay * Value;
        HomingMissileFireDelay = HomingMissileFireDelay * Value;
        MinigunFireDelay = MinigunFireDelay * Value;
        FlakFireDelay = FlakFireDelay * Value;
        DroneFireDelay = DroneFireDelay * Value;
        LaserFireDelay = LaserFireDelay * Value;
        MissileSpeed = MissileSpeed / Value;
        NukeSpeed = NukeSpeed / Value;
        HomingMissileSpeed = HomingMissileSpeed / Value;
        MinigunSpeed = MinigunSpeed / Value;
        FlakSpeed = FlakSpeed / Value;
        DroneSpeed = DroneSpeed / Value;
        LaserSpeed = LaserSpeed / Value;
    }
    public void SkillController(string SkillName, float Value = 0, bool Bool = false)
    {
        // float values
        if (SkillName == "Damage Boost")
            DamageBoost(Value);

        if (SkillName == "Speed Boost")
            SpeedBoost(Value);

        if (SkillName == "Larger Ammo Capacity")
            AmmoIncrease(Value);

        if (SkillName == "Life Steal")
            LifeSteal(Value);

        if (SkillName == "Health Boost")
            HealthBoost(Value);

        if (SkillName == "Attack Speed")
            AttackSpeed(Value);

        if (SkillName == "XP Buff")
            XPBuff(Value);

        if (SkillName == "Extra Life")
            ExtraLife(Value);

        if (SkillName == "Projectile Speed")
            ProjectileSpeed(Value);

        if (SkillName == "Bullet Spread")
            Spread(Value);

        if (SkillName == "increased burst amount")
            _BurstAmount(Value);

        if (SkillName == "decreased burst delay")
            _BurstDelay(Value);

        if (SkillName == "Array Delay")
            _ArrayDelay(Value);

        // booleans
        if (SkillName == "Double Shot")
            _DoubleShot(Bool);

        if (SkillName == "Backwards Fire")
            _BackwardsFire(Bool);

        if (SkillName == "Multishot")
            _MultiShot(Bool);

        if (SkillName == "Nuke")
            _Nuke(Bool);

        if (SkillName == "Flak")
            _Flak(Bool);
        
        if (SkillName == "Drone")
            _Drone(Bool);

        if (SkillName == "Homing Missile")
            _HomingMissile(Bool);

        if (SkillName == "Minigun")
            _MiniGun(Bool);

        if (SkillName == "Laser")
            _LaserGun(Bool);

        if (SkillName == "Rapid Fire")
            _RapidFire(Bool);

        if (SkillName == "Array Shot")
            _ArrayShot(Bool);

        if (SkillName == "Array Double Shot")
            _ArrayDoubleShot(Bool);


        // extra
        CurrentStamina = MaxStamina;
        CurrentHealth = MaxHealth;
    }

    // Upgradeable Skills

    void DamageBoost(float Value)
    {
        MissileDamage *= Value;
        NukeDamage *= Value;
        MinigunDamage *= Value;
        HomingMissileDamage *= Value;
        FlakDamage *= Value;
        DroneDamage *= Value;
        LaserDamage *= Value;
    }
    void SpeedBoost(float Value)
    {
        MoveSpeed *= Value;
    }
    void AmmoIncrease(float Value)
    {
        MaxStamina *= Value;
    }
    void LifeSteal(float Value)
    {
        lifesteal += Value - 1;
    }
    void HealthBoost(float Value)
    {
        MaxHealth *= Value;
    }
    void AttackSpeed(float Value)
    {
        MissileSpeed *= Value;
        NukeSpeed *= Value;
        MinigunSpeed *= Value;
        HomingMissileSpeed *= Value;
        FlakSpeed *= Value;
        DroneSpeed *= Value;
        LaserSpeed *= Value;
        ArrayShotSpeed *= Value;
    }
    void XPBuff(float Value)
    {
        ExpGain += Value;
    }
    void ExtraLife(float Value)
    {
        ExtraLives++;
    }
    void ProjectileSpeed(float Value)
    {
        MissileSpeed *= Value;
        NukeSpeed *= Value;
        MinigunSpeed *= Value;
        HomingMissileSpeed *= Value;
        FlakSpeed *= Value;
        DroneSpeed *= Value;
        LaserSpeed *= Value;
        ArrayShotSpeed *= Value;

    }
    void Spread(float Value)
    {
        // n/a
    }
    
    // Boolean Skills

    void _DoubleShot(bool Value)
    {
        DoubleShot = Value;
        DamageDebuff(1.4f);
    }
    void _BackwardsFire(bool Value)
    {
        BackwardsFire = Value;
        DamageDebuff(1.2f);
    }
    void _MultiShot(bool Value)
    {
        MultiShot = Value;
        DamageDebuff(1.4f);
    }
    void _Nuke(bool Value)
    {
        Nuke = Value;
        StatDebuff(1.5f);
    }    
    void _Flak(bool Value)
    {
        Flak = Value;
        StatDebuff(1.5f);
    }
    void _Drone(bool Value)
    {
        Drone = Value;
        StatDebuff(1.5f);
    }
    void _HomingMissile(bool Value)
    {
        HomingMissile = Value;
        StatDebuff(1.5f);
    }
    void _MiniGun(bool Value)
    {
        Minigun = Value;
        StatDebuff(1.5f);
    }
    void _LaserGun(bool Value)
    {
        Laser = Value;
        StatDebuff(1.5f);
    }

    // Class Specific Skills

    // Rapid Fire
    void _BurstAmount(float Value)
    {
        BurstAmount = Value;
    }
    void _BurstDelay(float Value)
    {
        BurstDelay /= Value;
    }
    void _RapidFire(bool Value)
    {
        RapidFire = Value;
    }
    

    // Idle Skills
    void _ArrayShot(bool Value)
    {
        ArrayShot = Value;
        DamageDebuff(1.4f);
    }
    void _ArrayDelay(float Value)
    {
        ArrayDelay /= Value;
    }
    void _ArrayDoubleShot(bool Value)
    {
        ArrayDoubleShot = Value;
        DamageDebuff(1.5f);
    }
}
