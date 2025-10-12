using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class StatsController : MonoBehaviour
{

    [SerializeField] SkillsController SkillsController;
    [Space(10)]
    [TabGroup("Player Stats")]
    public float MaxHealth = 2500;
    [TabGroup("Player Stats")]
    public float CurrentHealth = 2500;
    [TabGroup("Player Stats")]
    public float ExtraLives = 0;
    [TabGroup("Player Stats")]
    public float MaxAmmo = 100;
    [TabGroup("Player Stats")]
    public float CurrentAmmo = 100;
    [TabGroup("Player Stats")]
    public float MoveSpeed = 20;
    [TabGroup("Player Stats")]
    public float ExpGain = 20;

    [Space(10)]
    [TabGroup("Speed Boost Stats")]
    public float ShipSpeed = 20;
    [TabGroup("Speed Boost Stats")]
    public float BoostSpeed = 20;
    [TabGroup("Speed Boost Stats")]
    public float Damping = 1;
    [TabGroup("Speed Boost Stats")]
    public float ShipDamping = 1;
    [TabGroup("Speed Boost Stats")]
    public float BoostDamping = 0.1f;
    [TabGroup("Speed Boost Stats")]
    public float Mass = 1;
    [TabGroup("Speed Boost Stats")]
    public float ShipMass = 1;
    [TabGroup("Speed Boost Stats")]
    public float BoostMass = 0.1f;



    [Space(10)]
    [TabGroup("Level Stats")]
    public float TargetXP = 100;
    [TabGroup("Level Stats")]
    public float TargetXpIncrease = 15;
    [TabGroup("Level Stats")]
    public bool LeveledUp = false;
    [TabGroup("Level Stats")]
    public int CurrentLevel;
    [TabGroup("Level Stats")]
    public float CurrentXP = 0;

    [DictionaryDrawerSettings(KeyLabel = ("Weapon Name"), ValueLabel = ("Weapon")), ShowInInspector, BoxGroup("Weapons")]
    Dictionary<string, Weapon> WeaponList = new Dictionary<string, Weapon>();
    [SerializeField, BoxGroup("Weapons")] public Weapon ActiveWeapon;



    int skillCheck = 0;
    float buffAmount;
    int minutes;
    float expTimeBuff = 1;
    float expTime;
    float expTimeBuffCost = 1;
    float expTimeCost;
    float ExperienceGain = 20;
    int timeinterval = 5;

    public void Start()
    {
        Weapon[] TempWeaponList = Resources.LoadAll<Weapon>("Scriptable Objects/Weapons");

        foreach (Weapon Weapon in TempWeaponList)
        {
            WeaponList.Add(Weapon.WeaponName, Weapon);
        }

        SkillTreeData skillData = SkillTreeData.Load();

        MaxHealth = PlayerPrefs.GetFloat("PlayerHealth", 2500);
        MaxAmmo = PlayerPrefs.GetFloat("PlayerAmmo", 100);

        // Skill tree upgrades

        MoveSpeed *= skillData.SpeedBoost;

        MaxHealth += skillData.HealthBoost;

        MaxAmmo += skillData.AmmoBoost;

        ExperienceGain = skillData.ExperienceBoost;


        foreach(Weapon weaponType in TempWeaponList)
        {
            weaponType.DamageRange.y *= skillData.DamageBoost;
            weaponType.AttackSpeed /= skillData.AttackSpeed;
            weaponType.ProjectileSpeed *= skillData.ProjectileSpeed;
        }



        ExpGain = PlayerPrefs.GetFloat("PlayerXPGain", 20);
        TargetXpIncrease = PlayerPrefs.GetFloat("PlayerXPIncreaseCost", 15);
        expTimeBuffCost = PlayerPrefs.GetFloat("PlayerXPTimeCost", 1);
        ExpGain += ExperienceGain;
        CurrentHealth = MaxHealth;
        CurrentAmmo = MaxAmmo;
    }
    float LevelIncreaseCost = 10;
    public void Update()
    {
        SkillsController.PlayerLevel = CurrentLevel;

        if (minutes >= timeinterval)
        {
            expTime += expTimeBuff;
            expTimeCost += expTimeBuffCost;
            timeinterval += 2;
        }
        if (CurrentLevel >= LevelIncreaseCost)
        {
            TargetXpIncrease += LevelIncreaseCost / 10;
            LevelIncreaseCost += 10;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ShipSpeed = MoveSpeed + BoostSpeed;
            ShipDamping = BoostDamping;
            ShipMass = BoostMass;
        }
        else
        {
            ShipSpeed = MoveSpeed;
            ShipDamping = Damping;
            ShipMass = Mass;
        }
    }
    void DamageDebuff(float Value, Weapon Weapon)
    {
        Weapon.DamageRange.y = Weapon.DamageRange.y / Value;
    }
    void StatDebuff(float Value, Weapon Weapon)
    {
        Weapon.DamageRange.y = Weapon.DamageRange.y / Value;
        Weapon.AttackSpeed = Weapon.AttackSpeed * Value;
        Weapon.ProjectileSpeed = Weapon.ProjectileSpeed / Value;
    }
    public void SkillController(BaseSkillType SkillType, Weapon Weapon, float Value = 0, bool Bool = false)
    {
        switch (SkillType)
        {
            case BaseSkillType.None:
                break;

            case BaseSkillType.Damage: 
                DamageBoost(Value, Weapon); break;

            case BaseSkillType.Speed: 
                SpeedBoost(Value); break;

            case BaseSkillType.AmmoCapacity:
                AmmoIncrease(Value); break;

            case BaseSkillType.Health:
                HealthBoost(Value); break;
                
            case BaseSkillType.AttackSpeed:
                AttackSpeed(Value, Weapon); break;
                
            case BaseSkillType.Experience:
                ExperienceBuff(Value); break;
                
            case BaseSkillType.ExtraLife:
                ExtraLife(Value); break;
                
            case BaseSkillType.ProjectileSpeed:
                ProjectileSpeed(Value, Weapon); break;
                
            case BaseSkillType.DoubleShot:
                _DoubleShot(Bool, Weapon); break;
                
            case BaseSkillType.BackwardsFire:
                _BackwardsFire(Bool, Weapon); break;
                
            case BaseSkillType.MultiShot:
                _MultiShot(Bool, Weapon); break;
        }

        // extra
        CurrentAmmo = MaxAmmo;
        CurrentHealth = MaxHealth;
    }

    // Upgradeable Skills

    void DamageBoost(float Value, Weapon Weapon)
    {
        Weapon.DamageRange.y *= Value;
    }
    void SpeedBoost(float Value)
    {
        MoveSpeed *= Value;
    }
    void AmmoIncrease(float Value)
    {
        MaxAmmo *= Value;
    }
    void HealthBoost(float Value)
    {
        MaxHealth *= Value;
    }
    void AttackSpeed(float Value, Weapon Weapon)
    {
         Weapon.AttackSpeed /= Value;
    }
    void ExperienceBuff(float Value)
    {
        ExpGain += Value;
    }
    void ExtraLife(float Value)
    {
        ExtraLives++;
    }
    void ProjectileSpeed(float Value, Weapon Weapon)
    {
         Weapon.ProjectileSpeed *= Value;
    }
    
    // Boolean Skills

    void _DoubleShot(bool Value, Weapon Weapon)
    {
        Weapon.DoubleShot = Value;
        DamageDebuff(1.4f, Weapon);
    }
    void _BackwardsFire(bool Value, Weapon Weapon)
    {
        Weapon.BackwardsFire = Value;
        DamageDebuff(1.2f, Weapon);
    }
    void _MultiShot(bool Value, Weapon Weapon)
    {
        Weapon.MultiShot = Value;
        DamageDebuff(1.4f, Weapon);
    }
}
