using System.Collections;
using UnityEngine;

public class FlakControllerPlayer : MonoBehaviour
{

    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float FlakSpeed = 20f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] private float Spread = 25f;
    [SerializeField] float Damage;

    public Skill Skill;
    public PlayerController playerController;
    public SkillsController skillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
    public int spawnCount = 0;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        Damage = StatsController.FlakDamage;
        FlakSpeed = StatsController.FlakSpeed;
        fireDelay = StatsController.FlakFireDelay;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            if (Skill.usingMainWeaponFlak == true || Skill.usingBackupWeaponFlak == true) 
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
        if (StatsController.CurrentStamina < StaminaPerShot)
        {
            canFire = false;
            playerController.canReload = true;
        }
        else
        {
            if (spawnCount == 0)
            {
                AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * FlakSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                spawnCount++;
            }
            if (spawnCount == 1)
            {
                AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                playerController.playerStamina -= StaminaPerShot;
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, Spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                spawnCount++;
            }
            if (spawnCount == 2)
            {
                AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                playerController.playerStamina -= StaminaPerShot;
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -Spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                spawnCount = 0;
            }

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.FlakShot, Source);
                playerController.playerStamina -= StaminaPerShot;
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            }
            canFire = false;
            if (StatsController.MultiShot)
            {
                StartCoroutine(FireMultiShot(ProjectileSpawnPoint1));
            }
        }
    }
    private IEnumerator FireMultiShot(Transform SpawnPoint)
    {

        yield return new WaitForSeconds(0.3f);
        if (spawnCount == 0)
        {
            AudioManager.PlaySFX(AudioManager.FlakShot, Source);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * FlakSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            spawnCount++;
        }
        if (spawnCount == 1)
        {
            AudioManager.PlaySFX(AudioManager.FlakShot, Source);
            var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, Spread);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

            Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            spawnCount++;
        }
        if (spawnCount == 2)
        {
            AudioManager.PlaySFX(AudioManager.FlakShot, Source);
            var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -Spread);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

            Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            spawnCount = 0;
        }

        if (StatsController.BackwardsFire == true)
        {
            AudioManager.PlaySFX(AudioManager.FlakShot, Source);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);

            Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * FlakSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
        }
        canFire = false;

    }
}
