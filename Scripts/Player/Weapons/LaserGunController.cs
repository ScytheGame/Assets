using System.Collections;
using System.Reflection;
using UnityEngine;

public class LaserGunControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private Transform ProjectileSpawnPoint4;
    [SerializeField] private GameObject LaserPrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float BulletSpeed = 30f;
    [SerializeField] private float shotDelay = 0.01f;
    [SerializeField] public float fireDelay = 0.01f;
    [SerializeField] private float StaminaPerShot = 10f;
    [SerializeField] float Damage;

    public Skill Skill;
    public PlayerController playerController;
    public SkillsController skillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    public int Spread = 10;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        Damage = StatsController.LaserDamage;
        setDelayTimer = fireDelay;
        BulletSpeed = StatsController.LaserSpeed;
        fireDelay = StatsController.LaserFireDelay;
        StaminaPerShot = StatsController.LaserAmmoCost;

        if (canFire == true && delayTimer >= setDelayTimer && StaminaRegen.isReloading == false)
        {

            if (Skill.usingMainWeaponLaser == true || Skill.usingBackupWeaponLaser == true)
            {
                FireBullet();
                canFire = false;
                delayTimer = 0f;
            }
        }
        else
        {
            delayTimer += Time.deltaTime;

            if (delayTimer >= setDelayTimer)
            {
                canFire = true;
            }
        }
    }

    private void FireBullet()
    {
        if (StatsController.CurrentStamina < StaminaPerShot)
        {
            canFire = false;
            playerController.canReload = true;
        }
        else
        {
            if (StatsController.DoubleShot == true)
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                int AngleOfSpread = Random.Range(-Spread, Spread);
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-Spread, Spread);
                offsetRotation = ProjectileSpawnPoint2.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint2.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-Spread, Spread);
                    offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                }
            }
            else
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                int AngleOfSpread = Random.Range(-Spread, Spread);
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-Spread, Spread);
                    offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                }
            }
            if (StatsController.MultiShot)
            {
                StartCoroutine(FireMultiShot());
            }
        }
    }
    private IEnumerator FireMultiShot()
    {
        yield return new WaitForSeconds(0.3f);
        if (StatsController.DoubleShot == true)
        {
            AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            int AngleOfSpread = Random.Range(-Spread, Spread);
            var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint1.position, offsetRotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

            AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            AngleOfSpread = Random.Range(-Spread, Spread);
            offsetRotation = ProjectileSpawnPoint2.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint2.position, offsetRotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-Spread, Spread);
                offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
            }
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            int AngleOfSpread = Random.Range(-Spread, Spread);
            var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-Spread, Spread);
                offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(LaserPrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
            }
        }
    }
}
