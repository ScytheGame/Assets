using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MissleControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MissilePrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float missileSpeed = 20f;
    [SerializeField] public float fireDelay = 1f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    private bool firedFirstMissile = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;
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
        missileSpeed = StatsController.MissileSpeed;
        Damage = StatsController.MissileDamage;
        fireDelay = StatsController.MissileFireDelay;
        StaminaPerShot = StatsController.MissileAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {

            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponMissile == true)
                {
                    FireMissile(false);
                    firedFirstMissile = true;
                    setDelayTimer = 0f;
                    canFire = false;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponMissile == true)
                {
                    FireMissile(false);
                    setDelayTimer = 0f;

                    canFire = false;
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
    int FireCount = 0;
    private void FireMissile(bool SecondShot)
    {
        if (StatsController.CurrentStamina < StaminaPerShot)
        {
            canFire = false;
            playerController.canReload = true;
        }
        else
        {
            if (StatsController.DoubleShot == true)
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                anim.SetTrigger("LeftWeaponShot");

                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                anim.SetTrigger("RightWeaponShot");

                if (StatsController.BackwardsFire == true)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30); AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {
                if (FireCount == 0)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                    anim.SetTrigger("LeftWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                        StatsController.CurrentStamina -= StaminaPerShot;
                        Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * missileSpeed;
                        Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                        anim.SetTrigger("LeftWeaponShot");
                    }
                    FireCount++;
                }
                else
                {

                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                        StatsController.CurrentStamina -= StaminaPerShot;
                        Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * missileSpeed;
                        Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                        anim.SetTrigger("RightWeaponShot");
                    }
                    FireCount = 0;
                }
            }
            if (StatsController.MultiShot && !SecondShot)
            {
                StartCoroutine(FireMultiShot());
            }
        }
    }
    private IEnumerator FireMultiShot()
    {
        yield return new WaitForSeconds(0.3f);
        FireMissile(true);
    }
}
