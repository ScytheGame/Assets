using System.Collections;
using System.Reflection;
using UnityEngine;

public class NukeControllerPlayer : MonoBehaviour
{
    [SerializeField] private Transform ProjectileSpawnPoint1;
    [SerializeField] private Transform ProjectileSpawnPoint2;
    [SerializeField] private Transform ProjectileSpawnPoint3;
    [SerializeField] private Transform ProjectileSpawnPoint4;
    [SerializeField] private GameObject NukePrefab;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] AudioSource Source;
 
    [SerializeField] public float NukeSpeed = 16f;
    [SerializeField] public float fireDelay = 4f;
    [SerializeField] private float StaminaPerShot = 50f;
    [SerializeField] float Damage;



    public Skill Skill;
    public PlayerController playerController;
    public SkillsController SkillsController;
    public StatsController StatsController;
    public StaminaRegen StaminaRegen;

    private bool firedFirstMissile;
    private float delayTimer = 0f;
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
        Damage = StatsController.NukeDamage;
        NukeSpeed = StatsController.NukeSpeed;
        fireDelay = StatsController.NukeFireDelay;
        StaminaPerShot = StatsController.NukeAmmoCost;
        if (canFire == true && StaminaRegen.isReloading == false)
        {
            //Double Shot
            if (StatsController.DoubleShot)
            {

                if (Skill.usingMainWeaponNuke == true || Skill.usingBackupWeaponNuke == true)
                {
                    FireNuke();
                    canFire = false;
                    setDelayTimer = 0f;
                }

            }

            //Single Shot
            else
            {
                if (Skill.usingMainWeaponNuke == true || Skill.usingBackupWeaponNuke == true)
                {
                    FireNuke();
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
    private void FireNuke()
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
                var Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
                }
            }
            else
            {
                StatsController.CurrentStamina -= StaminaPerShot;
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                var Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

                if (StatsController.BackwardsFire == true)
                {
                    StatsController.CurrentStamina -= StaminaPerShot;
                    AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                    Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                    Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * NukeSpeed;
                    Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
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
        if (StatsController.DoubleShot)
        {
            AudioManager.PlaySFX(AudioManager.NukeShot, Source);
            var Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint1.position, ProjectileSpawnPoint1.rotation);
            Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
            Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

            AudioManager.PlaySFX(AudioManager.NukeShot, Source);
            Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint2.position, ProjectileSpawnPoint2.rotation);
            Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
            Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
            }
        }
        else
        {
            AudioManager.PlaySFX(AudioManager.NukeShot, Source);
            var Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint3.position, ProjectileSpawnPoint3.rotation);
            Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint3.up * NukeSpeed;
            Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);

            if (StatsController.BackwardsFire == true)
            {
                AudioManager.PlaySFX(AudioManager.NukeShot, Source);
                Nuke = Instantiate(NukePrefab, ProjectileSpawnPoint4.position, ProjectileSpawnPoint4.rotation);
                Nuke.GetComponent<Rigidbody2D>().linearVelocity = ProjectileSpawnPoint4.up * NukeSpeed;
                Nuke.GetComponent<PlayerWeaponStats>().Damage = Random.Range(Damage - 150, Damage + 100);
            }
        }
    }
}
