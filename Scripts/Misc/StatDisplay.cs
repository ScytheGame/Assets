using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI MainDamage;
    [SerializeField] TextMeshProUGUI SubDamage;
    [SerializeField] GameObject MainDamage1;
    [SerializeField] GameObject SubDamage1;
    [SerializeField] TextMeshProUGUI Ammo;
    [SerializeField] TextMeshProUGUI MainAttackSpeed;
    [SerializeField] TextMeshProUGUI SubAttackSpeed;
    [SerializeField] GameObject MainAttackSpeed1;
    [SerializeField] GameObject SubAttackSpeed1;
    [SerializeField] TextMeshProUGUI MainProjectileSpeed;
    [SerializeField] TextMeshProUGUI SubProjectileSpeed;
    [SerializeField] GameObject MainProjectileSpeed1;
    [SerializeField] GameObject SubProjectileSpeed1;
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

        if (Skill.mainWeapon == Skill.WeaponCode.None)
        {
            MainDamage1.SetActive(false);
            MainAttackSpeed1.SetActive(false);
            MainProjectileSpeed1.SetActive(false);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Missile)
        {
            MainWeaponDisplay(StatsController.MissileDamage, StatsController.MissileFireDelay, StatsController.MissileSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Nuke)
        {
            MainWeaponDisplay(StatsController.NukeDamage, StatsController.NukeFireDelay, StatsController.NukeSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.MiniGun)
        {
            MainWeaponDisplay(StatsController.MinigunDamage, StatsController.MinigunFireDelay, StatsController.MinigunSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.HomingMissile)
        {
            MainWeaponDisplay(StatsController.HomingMissileDamage, StatsController.HomingMissileFireDelay, StatsController.HomingMissileSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Flak)
        {
            MainWeaponDisplay(StatsController.FlakDamage, StatsController.FlakFireDelay, StatsController.FlakSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Drone)
        {
            MainWeaponDisplay(StatsController.DroneDamage, StatsController.DroneFireDelay, StatsController.DroneSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Laser)
        {
            MainWeaponDisplay(StatsController.LaserDamage, StatsController.LaserFireDelay, StatsController.LaserSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.MineHeavy)
        {
            MainWeaponDisplay(StatsController.MineHeavyDamage, StatsController.MineHeavyFireDelay, StatsController.MineHeavySpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.MineRapid)
        {
            MainWeaponDisplay(StatsController.MineRapidDamage, StatsController.MineRapidFireDelay, StatsController.MineRapidSpeed);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.MineHoming)
        {
            MainWeaponDisplay(StatsController.MineHomingDamage, StatsController.MineHomingFireDelay, StatsController.MineHomingSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.None)
        {
            SubDamage1.SetActive(false);
            SubAttackSpeed1.SetActive(false);
            SubProjectileSpeed1.SetActive(false);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Missile)
        {
            BackupWeaponDisplay(MissileDamage, MissleControllerPlayer.fireDelay, MissleControllerPlayer.missileSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Nuke)
        {
            BackupWeaponDisplay(NukeDamage, NukeControllerPlayer.fireDelay, NukeControllerPlayer.NukeSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.MiniGun)
        {
            BackupWeaponDisplay(StatsController.MinigunDamage, MiniGunControllerPlayer.fireDelay, MiniGunControllerPlayer.BulletSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.HomingMissile)
        {
            BackupWeaponDisplay(HomingMissile, HomingMissleControllerPlayer.fireDelay, HomingMissleControllerPlayer.missileSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Flak)
        {
            BackupWeaponDisplay(Flak, FlakControllerPlayer.fireDelay, FlakControllerPlayer.FlakSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Drone)
        {
            BackupWeaponDisplay(Drone, DroneControllerPlayer.fireDelay, DroneControllerPlayer.DroneSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Laser)
        {
            BackupWeaponDisplay(Laser, LaserGunControllerPlayer.fireDelay, LaserGunControllerPlayer.BulletSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.MineHeavy)
        {
            BackupWeaponDisplay(StatsController.MineHeavyDamage, StatsController.MineHeavyFireDelay, StatsController.MineHeavySpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.MineRapid)
        {
            BackupWeaponDisplay(StatsController.MineRapidDamage, StatsController.MineRapidFireDelay, StatsController.MineRapidSpeed);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.MineHoming)
        {
            BackupWeaponDisplay(StatsController.MineHomingDamage, StatsController.MineHomingFireDelay, StatsController.MineHomingSpeed);
        }

    }

    void MainWeaponDisplay(float MainDamage, float MainAttackSpeed, float MainProjectileSpeed)
    {
        this.MainDamage.text = "Main Damage " + Mathf.Round(MainDamage);
        this.MainAttackSpeed.text = "Main Attack Speed " + Mathf.Round(MainAttackSpeed * 10) / 10 + "s";
        this.MainProjectileSpeed.text = "Main Projectile Speed " + Mathf.Round(MainProjectileSpeed * 10) / 10 + "s";
        MainDamage1.SetActive(true);
        MainAttackSpeed1.SetActive(true);
        MainProjectileSpeed1.SetActive(true);
    }
    void BackupWeaponDisplay(float SubDamage, float SubAttackSpeed, float SubProjectileSpeed)
    {
        this.SubDamage.text = "Sub Damage " + Mathf.Round(SubDamage);
        this.SubAttackSpeed.text = "Sub Attack Speed " + Mathf.Round(SubAttackSpeed * 10) / 10 + "s";
        this.SubProjectileSpeed.text = "Sub Projectile Speed " + Mathf.Round(SubProjectileSpeed * 10) / 10 + "s";
        SubDamage1.SetActive(true);
        SubAttackSpeed1.SetActive(true);
        SubProjectileSpeed1.SetActive(true);
    }
}
