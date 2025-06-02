using System.Collections;
using UnityEngine;

public class FlakControllerPlayer : MonoBehaviour
{

    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MissilePrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float FlakSpeed = 20f;
    [SerializeField] public float fireDelay = 1.5f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] private float Spread = 25f;
    [SerializeField] float Damage;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    public int spawnCount = 0;
    Animator anim;
    int FireCount = 0;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        Source = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Skill = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Skill>();

        playerController = GetComponentInParent<PlayerController>();
        skillsController = GetComponentInParent<SkillsController>();
        StatsController = GetComponentInParent<StatsController>();
        StaminaRegen = GetComponentInParent<StaminaRegen>();
    }

    void Update()
    {
        Damage = StatsController.FlakDamage;
        FlakSpeed = StatsController.FlakSpeed;
        fireDelay = StatsController.FlakFireDelay;
        StaminaPerShot = StatsController.FlakAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            if (Skill.usingMainWeaponFlak == true)
            {

                if (StatsController.DoubleShot == true)
                {
                    FireMissile(false, ProjectileSpawnPointLeft);
                    anim.SetTrigger("LeftWeaponShot");

                    FireMissile(false, ProjectileSpawnPointRight);
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        FireMissile(false, ProjectileSpawnPointBackLeft);
                        anim.SetTrigger("LeftWeaponShot");

                        FireMissile(false, ProjectileSpawnPointBackRight);
                        anim.SetTrigger("RightWeaponShot");
                    }
                }
                else
                {

                    if (FireCount == 0)
                    {
                        FireMissile(false, ProjectileSpawnPointLeft);
                        anim.SetTrigger("LeftWeaponShot");

                        if (StatsController.BackwardsFire == true)
                        {
                            FireMissile(false, ProjectileSpawnPointBackLeft);
                            anim.SetTrigger("LeftWeaponShot");
                        }
                        FireCount++;
                    }
                    else
                    {
                        FireMissile(false, ProjectileSpawnPointRight);
                        anim.SetTrigger("RightWeaponShot");

                        if (StatsController.BackwardsFire == true)
                        {
                            FireMissile(false, ProjectileSpawnPointBackRight);
                            anim.SetTrigger("RightWeaponShot");
                        }
                        FireCount = 0;
                    }
                }
                delayTimer = 0f;

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
        for (int i = 1; i <= 3; i++)
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

                canFire = false;
                if (StatsController.MultiShot && !SecondShot)
                {
                    StartCoroutine(FireMultiShot(SpawnPoint));
                }
            }
        }
    }
    private IEnumerator FireMultiShot(Transform SpawnPoint)
    {

        yield return new WaitForSeconds(0.3f);
        FireMissile(true, SpawnPoint);
    }
}
