using System.Threading.Tasks;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MissileControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] GameObject Parent;
    [SerializeField] public EnemyController EnemyController;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] private float missileSpeed = 10f;
    [SerializeField] private float shotDelay = 1f;
    [SerializeField] private float fireDelay = 0.5f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplier;
    [SerializeField] float ProjectileSpeedMultiplier;

    private bool firedFirstMissile = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    private bool EnemyDoubleShot = false;
    private int DoubleShot = 0;
    private bool Loaded = false;
    Animator anim;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        anim = Parent.GetComponent<Animator>();
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

    async void Update()
    {
        if (!Loaded)
        {
            Damage = EnemyController.MissileDamage;
            AttackRateMultiplier = EnemyController.EnemyAttackRateMultiplier;
            ProjectileSpeedMultiplier = EnemyController.EnemyProjectileSpeedMultiplier;
            fireDelay /= AttackRateMultiplier;
            missileSpeed *= ProjectileSpeedMultiplier;
            Loaded = true;
        }
        if (canFire == true)
        {
            StaminaPerShot = 3.5f;
            if (EnemyController.isAttacking == true)
            {
                if (EnemyDoubleShot)
                {
                    FireMissile(ProjectileSpawnPointLeft);
                    SpawnPoint = ProjectileSpawnPointLeft;
                    anim.SetTrigger("LeftWeaponShot");

                    FireMissile(ProjectileSpawnPointRight);
                    SpawnPoint = ProjectileSpawnPointRight;
                    anim.SetTrigger("RightWeaponShot");
                    delayTimer = 0f;

                    await Task.Delay(10);
                }
                else
                {
                    if (!firedFirstMissile)
                    {
                        FireMissile(ProjectileSpawnPointLeft);
                        SpawnPoint = ProjectileSpawnPointLeft;
                        anim.SetTrigger("LeftWeaponShot");
                        firedFirstMissile = true;
                        delayTimer = 0f;

                        await Task.Delay(10);
                    }
                    else if (firedFirstMissile)
                    {
                        delayTimer += Time.deltaTime;

                        if (delayTimer >= shotDelay)
                        {
                            FireMissile(ProjectileSpawnPointRight);
                            SpawnPoint = ProjectileSpawnPointRight;
                            anim.SetTrigger("RightWeaponShot");
                            firedFirstMissile = false;
                            setDelayTimer = 0f;
                            canFire = false;
                            
                            await Task.Delay(10);
                        }
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
            StaminaRegenEnemy StaminaRegenEnemy = Parent.GetComponent<StaminaRegenEnemy>();
            StaminaRegenEnemy.StartReloading();
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
