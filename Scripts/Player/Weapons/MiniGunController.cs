using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGunControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private Transform ProjectileSpawnPoint4;
    [SerializeField] private GameObject MiniGunPrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float BulletSpeed = 30f;
    [SerializeField] private float shotDelay = 0.01f;
    [SerializeField] public float fireDelay = 0.01f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] public bool betweenBurst = false;
    [SerializeField] private float spread = 10;
    [SerializeField] float Damage;

    public Skill Skill;
    public PlayerController playerController;
    public SkillsController skillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    float SetBurstDelay;
    float BurstDelay;
    public bool canFire = true;
    public bool burstshot = false;
    private bool RapidFire = false;
    private float AngleOfSpread;
    float Burst = 0;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        Damage = StatsController.MinigunDamage;
        BulletSpeed = StatsController.MinigunSpeed;
        fireDelay = StatsController.MinigunFireDelay;
        SetBurstDelay = StatsController.BurstDelay;
        StaminaPerShot = StatsController.MinigunAmmoCost;

        if (RapidFire)
        {
            if (canFire && delayTimer >= fireDelay && !StaminaRegen.isReloading)
            {
                if (Skill.usingMainWeaponMiniGun || Skill.usingBackupWeaponMiniGun)
                {
                    FireBullet();
                    firedFirstBullet = true;
                    canFire = false;
                    delayTimer = 0f;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;

                if (delayTimer >= fireDelay)
                {
                    canFire = true;
                }
            }
        }
        else
        {
            if (Burst >= StatsController.BurstAmount)
            {
                BurstDelay = 0;
                Burst = 0;
            }
            if (BurstDelay > SetBurstDelay)
            {
                if (canFire && delayTimer >= fireDelay && !StaminaRegen.isReloading)
                {
                    if (Skill.usingMainWeaponMiniGun || Skill.usingBackupWeaponMiniGun)
                    {
                        FireBullet();
                        firedFirstBullet = true;
                        canFire = false;
                        delayTimer = 0f;
                    }
                }
                else
                {
                    delayTimer += Time.deltaTime;

                    if (delayTimer >= fireDelay)
                    {
                        canFire = true;
                    }
                }
            }
            else
            {
                BurstDelay += Time.deltaTime;
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
                AngleOfSpread = Random.Range(-spread, spread);
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                Burst++;

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-spread, spread);
                offsetRotation = ProjectileSpawnPoint2.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint2.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                Burst++;

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    Burst++;
                }
            }
            else
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-spread, spread);
                var offsetRotation = ProjectileSpawnPoint3.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint3.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                Burst++;

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    Burst++;
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
            AngleOfSpread = Random.Range(-spread, spread);
            var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint1.position, offsetRotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
            Burst++;

            AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            AngleOfSpread = Random.Range(-spread, spread);
            offsetRotation = ProjectileSpawnPoint2.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint2.position, offsetRotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
            Burst++;

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-spread, spread);
                offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                Burst++;
            }
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            AngleOfSpread = Random.Range(-spread, spread);
            var offsetRotation = ProjectileSpawnPoint3.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
            var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint3.position, offsetRotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
            Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
            Burst++;

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-spread, spread);
                offsetRotation = ProjectileSpawnPoint4.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPoint4.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                Burst++;
            }
        }

    }
}