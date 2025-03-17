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
    public float DroneDamage = 280;
    [TabGroup("Weapon Damage")]
    public float LaserDamage = 150;
    [TabGroup("Weapon Damage")]
    public float MineHeavyDamage = 350;
    [TabGroup("Weapon Damage")]
    public float MineHomingDamage = 350;
    [TabGroup("Weapon Damage")]
    public float MineRapidDamage = 350;
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
    public float MineHeavySpeed = 5;
    [TabGroup("Weapon Stats")]
    public float MineRapidSpeed = 15;
    [TabGroup("Weapon Stats")]
    public float MineHomingSpeed = 10;
    [TabGroup("Weapon Stats")]
    public float MineHeavyFireDelay = 2.5f;
    [TabGroup("Weapon Stats")]
    public float MineRapidFireDelay = 0.9f;
    [TabGroup("Weapon Stats")]
    public float MineHomingFireDelay = 1.5f;
    [TabGroup("Weapon Stats")]
    public float MissileAmmoCost = 5f;
    [TabGroup("Weapon Stats")]
    public float NukeAmmoCost = 50f;
    [TabGroup("Weapon Stats")]
    public float FlakAmmoCost = 5f;
    [TabGroup("Weapon Stats")]
    public float MinigunAmmoCost = 5f;
    [TabGroup("Weapon Stats")]
    public float LaserAmmoCost = 10f;
    [TabGroup("Weapon Stats")]
    public float DroneAmmoCost = 1.5f;
    [TabGroup("Weapon Stats")]
    public float HomingMissileAmmoCost = 15f;
    [TabGroup("Weapon Stats")]
    public float MineHeavyAmmoCost = 20f;
    [TabGroup("Weapon Stats")]
    public float MineRapidAmmoCost = 5f;
    [TabGroup("Weapon Stats")]
    public float MineHomingAmmoCost = 10f;
    [TabGroup("Weapon Stats")]
    public float MineHeavyExplosionRadius = 20f;
    [TabGroup("Weapon Stats")]
    public float MineRapidExplosionRadius = 5f;
    [TabGroup("Weapon Stats")]
    public float MineHomingExplosionRadius = 10f;

    public float lifeSteal = 0;


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
    public bool MineHeavy;
    [TabGroup("Bool Skills")]
    public bool MineRapid;
    [TabGroup("Bool Skills")]
    public bool MineHoming;

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
        SkillTreeData skillData = SkillTreeData.Load();

        MaxHealth = PlayerPrefs.GetFloat("PlayerHealth", 2500);
        MaxStamina = PlayerPrefs.GetFloat("PlayerAmmo", 100);

        // Skill tree upgrades

        MoveSpeed *= skillData.SpeedBoost;

        MaxHealth += skillData.HealthBoost;

        MaxStamina += skillData.AmmoBoost;

        expGain = skillData.ExperienceBoost;

        // Damage 
        MissileDamage *= skillData.DamageBoostMissile;
        NukeDamage *= skillData.DamageBoostNuke;
        MinigunDamage *= skillData.DamageBoostMinigun;
        HomingMissileDamage *= skillData.DamageBoostHomingMissile;
        FlakDamage *= skillData.DamageBoostFlak;
        DroneDamage *= skillData.DamageBoostDrone;
        LaserDamage *= skillData.DamageBoostLaser;

        // Attack Speed
        MissileFireDelay /= skillData.AttackSpeedMissile;
        NukeFireDelay /= skillData.AttackSpeedNuke;
        MinigunFireDelay /= skillData.AttackSpeedMinigun;
        HomingMissileFireDelay /= skillData.AttackSpeedHomingMissile;
        FlakFireDelay /= skillData.AttackSpeedFlak;
        DroneFireDelay /= skillData.AttackSpeedDrone;
        LaserFireDelay /= skillData.AttackSpeedLaser;

        // Projectile Speed
        MissileSpeed *= skillData.ProjectileSpeedMissile;
        NukeSpeed *= skillData.ProjectileSpeedNuke;
        MinigunSpeed *= skillData.ProjectileSpeedMinigun;
        HomingMissileSpeed *= skillData.ProjectileSpeedHomingMissile;
        FlakSpeed *= skillData.ProjectileSpeedFlak;
        DroneSpeed *= skillData.ProjectileSpeedDrone;
        LaserSpeed *= skillData.ProjectileSpeedLaser;
        // other
        DamageBonus += PlayerPrefs.GetFloat("PlayerDamageBonus", 1);
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
        ExpGain += expGain;
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
    }
    float LevelIncreaseCost = 10;
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
        if (currentLevel >= LevelIncreaseCost)
        {
            targetXpIncrease += LevelIncreaseCost / 10;
            LevelIncreaseCost += 10;
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

        if (SkillName == "Heavy Mine")
            _MineHeavy(Bool);

        if (SkillName == "Rapid Mine")
            _MineRapid(Bool);

        if (SkillName == "Homing Mine")
            _MineHoming(Bool);

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
        MissileAmmoCost *= Value / 2;
        NukeAmmoCost *= Value / 2;
        FlakAmmoCost *= Value / 2;
        MinigunAmmoCost *= Value / 2;
        LaserAmmoCost *= Value / 2;
        DroneAmmoCost *= Value / 2;
        HomingMissileAmmoCost *= Value / 2;
        MineHeavyDamage *= Value;
        MineRapidDamage *= Value;
        MineHomingDamage *= Value;
        MineHeavyAmmoCost *= Value / 2;
        MineRapidAmmoCost *= Value / 2;
        MineHomingAmmoCost *= Value / 2;
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
        lifeSteal += Value - 1;
    }
    void HealthBoost(float Value)
    {
        MaxHealth *= Value;
    }
    void AttackSpeed(float Value)
    {
        MissileFireDelay *= Value;
        NukeFireDelay *= Value;
        MinigunFireDelay *= Value;
        HomingMissileFireDelay *= Value;
        FlakFireDelay *= Value;
        DroneFireDelay *= Value;
        LaserFireDelay *= Value;
        MineHeavyFireDelay *= Value;
        MineRapidFireDelay *= Value;
        MineHomingFireDelay *= Value;
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
        MineHeavySpeed *= Value;
        MineRapidSpeed *= Value;
        MineHomingSpeed *= Value;

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
    void _MineHeavy(bool Value)
    {
        MineHeavy = Value;
        StatDebuff(1.5f);
    }
    void _MineRapid(bool Value)
    {
        MineRapid = Value;
        StatDebuff(1.5f);
    }
    void _MineHoming(bool Value)
    {
        MineHoming = Value;
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
