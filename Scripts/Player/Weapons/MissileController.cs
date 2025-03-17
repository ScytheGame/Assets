using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MissleControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private Transform ProjectileSpawnPoint4;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float missileSpeed = 20f;
    [SerializeField] public float fireDelay = 1f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;

    public Skill Skill;
    public PlayerController playerController;
    public SkillsController skillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;

    private bool firedFirstMissile = false;
    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    private Transform SpawnPoint;
    public bool canFire = true;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
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

                if (Skill.usingMainWeaponMissile == true || Skill.usingBackupWeaponMissile == true)
                {
                    FireMissile();
                    firedFirstMissile = true;
                    setDelayTimer = 0f;
                    canFire = false;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponMissile == true || Skill.usingBackupWeaponMissile == true)
                {
                    FireMissile();
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
    private void FireMissile()
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
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint1.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint2.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

                if (StatsController.BackwardsFire == true)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                     Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                }
            }
            else
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

                if (StatsController.BackwardsFire == true)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                     Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
                }
            }
            if (StatsController.MultiShot == true)
            {
                StartCoroutine(FireMultiShot());
            }
        }
    }
    private IEnumerator FireMultiShot()
    {
        yield return new WaitForSeconds(0.3f);
        if (StatsController.DoubleShot == true)
        {
            AudioManager.PlaySFX(AudioManager.MissileShot, Source);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint1.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

            AudioManager.PlaySFX(AudioManager.MissileShot, Source);
            StatsController.CurrentStamina -= StaminaPerShot;
            Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint2.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            }
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.MissileShot, Source);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 50, Damage + 30);
            }
        }
    }
}
