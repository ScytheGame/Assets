using System.Threading.Tasks;
using UnityEngine;

public class DroneControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] GameObject Parent;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float DroneSpeed = 5f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 1.5f;
    [SerializeField] private float spread = 20f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplier;
    [SerializeField] float ProjectileSpeedMultiplier;

    public EnemyController EnemyController;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    public int spawnCount = 0;
    private bool Loaded = false;
    bool FirstShotShot = false;
    Animator anim;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        anim = Parent.GetComponent<Animator>();
        GetComponent<EnemyController>();

    }

    async void Update()
    {
        if (!Loaded)
        {
            Damage = EnemyController.DroneDamage;
            AttackRateMultiplier = EnemyController.EnemyAttackRateMultiplier;
            ProjectileSpeedMultiplier = EnemyController.EnemyProjectileSpeedMultiplier;
            fireDelay /= AttackRateMultiplier;
            DroneSpeed *= ProjectileSpeedMultiplier;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!FirstShotShot)
                    {
                        EnemyController.enemyStamina -= StaminaPerShot;
                        FireMissile(ProjectileSpawnPointLeft);
                        SpawnPoint = ProjectileSpawnPointLeft;
                        anim.SetTrigger("LeftWeaponShot");
                        FirstShotShot = true;

                        await Task.Delay(10);
                    }
                    else
                    {
                        EnemyController.enemyStamina -= StaminaPerShot;
                        FireMissile(ProjectileSpawnPointRight);
                        SpawnPoint = ProjectileSpawnPointRight;
                        anim.SetTrigger("RightWeaponShot");
                        FirstShotShot = false;

                        await Task.Delay(10);
                    }
                }
                delayTimer = 0f;
            }
        }
        else
        {
            setDelayTimer += Time.deltaTime;

            if (setDelayTimer >= fireDelay)
            {
                canFire = true;
                setDelayTimer = 0f;
            }
        }
    }

    private void FireMissile(Transform SpawnPoint)
    {
        if (EnemyController.enemyStamina < StaminaPerShot)
        {
            StaminaRegenEnemy StaminaRegenEnemy = Parent.GetComponent<StaminaRegenEnemy>();
            StaminaRegenEnemy.StartReloading();
        }
        else
        {
            if (spawnCount == 0)
            {
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * DroneSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 10, Damage);
                spawnCount++;

                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                }
            }
            if (spawnCount == 1)
            {
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 10, Damage);
                spawnCount++;
                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                }
            }
            if (spawnCount == 2)
            {
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 10, Damage);
                spawnCount = 0;

                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                }
            }
            canFire = false;
        }
    }
}
