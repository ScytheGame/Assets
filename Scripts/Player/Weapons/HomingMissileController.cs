using System.Collections;
using UnityEngine;

public class HomingMissleControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MissilePrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float missileSpeed = 25f;
    [SerializeField] public float fireDelay = 0.5f;
    [SerializeField] private float StaminaPerShot = 15f;
    [SerializeField] float Damage; 

    Skill Skill;
    PlayerController playerController;
    SkillsController SkillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    public float delayTimer = 0f;
    private float setDelayTimer = 0f;
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
        SkillsController = Player.GetComponent<SkillsController>();
        StatsController = Player.GetComponent<StatsController>();
        StaminaRegen = Player.GetComponent<StaminaRegen>();
    }

    void Update()
    {
        Damage = StatsController.HomingMissileDamage;
        missileSpeed = StatsController.HomingMissileSpeed;
        fireDelay = StatsController.HomingMissileFireDelay;
        StaminaPerShot = StatsController.HomingMissileAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponHomingMissile == true)
                {
                    FireMissile(false);
                    canFire = false;
                    setDelayTimer = 0f;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponHomingMissile == true)
                {
                    FireMissile(false);
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
            if (StatsController.DoubleShot)
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                anim.SetTrigger("LeftWeaponShot");

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                Missile = Instantiate(MissilePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * missileSpeed;
                Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                anim.SetTrigger("RightWeaponShot");

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {
                if (FireCount == 0)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                    anim.SetTrigger("LeftWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                        Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * missileSpeed;
                        Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                        anim.SetTrigger("LeftWeaponShot");
                    }
                    FireCount++;
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                    var Missile = Instantiate(MissilePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * missileSpeed;
                    Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.HomingMissileShot, Source);
                        Missile = Instantiate(MissilePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * missileSpeed;
                        Missile.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 100, Damage + 75);
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
