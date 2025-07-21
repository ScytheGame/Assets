using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MiniGunControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] GameObject Parent;
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
    [SerializeField] float ProjectileSpeedMultiplier;

    public EnemyController playerController;


    private bool firedFirstBullet = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    private bool EnemyDoubleShot = false;
    private int DoubleShot = 0;
    private bool Loaded = false;
    Animator anim;
    async void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        anim = Parent.GetComponent<Animator>();
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

    async Task Update()
    {

        if (!Loaded)
        {
            Damage = EnemyController.MinigunDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplier;
            ProjectileSpeedMultiplier = EnemyController.EnemyProjectileSpeedMultiplier;
            fireDelay /= AttackRateMultiplyer;
            BulletSpeed *= ProjectileSpeedMultiplier;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                if (EnemyDoubleShot)
                {
                    StaminaPerShot = 0.75f;
                    FireBullet(ProjectileSpawnPointLeft);
                    anim.SetTrigger("LeftWeaponShot");

                    FireBullet(ProjectileSpawnPointRight);
                    anim.SetTrigger("RightWeaponShot");
                    setDelayTimer = 0;

                    canFire = false;

                    await Task.Delay(10);
                }

                else
                {
                    StaminaPerShot = 1f;
                    if (!firedFirstBullet)
                    {
                        FireBullet(ProjectileSpawnPointLeft);
                        anim.SetTrigger("LeftWeaponShot");
                        firedFirstBullet = true;

                        await Task.Delay(10);
                    }

                    else if (firedFirstBullet)
                    {
                        FireBullet(ProjectileSpawnPointRight);
                        anim.SetTrigger("RightWeaponShot");
                        firedFirstBullet = false;
                        setDelayTimer = 0f;
                        canFire = false;

                        await Task.Delay(10);
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


    private void FireBullet(Transform SpawnPoint)
    {
        if (playerController.enemyStamina < StaminaPerShot)
        {
            StaminaRegenEnemy StaminaRegenEnemy = Parent.GetComponent<StaminaRegenEnemy>();
            StaminaRegenEnemy.StartReloading();
        }
        else
        {
            playerController.enemyStamina -= StaminaPerShot;
            var Bullet = Instantiate(MiniGunPrefab, SpawnPoint.position, SpawnPoint.rotation);
            Bullet.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * BulletSpeed;
            Bullet.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 15, Damage);

            System.Random rng = new System.Random();
            int randomValue = rng.Next(0, 5);
            if (randomValue >= 3)
            {
                AudioManager.PlaySFX(AudioManager.MiniGunShot, Source);
            }
        }
    }
}
