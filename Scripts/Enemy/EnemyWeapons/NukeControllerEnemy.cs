using UnityEngine;

public class NukeControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint3;
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
                FireNuke(ProjectileSpawnPoint3);
                setDelayTimer = 0f;

                canFire = false;
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
            canFire = false;
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
