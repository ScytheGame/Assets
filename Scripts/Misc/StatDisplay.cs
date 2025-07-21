using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI MainDamage;
    [SerializeField] GameObject MainDamage1;
    [SerializeField] TextMeshProUGUI Ammo;
    [SerializeField] TextMeshProUGUI MainAttackSpeed;
    [SerializeField] GameObject MainAttackSpeed1;
    [SerializeField] TextMeshProUGUI MainProjectileSpeed;
    [SerializeField] GameObject MainProjectileSpeed1;
    [SerializeField] TextMeshProUGUI Speed;
    [SerializeField] TextMeshProUGUI LifeSteal;
    [SerializeField] TextMeshProUGUI ExtraLives;
    [SerializeField] TextMeshProUGUI ExpBuff;
    [SerializeField] TextMeshProUGUI EnemyCount;
    [SerializeField] TextMeshProUGUI killCount;

    [Space(10)]
    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] Skill Skill;
    [SerializeField] SkillsController skillController;
    [SerializeField] MissleControllerPlayer MissleControllerPlayer;
    [SerializeField] NukeControllerPlayer NukeControllerPlayer;
    [SerializeField] MiniGunControllerPlayer MiniGunControllerPlayer;
    [SerializeField] HomingMissleControllerPlayer HomingMissleControllerPlayer;
    [SerializeField] FlakControllerPlayer FlakControllerPlayer;
    [SerializeField] DroneControllerPlayer DroneControllerPlayer;
    [SerializeField] LaserGunControllerPlayer LaserGunControllerPlayer;
    [SerializeField] LevelsManager levelsManager;
    [SerializeField] StatsController StatsController;
    [SerializeField] RandomEnemySpawn RandomEnemySpawn;


    float MissileDamage;
    float NukeDamage;
    float MiniGunDamage;
    float HomingMissile;
    float Flak;
    float Drone;
    float Laser;
    float ExpGain;
    float enemyCount;
    float KillCount;

    private void Start()
    {
    }
    void Update()
    {
        MissileDamage = StatsController.MissileDamage;
        NukeDamage = StatsController.NukeDamage;
        MiniGunDamage = StatsController.MinigunDamage;
        HomingMissile = StatsController.HomingMissileDamage;
        Flak = StatsController.FlakDamage;
        Drone = StatsController.DroneDamage;
        Laser = StatsController.LaserDamage;
        ExpGain = StatsController.ExpGain;
        enemyCount = RandomEnemySpawn.enemyCount;
        KillCount = RandomEnemySpawn.KillCount;

        Health.text = "Health " + Mathf.Round(playerController.playerHealth) + "/" + playerController.maxHealth;
        Ammo.text = "Ammo " + Mathf.Round(playerController.playerStamina) + "/" + playerController.maxStamina;
        Speed.text = "Speed " + Mathf.Round(playerController.moveSpeed);
        LifeSteal.text = "Life Steal " + Mathf.Round(StatsController.lifeSteal * 10) / 10;
        ExtraLives.text = "Extra lives " + StatsController.ExtraLives;
        ExpBuff.text = "XP gain " + ExpGain;
        EnemyCount.text = "Enemy Count " + enemyCount;
        killCount.text = "Kill Count " + KillCount;

        if (Skill.mainWeapon == WeaponCode.None)
        {
            MainDamage1.SetActive(false);
            MainAttackSpeed1.SetActive(false);
            MainProjectileSpeed1.SetActive(false);
        }
        if (Skill.mainWeapon == WeaponCode.Missile)
        {
            MainWeaponDisplay(StatsController.MissileDamage, StatsController.MissileFireDelay, StatsController.MissileSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.Nuke)
        {
            MainWeaponDisplay(StatsController.NukeDamage, StatsController.NukeFireDelay, StatsController.NukeSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.MiniGun)
        {
            MainWeaponDisplay(StatsController.MinigunDamage, StatsController.MinigunFireDelay, StatsController.MinigunSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.HomingMissile)
        {
            MainWeaponDisplay(StatsController.HomingMissileDamage, StatsController.HomingMissileFireDelay, StatsController.HomingMissileSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.Flak)
        {
            MainWeaponDisplay(StatsController.FlakDamage, StatsController.FlakFireDelay, StatsController.FlakSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.Drone)
        {
            MainWeaponDisplay(StatsController.DroneDamage, StatsController.DroneFireDelay, StatsController.DroneSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.Laser)
        {
            MainWeaponDisplay(StatsController.LaserDamage, StatsController.LaserFireDelay, StatsController.LaserSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.MineHeavy)
        {
            MainWeaponDisplay(StatsController.MineHeavyDamage, StatsController.MineHeavyFireDelay, StatsController.MineHeavySpeed);
        }
        if (Skill.mainWeapon == WeaponCode.MineRapid)
        {
            MainWeaponDisplay(StatsController.MineRapidDamage, StatsController.MineRapidFireDelay, StatsController.MineRapidSpeed);
        }
        if (Skill.mainWeapon == WeaponCode.MineHoming)
        {
            MainWeaponDisplay(StatsController.MineHomingDamage, StatsController.MineHomingFireDelay, StatsController.MineHomingSpeed);
        }

    }

    void MainWeaponDisplay(float MainDamage, float MainAttackSpeed, float MainProjectileSpeed)
    {
        this.MainDamage.text = "Main Damage " + Mathf.Round(MainDamage);
        this.MainAttackSpeed.text = "Main Attack Speed " + Mathf.Round(MainAttackSpeed * 10) / 10 + "s";
        this.MainProjectileSpeed.text = "Main Projectile Speed " + Mathf.Round(MainProjectileSpeed * 10) / 10;
        MainDamage1.SetActive(true);
        MainAttackSpeed1.SetActive(true);
        MainProjectileSpeed1.SetActive(true);
    }
}
