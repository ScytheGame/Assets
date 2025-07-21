using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class MineControllerWeaponHoming : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject MinePrefab;
    private AudioManager AudioManager;
    AudioSource Source;

    [SerializeField] public float MineSpeed = 20f;
    [SerializeField] public float fireDelay = 1f;
    [SerializeField] private float StaminaPerShot = 5f;
    [SerializeField] float Damage;
    [SerializeField] float ExplosionRadius;

    Skill Skill;
    PlayerController playerController;
    SkillsController skillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    private bool firedFirstMine = false;
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
        MineSpeed = StatsController.MineHomingSpeed;
        Damage = StatsController.MineHomingDamage;
        fireDelay = StatsController.MineHomingFireDelay;
        ExplosionRadius = StatsController.MineHomingExplosionRadius;
        if (canFire == true && StaminaRegen.isReloading == false)
        {

            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponMineHoming == true)
                {
                    FireMissile(false);
                    firedFirstMine = true;
                    setDelayTimer = 0f;
                    canFire = false;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponMineHoming == true)
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
                var Missile = Instantiate(MinePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                Missile.GetComponent<MineController>().Size = ExplosionRadius;
                anim.SetTrigger("LeftWeaponShot");

                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                StatsController.CurrentStamina -= StaminaPerShot;
                Missile = Instantiate(MinePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                Missile.GetComponent<MineController>().Size = ExplosionRadius;
                anim.SetTrigger("RightWeaponShot");

                if (StatsController.BackwardsFire == true)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    Missile = Instantiate(MinePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                    Missile.GetComponent<MineController>().Size = ExplosionRadius;
                    anim.SetTrigger("LeftWeaponShot");

                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    Missile = Instantiate(MinePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                    Missile.GetComponent<MineController>().Size = ExplosionRadius;
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {
                if (FireCount == 0)
                {
                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    var Missile = Instantiate(MinePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                    Missile.GetComponent<MineController>().Size = ExplosionRadius;
                    anim.SetTrigger("LeftWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                        StatsController.CurrentStamina -= StaminaPerShot;
                        Missile = Instantiate(MinePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                        Missile.GetComponent<MineController>().Size = ExplosionRadius;
                        anim.SetTrigger("LeftWeaponShot");
                    }
                    FireCount++;
                }
                else
                {

                    AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                    StatsController.CurrentStamina -= StaminaPerShot;
                    var Missile = Instantiate(MinePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                    Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                    Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                    Missile.GetComponent<MineController>().Size = ExplosionRadius;
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                        StatsController.CurrentStamina -= StaminaPerShot;
                        Missile = Instantiate(MinePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                        Missile.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * MineSpeed + (Vector3)playerController.GetPlayerForwardVelocity();
                        Missile.GetComponent<MineController>().Damage = Random.Range(Damage - 50, Damage + 30);
                        Missile.GetComponent<MineController>().Size = ExplosionRadius;
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