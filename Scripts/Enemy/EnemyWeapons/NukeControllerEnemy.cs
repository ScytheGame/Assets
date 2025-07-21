using System.Threading.Tasks;
using UnityEngine;

public class NukeControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] GameObject Parent;
    [SerializeField] private GameObject NukePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;
    [SerializeField] private EnemyController EnemyController;

    [SerializeField] private float NukeSpeed = 10f;
    [SerializeField] private float fireDelay = 5f;
    [SerializeField] private float StaminaPerShot = 50f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;
    [SerializeField] float ProjectileSpeedMultiplier;



    public EnemyController playerController;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
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
            Damage = EnemyController.NukeDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplier;
            ProjectileSpeedMultiplier = EnemyController.EnemyProjectileSpeedMultiplier;
            fireDelay /= AttackRateMultiplyer;
            NukeSpeed *= ProjectileSpeedMultiplier;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                if (!FirstShotShot)
                {
                    FireNuke(ProjectileSpawnPointLeft);
                    anim.SetTrigger("LeftWeaponShot");
                    FirstShotShot = true;
                    setDelayTimer = 0f;

                    canFire = false;

                    await Task.Delay(10);
                }
                else
                {
                    FireNuke(ProjectileSpawnPointRight);
                    anim.SetTrigger("RightWeaponShot");
                    FirstShotShot = false;
                    setDelayTimer = 0f;

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
            }
        }
    }


    private void FireNuke(Transform ProjectileSpawnPoint3)
    {
        if (playerController.enemyStamina < StaminaPerShot)
        {
            StaminaRegenEnemy StaminaRegenEnemy = Parent.GetComponent<StaminaRegenEnemy>();
            StaminaRegenEnemy.StartReloading();
        }
        else
        {
            playerController.enemyStamina -= StaminaPerShot;
            var Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
            Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
            Nuke.GetComponent<EnemyWeaponStats>().Damage = Random.Range(Damage - 150, Damage);

            System.Random rng = new System.Random();
            int randomValue = rng.Next(0, 5);
            if (randomValue >= 3)
            {
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
            }
        }
    }
}
