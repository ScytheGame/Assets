using System.Diagnostics.Contracts;
using UnityEngine;

public class FlakControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float FlakSpeed = 20f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] private float Spread = 25f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;

    public EnemyController playerController;
    public EnemyController EnemyController;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    public int spawnCount = 0;
    private bool Loaded = false;


    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<EnemyController>();
    }

    void Update()
    {
        if (!Loaded)
        {
            Damage = EnemyController.FlakDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplyer;
            fireDelay /= AttackRateMultiplyer;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                for (int i = 1; i <= 3; i++)
                {
                    FireMissile(ProjectileSpawnPoint1);
                    SpawnPoint = ProjectileSpawnPoint1;
                    delayTimer = 0f;
                }
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
        if (playerController.enemyStamina < StaminaPerShot)
        {
            canFire = false;
        }
        else
        {
            if (spawnCount == 0)
            {
                playerController.enemyStamina -= StaminaPerShot;
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * FlakSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 50, Damage);
                spawnCount++;

                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                }
            }
            else if (spawnCount == 1)
            {
                playerController.enemyStamina -= StaminaPerShot;
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, Spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 50, Damage);
                spawnCount++;

                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                }
            }
            else if (spawnCount == 2)
            {
                playerController.enemyStamina -= StaminaPerShot;
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -Spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
                Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 50, Damage);
                spawnCount = 0;

                System.Random rng = new System.Random();
                int randomValue = rng.Next(0, 5);
                if (randomValue >= 3)
                {
                    AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                }
            }
            canFire = false;
        }
    }
}
