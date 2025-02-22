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

        Health.text = "Health " + playerController.playerHealth + ":" + playerController.maxHealth;
        Ammo.text = "Ammo " + playerController.playerStamina + ":" + playerController.maxStamina;
        Speed.text = "Speed " + playerController.moveSpeed;
        LifeSteal.text = "Life Steal " + StatsController.lifesteal;
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
            MainDamage.text = "Main Damage " + MissileDamage;
            MainAttackSpeed.text = "Main Attack Speed " + MissleControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + MissleControllerPlayer.missileSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Nuke)
        {
            MainDamage.text = "Main Damage " + NukeDamage;
            MainAttackSpeed.text = "Main Attack Speed " + NukeControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + NukeControllerPlayer.NukeSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
            if (Skill.mainWeapon == Skill.WeaponCode.MiniGun)
        {
            MainDamage.text = "Main Damage " + MiniGunDamage;
            MainAttackSpeed.text = "Main Attack Speed " + MiniGunControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + MiniGunControllerPlayer.BulletSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.HomingMissile)
        {
            MainDamage.text = "Main Damage " + HomingMissile;
            MainAttackSpeed.text = "Main Attack Speed " + HomingMissleControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + HomingMissleControllerPlayer.missileSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Flak)
        {
            MainDamage.text = "Main Damage " + Flak;
            MainAttackSpeed.text = "Main Attack Speed " + FlakControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + FlakControllerPlayer.FlakSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Drone)
        {
            MainDamage.text = "Main Damage " + Drone;
            MainAttackSpeed.text = "Main Attack Speed " + DroneControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + DroneControllerPlayer.DroneSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.mainWeapon == Skill.WeaponCode.Laser)
        {
            MainDamage.text = "Main Damage " + Laser;
            MainAttackSpeed.text = "Main Attack Speed " + LaserGunControllerPlayer.fireDelay;
            MainProjectileSpeed.text = "Main Projectile Speed " + LaserGunControllerPlayer.BulletSpeed;
            MainDamage1.SetActive(true);
            MainAttackSpeed1.SetActive(true);
            MainProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.None)
        {
            SubDamage1.SetActive(false);
            SubAttackSpeed1.SetActive(false);
            SubProjectileSpeed1.SetActive(false);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Missile)
        {
            SubDamage.text = "Sub Damage " + MissileDamage;
            SubAttackSpeed.text = "Sub Attack Speed " + MissleControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + MissleControllerPlayer.missileSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Nuke)
        {
            SubDamage.text = "Sub Damage " + NukeDamage;
            SubAttackSpeed.text = "Sub Attack Speed " + NukeControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + NukeControllerPlayer.NukeSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.MiniGun)
        {
            SubDamage.text = "Sub Damage " + StatsController.MinigunDamage;
            SubAttackSpeed.text = "Sub Attack Speed " + MiniGunControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + MiniGunControllerPlayer.BulletSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.HomingMissile)
        {
            SubDamage.text = "Sub Damage " + HomingMissile;
            SubAttackSpeed.text = "Sub Attack Speed " + HomingMissleControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + HomingMissleControllerPlayer.missileSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Flak)
        {
            SubDamage.text = "Sub Damage " + Flak;
            SubAttackSpeed.text = "Sub Attack Speed " + FlakControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + FlakControllerPlayer.FlakSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Drone)
        {
            SubDamage.text = "Sub Damage " + Drone;
            SubAttackSpeed.text = "Sub Attack Speed " + DroneControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + DroneControllerPlayer.DroneSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }
        if (Skill.backupWeapon == Skill.WeaponCode.Laser)
        {
            SubDamage.text = "Sub Damage " + Laser;
            SubAttackSpeed.text = "Sub Attack Speed " + LaserGunControllerPlayer.fireDelay;
            SubProjectileSpeed.text = "Sub Projectile Speed " + LaserGunControllerPlayer.BulletSpeed;
            SubDamage1.SetActive(true);
            SubAttackSpeed1.SetActive(true);
            SubProjectileSpeed1.SetActive(true);
        }

    }
}
