using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGunControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MiniGunPrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float BulletSpeed = 30f;
    [SerializeField] private float shotDelay = 0.01f;
    [SerializeField] public float fireDelay = 0.01f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] public bool betweenBurst = false;
    [SerializeField] private float spread = 10;
    [SerializeField] float Damage;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    float SetBurstDelay;
    float BurstDelay;
    public bool canFire = true;
    public bool burstshot = false;
    private bool RapidFire = false;
    private float AngleOfSpread;
    float Burst = 0;
    Animator anim;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        Source = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Skill = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Skill>();

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        skillsController = Player.GetComponent<SkillsController>();
        StatsController = Player.GetComponent<StatsController>();
        StaminaRegen = Player.GetComponent<StaminaRegen>();
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
                if (Skill.usingMainWeaponMiniGun)
                {
                    FireBullet(false);
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
                    if (Skill.usingMainWeaponMiniGun)
                    {
                        FireBullet(false);
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
    int FireCount = 0;
    private void FireBullet(bool SecondShot)
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
                var offsetRotation = ProjectileSpawnPointLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointLeft.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                anim.SetTrigger("LeftWeaponShot");
                Burst++;

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-spread, spread);
                offsetRotation = ProjectileSpawnPointRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointRight.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                anim.SetTrigger("RightWeaponShot");
                Burst++;

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    offsetRotation = ProjectileSpawnPointBackLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointBackLeft.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    offsetRotation = ProjectileSpawnPointBackRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointBackRight.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {
                if (FireCount == 0)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    var offsetRotation = ProjectileSpawnPointLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointLeft.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    anim.SetTrigger("LeftWeaponShot");
                    Burst++;

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                        AngleOfSpread = Random.Range(-spread, spread);
                        offsetRotation = ProjectileSpawnPointBackLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                        Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointBackLeft.position, offsetRotation);
                        Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                        anim.SetTrigger("LeftWeaponShot");
                        Burst++;
                    }
                    FireCount++;
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-spread, spread);
                    var offsetRotation = ProjectileSpawnPointRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    var Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointRight.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                    anim.SetTrigger("RightWeaponShot");
                    Burst++;

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                        AngleOfSpread = Random.Range(-spread, spread);
                        offsetRotation = ProjectileSpawnPointBackRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                        Bullet = Instantiate(MiniGunPrefab, ProjectileSpawnPointBackRight.position, offsetRotation);
                        Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 10, Damage + 30);
                        anim.SetTrigger("RightWeaponShot");
                        Burst++;
                    }
                    FireCount = 0;
                }
            }
            if (StatsController.MultiShot && !SecondShot)
            {
                StartCoroutine(FireMultiShot());
            }
        }
    }
    private IEnumerator FireMultiShot()
    {
        yield return new WaitForSeconds(0.3f);
        FireBullet(true);
    }
}