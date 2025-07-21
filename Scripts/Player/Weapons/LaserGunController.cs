using System.Collections;
using System.Reflection;
using UnityEngine;

public class LaserGunControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject LaserPrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float BulletSpeed = 30f;
    [SerializeField] private float shotDelay = 0.01f;
    [SerializeField] public float fireDelay = 0.01f;
    [SerializeField] private float StaminaPerShot = 10f;
    [SerializeField] float Damage;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    public int Spread = 10;
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
        Damage = StatsController.LaserDamage;
        setDelayTimer = fireDelay;
        BulletSpeed = StatsController.LaserSpeed;
        fireDelay = StatsController.LaserFireDelay;
        StaminaPerShot = StatsController.LaserAmmoCost;

        if (canFire == true && delayTimer >= setDelayTimer && StaminaRegen.isReloading == false)
        {

            if (Skill.usingMainWeaponLaser == true)
            {
                FireBullet(false);
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
                int AngleOfSpread = Random.Range(-Spread, Spread);
                var offsetRotation = ProjectileSpawnPointLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointLeft.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                anim.SetTrigger("LeftWeaponShot");

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                AngleOfSpread = Random.Range(-Spread, Spread);
                offsetRotation = ProjectileSpawnPointRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointRight.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                anim.SetTrigger("RightWeaponShot");

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-Spread, Spread);
                    offsetRotation = ProjectileSpawnPointBackLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointBackLeft.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    AngleOfSpread = Random.Range(-Spread, Spread);
                    offsetRotation = ProjectileSpawnPointBackRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointBackRight.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {
                if (FireCount == 0)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    int AngleOfSpread = Random.Range(-Spread, Spread);
                    var offsetRotation = ProjectileSpawnPointLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointLeft.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                    anim.SetTrigger("LeftWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                        AngleOfSpread = Random.Range(-Spread, Spread);
                        offsetRotation = ProjectileSpawnPointBackLeft.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                        Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointBackLeft.position, offsetRotation);
                        Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                        anim.SetTrigger("LeftWeaponShot");
                    }
                    FireCount++;
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                    int AngleOfSpread = Random.Range(-Spread, Spread);
                    var offsetRotation = ProjectileSpawnPointRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                    var Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointRight.position, offsetRotation);
                    Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
                        AngleOfSpread = Random.Range(-Spread, Spread);
                        offsetRotation = ProjectileSpawnPointBackRight.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                        Bullet = Instantiate(LaserPrefab, ProjectileSpawnPointBackRight.position, offsetRotation);
                        Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Bullet.GetComponent<PlayerWeaponStats>().Damage = Damage;
                        anim.SetTrigger("RightWeaponShot");
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
