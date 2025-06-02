using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DroneControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MissilePrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float DroneSpeed = 25f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 1.5f;
    [SerializeField] private float spread = 20f;
    [SerializeField] float Damage;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    int skillCheck = 0;
    public int spawnCount = 0;
    Animator anim;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        Source = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Skill = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Skill>();

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        skillsController = Player.GetComponent<SkillsController>();
        StatsController = Player.GetComponent<StatsController>();
        StaminaRegen = Player.GetComponent<StaminaRegen>();
    }

    void Update()
    {
        Damage = StatsController.DroneDamage;
        DroneSpeed = StatsController.DroneSpeed;
        fireDelay = StatsController.DroneFireDelay;
        StaminaPerShot = StatsController.DroneAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            if (Skill.usingMainWeaponDrone == true)
            {
                if (StatsController.DoubleShot)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(false, ProjectileSpawnPointLeft);
                        anim.SetTrigger("LeftWeaponShot");

                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(false, ProjectileSpawnPointRight);
                        anim.SetTrigger("RightWeaponShot");

                        if (StatsController.BackwardsFire)
                        {
                            StatsController.CurrentStamina -= StaminaPerShot;
                            FireMissile(false, ProjectileSpawnPointBackLeft);
                            anim.SetTrigger("LeftWeaponShot");

                            StatsController.CurrentStamina -= StaminaPerShot;
                            FireMissile(false, ProjectileSpawnPointBackRight);
                            anim.SetTrigger("RightWeaponShot");
                        }
                        delayTimer = 0f;
                    }
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    FireMissile(false, ProjectileSpawnPointLeft);
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    FireMissile(false, ProjectileSpawnPointRight);
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(false, ProjectileSpawnPointBackLeft);
                        anim.SetTrigger("LeftWeaponShot");

                        StatsController.CurrentStamina -= StaminaPerShot;
                        FireMissile(false, ProjectileSpawnPointBackRight);
                        anim.SetTrigger("RightWeaponShot");
                    }
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
    private void FireMissile(bool SecondShot, Transform SpawnPoint)
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
            if (StatsController.MultiShot && !SecondShot)
            {
                StartCoroutine(FireMultiShot(SpawnPoint));
            }
        }
    }
    private IEnumerator FireMultiShot(Transform SpawnPoint)
    {
        yield return new WaitForSeconds(0.3f);
        FireMissile(true, SpawnPoint);
    }
}
