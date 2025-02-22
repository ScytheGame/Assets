using System.Collections;
using UnityEngine;

public class HomingMissleControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private Transform ProjectileSpawnPoint4;
    [SerializeField] private GameObject MissilePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;

    [SerializeField] public float missileSpeed = 25f;
    [SerializeField] public float fireDelay = 0.5f;
    [SerializeField] private float StaminaPerShot = 15f;
    [SerializeField] float Damage; 

    public Skill Skill;
    public PlayerController playerController;
    public SkillsController SkillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        Damage = StatsController.HomingMissileDamage;
        missileSpeed = StatsController.HomingMissileSpeed;
        fireDelay = StatsController.HomingMissileFireDelay;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponHomingMissile == true || Skill.usingBackupWeaponHomingMissile == true)
                {
                    StaminaPerShot = 7.5f;
                    FireMissile();
                    canFire = false;
                    setDelayTimer = 0f;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponHomingMissile == true || Skill.usingBackupWeaponHomingMissile == true)
                {
                    StaminaPerShot = 15f;
                    FireMissile();
                    canFire = false;
                    setDelayTimer = 0f;
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
            if (StatsController.DoubleShot)
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint1.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint2.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                }
            }
            else
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                }
            }
            if (StatsController.MultiShot)
            {
                StartCoroutine(FireMultiShot());
            }
        }
    }
    private IEnumerator FireMultiShot()
    {
        yield return new WaitForSeconds(0.3f);
        if (StatsController.DoubleShot)
        {
            AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint1.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);

            AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
            Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint2.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage =  Random.Range(Damage - 100, Damage + 75);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
            }
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
            var Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
            Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * missileSpeed;
            Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
            }
        }
    }
}
