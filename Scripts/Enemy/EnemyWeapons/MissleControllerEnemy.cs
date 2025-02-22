using UnityEngine;
using static Unity.VisualScripting.Member;

public class MissileControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] public EnemyController EnemyController;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] private float missileSpeed = 10f;
    [SerializeField] private float shotDelay = 1f;
    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;

    private bool firedFirstMissile = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    private bool EnemyDoubleShot = false;
    private int DoubleShot = 0;
    private bool Loaded = false;


    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<EnemyController>();
        DoubleShot = UnityEngine.Random.Range(1, 3);
        if (DoubleShot >= 3)
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
            Damage = EnemyController.MissileDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplyer;
            fireDelay /= AttackRateMultiplyer;
            Loaded = true;
        }
        if (canFire == true)
        {
            StaminaPerShot = 3.5f;
            if (EnemyController.isAttacking == true)
            {
                if (!firedFirstMissile)
                {
                    FireMissile(ProjectileSpawnPoint1);
                    SpawnPoint = ProjectileSpawnPoint1;
                    firedFirstMissile = true;
                    delayTimer = 0f;
                }
                if (firedFirstMissile)
                {
                    delayTimer += Time.deltaTime;

                    if (delayTimer >= shotDelay)
                    {
                        FireMissile(ProjectileSpawnPoint2);
                        SpawnPoint = ProjectileSpawnPoint2;
                        firedFirstMissile = false;
                        setDelayTimer = 0f;
                        canFire = false;
                    }
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


    private void FireMissile(Transform SpawnPoint)
    {
        if (EnemyController.enemyStamina <= StaminaPerShot)
        {
            canFire = false;
        }
        else
        {
            EnemyController.enemyStamina -= StaminaPerShot;
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * missileSpeed;
            Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 50, Damage);

            System.Random rng = new System.Random();
            int randomValue = rng.Next(0, 5);
            if (randomValue >= 3)
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
            }
        }
    }
}
