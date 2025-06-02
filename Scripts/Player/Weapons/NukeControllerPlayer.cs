using System.Collections;
using System.Reflection;
using UnityEngine;

public class NukeControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPointLeft;
    [SerializeField] private Transform ProjectileSpawnPointRight;
    [SerializeField] private Transform ProjectileSpawnPointBackLeft;
    [SerializeField] private Transform ProjectileSpawnPointBackRight;
    [SerializeField] private GameObject NukePrefab;
    private AudioManager AudioManager;
    AudioSource Source;
 
    [SerializeField] public float NukeSpeed = 16f;
    [SerializeField] public float fireDelay = 4f;
    [SerializeField] private float StaminaPerShot = 50f;
    [SerializeField] float Damage;

    GameObject Player;

    Skill Skill;
    PlayerController playerController;
    SkillsController SkillsController;
    StatsController StatsController;
    StaminaRegen StaminaRegen;

    private bool firedFirstMissile;
    private float delayTimer = 0f;
    private float setDelayTimer = 0f;
    public bool canFire = true;
    Animator anim;
    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        Source = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        Skill = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Skill>();

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        SkillsController = Player.GetComponent<SkillsController>();
        StatsController = Player.GetComponent<StatsController>();
        StaminaRegen = Player.GetComponent<StaminaRegen>();
    }

    void Update()
    {
        Damage = StatsController.NukeDamage;
        NukeSpeed = StatsController.NukeSpeed;
        fireDelay = StatsController.NukeFireDelay;
        StaminaPerShot = StatsController.NukeAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponNuke == true)
                {
                    FireNuke(false);
                    canFire = false;
                    setDelayTimer = 0f;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponNuke == true)
                {
                    FireNuke(false);
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
    private void FireNuke(bool SecondShot)
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
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                var Nuke = Instantiate(NukePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                anim.SetTrigger("LeftWeaponShot");


                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                Nuke = Instantiate(NukePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                anim.SetTrigger("RightWeaponShot");

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    Nuke = Instantiate(NukePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                    anim.SetTrigger("LeftWeaponShot");

                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    Nuke = Instantiate(NukePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                    anim.SetTrigger("RightWeaponShot");
                }
            }
            else
            {

                if (FireCount == 0)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    var Nuke = Instantiate(NukePrefab, ProjectileSpawnPointLeft.position, ProjectileSpawnPointLeft.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointLeft.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                    anim.SetTrigger("LeftWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                        Nuke = Instantiate(NukePrefab, ProjectileSpawnPointBackLeft.position, ProjectileSpawnPointBackLeft.rotation);
                        Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackLeft.up * NukeSpeed;
                        Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                        anim.SetTrigger("LeftWeaponShot");
                    }
                    FireCount++;
                }
                else
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    var Nuke = Instantiate(NukePrefab, ProjectileSpawnPointRight.position, ProjectileSpawnPointRight.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointRight.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                    anim.SetTrigger("RightWeaponShot");

                    if (StatsController.BackwardsFire == true)
                    {
                        StatsController.CurrentStamina -= StaminaPerShot;
                        AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                        Nuke = Instantiate(NukePrefab, ProjectileSpawnPointBackRight.position, ProjectileSpawnPointBackRight.rotation);
                        Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPointBackRight.up * NukeSpeed;
                        Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
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
        FireNuke(true);
    }
}
