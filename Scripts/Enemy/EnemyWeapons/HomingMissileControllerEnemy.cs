using UnityEngine;

public class HomingMissleControllerEnemy : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] private float missileSpeed = 10f;
    [SerializeField] private float fireDelay = 1f;
    [SerializeField] private float StaminaPerShot = 15f;
    [SerializeField] float Damage;
    [SerializeField] float AttackRateMultiplyer;

    [SerializeField] public EnemyController PlayerController;
    [SerializeField] public EnemyController EnemyController;


    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
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
            Damage = EnemyController.HomingMissileDamage;
            AttackRateMultiplyer = EnemyController.EnemyAttackRateMultiplyer;
            fireDelay /= AttackRateMultiplyer;
            Loaded = true;
        }
        if (canFire == true)
        {
            if (EnemyController.isAttacking == true)
            {
                FireMissile(ProjectileSpawnPoint3);
                SpawnPoint = ProjectileSpawnPoint3;
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
                setDelayTimer = 0;
            }
        }
    }


    private void FireMissile(Transform SpawnPoint)
    {
        if (PlayerController.enemyStamina < StaminaPerShot)
        {
            canFire = false;
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
