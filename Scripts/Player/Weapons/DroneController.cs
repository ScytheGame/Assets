using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DroneControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float DroneSpeed = 25f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 1.5f;
    [SerializeField] private float spread = 20f;
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
    int skillCheck = 0;
    public int spawnCount = 0;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        Damage = StatsController.DroneDamage;
        DroneSpeed = StatsController.DroneSpeed;
        fireDelay = StatsController.DroneFireDelay;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            if (Skill.usingMainWeaponDrone == true || Skill.usingMainWeaponDrone == true)
            {
                if (StatsController.DoubleShot)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(ProjectileSpawnPoint1);
                        SpawnPoint = ProjectileSpawnPoint1;
                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(ProjectileSpawnPoint2);
                        SpawnPoint = ProjectileSpawnPoint2;
                        delayTimer = 0f;
                    }
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    FireMissile(ProjectileSpawnPoint1);
                    SpawnPoint = ProjectileSpawnPoint1;
                    StatsController.CurrentStamina -= StaminaPerShot;
                    FireMissile(ProjectileSpawnPoint2);
                    SpawnPoint = ProjectileSpawnPoint2;
                    delayTimer = 0f;
                }
                FireBackwards();
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
        if (playerController.playerStamina < StaminaPerShot)
        {
            canFire = false;
            playerController.canReload = true;
        }
        else
        {
            if (spawnCount == 0)
            {
                AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * DroneSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
                spawnCount++;
                if (StatsController.DoubleShot == false)
                {
                    spawnCount = 0;
                }
            }
            else if (spawnCount == 1)
            {
                AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
                spawnCount++;
            }
            else if (spawnCount == 2)
            {
                AudioManager.PlaySFX(AudioManager.DroneShot, Source);
                var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -spread);
                var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

                Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
                spawnCount = 0;
            }
            canFire = false;
            if (StatsController.MultiShot)
            {
                StartCoroutine(FireMultiShot(SpawnPoint));
            }
        }
    }
    void FireBackwards()
    {
        if (StatsController.BackwardsFire == true)
        {
            AudioManager.PlaySFX(AudioManager.DroneShot, Source);
            var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, spread);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, offsetRotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * DroneSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
            AudioManager.PlaySFX(AudioManager.DroneShot, Source);
            offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -spread);
            Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, offsetRotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * DroneSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
        }
    }
    private IEnumerator FireMultiShot(Transform SpawnPoint)
    {
        yield return new WaitForSeconds(0.3f);
        if (spawnCount == 0)
        {
            AudioManager.PlaySFX(AudioManager.DroneShot, Source);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, SpawnPoint.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = SpawnPoint.up * DroneSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
            spawnCount++;
            if (StatsController.DoubleShot == false)
            {
                spawnCount = 0;
            }

        }
        else if (spawnCount == 1)
        {
            AudioManager.PlaySFX(AudioManager.DroneShot, Source);
            var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, spread);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

            Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
            spawnCount++;
        }
        else if (spawnCount == 2)
        {
            AudioManager.PlaySFX(AudioManager.DroneShot,Source);
            var offsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, -spread);
            var Missile = Instantiate(MissilePrefab, SpawnPoint.position, offsetRotation);

            Missile.GetComponent<Rigidbody2D>().linearVelocity = Missile.transform.up * DroneSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 15, Damage + 30);
            spawnCount = 0;
        }
        canFire = false;
        FireBackwards();
    }
}
