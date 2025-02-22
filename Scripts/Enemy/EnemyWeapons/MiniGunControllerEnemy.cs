using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MiniGunControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private GameObject MiniGunPrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;
    [SerializeField] private EnemyController EnemyController;

    [SerializeField] private float BulletSpeed = 10f;
    [SerializeField] private float shotDelay = 0.05f;
    [SerializeField] private float fireDelay = 0.05f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;

    public EnemyController playerController;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    private bool EnemyDoubleShot = false;
    private int DoubleShot = 0;
    private float burst = 0f;
    private bool betweenBurst = false;
    private bool Loaded = false;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<EnemyController>();
        DoubleShot = UnityEngine.Random.Range(1, 3);
        if (DoubleShot >= 1.5)
        {
            EnemyDoubleShot = true;
        }
        else
        {
            EnemyDoubleShot = false;
        }
    }

    void Update()
    {

        if (!Loaded)
        {
            Damage = EnemyController.MinigunDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplyer;
            fireDelay /= AttackRateMultiplyer;
            Loaded = true;
        }
        if (burst >= 20)
        {
            betweenBurst = true;
        }
        if (burst <= 0)
        {
            betweenBurst = false;
        }
        if (betweenBurst == true)
        {
            canFire = false;
            burst -= Time.deltaTime * 20f;
        }
        if (betweenBurst == false)
        {
            canFire = true;
        }
        if (canFire == true)
        {
            if (EnemyDoubleShot)
            {
                if (EnemyController.isAttacking == true)
                {
                    StaminaPerShot = 0.75f;

                    if (!firedFirstBullet)
                    {
                        FireBullet(ProjectileSpawnPoint1);
                        SpawnPoint = ProjectileSpawnPoint1;
                        firedFirstBullet = true;
                        delayTimer = 0f;
                    }

                    if (firedFirstBullet)
                    {
                        delayTimer += Time.deltaTime;

                        if (delayTimer >= shotDelay)
                        {
                            FireBullet(ProjectileSpawnPoint2);
                            SpawnPoint = ProjectileSpawnPoint2;
                            firedFirstBullet = false;
                            setDelayTimer = 0f;
                            canFire = false;
                        }
                    }
                }
            }
            else
            {
                if (EnemyController.isAttacking == true)
                {
                    StaminaPerShot = 1f;
                    FireBullet(ProjectileSpawnPoint3);
                    SpawnPoint = ProjectileSpawnPoint3;
                    setDelayTimer = 0f;


                    canFire = false;
                }
            }
        }
        else
        {
            setDelayTimer += Time.deltaTime;

            if (setDelayTimer >= fireDelay)
            {
                canFire = true;
            }
        }
    }


    private void FireBullet(Transform SpawnPoint)
    {
        if (playerController.enemyStamina < StaminaPerShot)
        {
            canFire = false;
        }
        else
        {
            playerController.enemyStamina -= StaminaPerShot;
            var Bullet = Instantiate(MiniGunPrefab, SpawnPoint.position, SpawnPoint.rotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * BulletSpeed;
            Bullet.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 15, Damage);

            burst++;

            System.Random rng = new System.Random();
            int randomValue = rng.Next(0, 5);
            if (randomValue >= 3)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            }
        }
    }
}
