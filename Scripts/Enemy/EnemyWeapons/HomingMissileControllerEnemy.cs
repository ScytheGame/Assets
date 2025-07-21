using System.Threading.Tasks;
using UnityEngine;

public class HomingMissleControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] GameObject Parent;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] private float missileSpeed = 10f;
    [SerializeField] private float fireDelay = 1f;
    [SerializeField] private float StaminaPerShot = 15f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;
    [SerializeField] float ProjectileSpeedMultiplier;

    [SerializeField] public EnemyController PlayerController;
    [SerializeField] public EnemyController EnemyController;


    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
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
            Damage = EnemyController.HomingMissileDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplier;
            ProjectileSpeedMultiplier = EnemyController.EnemyProjectileSpeedMultiplier;
            fireDelay /= AttackRateMultiplyer;
            missileSpeed *= ProjectileSpeedMultiplier;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                if (!FirstShotShot)
                {
                    FireMissile(ProjectileSpawnPointLeft);
                    SpawnPoint = ProjectileSpawnPointLeft;
                    anim.SetTrigger("LeftWeaponShot");
                    setDelayTimer = 0f;
                    FirstShotShot = true;
                    canFire = false;
                    await Task.Delay(10);
                }
                else
                {
                    FireMissile(ProjectileSpawnPointRight);
                    SpawnPoint = ProjectileSpawnPointRight;
                    anim.SetTrigger("RightWeaponShot");
                    setDelayTimer = 0f;
                    FirstShotShot = false;
                    canFire = false;
                    await Task.Delay(10);
                }
            }
        }
        else
        {
            setDelayTimer += Time.deltaTime;

            if (setDelayTimer >= fireDelay)
            {
                canFire = true;
                setDelayTimer = 0;
            }
        }
    }


    private void FireMissile(Transform SpawnPoint)
    {
        if (PlayerController.enemyStamina < StaminaPerShot)
        {
            StaminaRegenEnemy StaminaRegenEnemy = Parent.GetComponent<StaminaRegenEnemy>();
            StaminaRegenEnemy.StartReloading();
        }
        else
        {
            PlayerController.enemyStamina -= StaminaPerShot;
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * missileSpeed;
            Missile.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 100, Damage);

            System.Random rng = new System.Random();
            int randomValue = rng.Next(0, 5);
            if (randomValue >= 3)
            {
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
            }
        }
    }
}
