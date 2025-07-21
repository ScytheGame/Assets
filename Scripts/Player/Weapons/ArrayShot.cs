using System.Collections;
using UnityEngine;

public class ArrayShot : MonoBehaviour
{
    [SerializeField] SkillsController SkillsController;
    [SerializeField] StatsController StatsController;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] Transform ProjectileSpawnPoint1;
    [SerializeField] GameObject HeavyPrefab;
    [SerializeField] GameObject HomingPrefab;
    [SerializeField] GameObject RapidPrefab;

    public float BulletSpeed;
    public bool ArrayShotEnabled = false;
    public bool canFire = false;
    public float delay = 5f;
    public float time = 0f;
    public float Spread = 15;
    public float HeavyDamage;
    public float HomingDamage;
    public float RapidDamage;
    public float AngleOfSpread;

    void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        GetComponent<PlayerController>();
    }

    void Update()
    {
        delay = StatsController.ArrayDelay;
        BulletSpeed = StatsController.ArrayShotSpeed;
        ArrayShotEnabled = StatsController.ArrayShot;
        HeavyDamage = StatsController.MissileDamage;
        HomingDamage = StatsController.DroneDamage;
        RapidDamage = StatsController.MinigunDamage;
        if (ArrayShotEnabled)
        {
            if (time >= delay && canFire == true)
            {
                StartCoroutine(FireBullet());
                if (StatsController.ArrayDoubleShot)
                {
                    StartCoroutine(FireBullet());
                }
                canFire = false;
                time = 0f;
            }
            else
            {
                time += Time.deltaTime;

                if (time >= delay)
                {
                    canFire = true;
                }
            }
        }
    }
    private IEnumerator FireBullet()
    {
        if (SkillsController.SelectedWeapon == BaseWeapon.Heavy)
        {
            for (float i = 0; i < 24; i++)
            {
                AngleOfSpread += Spread;
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(HeavyPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(HeavyDamage - 50, HeavyDamage);
                yield return new WaitForSeconds(0.005f);
            }
            AngleOfSpread = 0;
        }
        if (SkillsController.SelectedWeapon == BaseWeapon.Homing)
        {
            for (float i = 0; i < 24; i++)
            {
                AngleOfSpread += Spread;
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(HomingPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(HomingDamage - 10, HomingDamage);
                yield return new WaitForSeconds(0.005f);
            }
            AngleOfSpread = 0;
        }
        if (SkillsController.SelectedWeapon == BaseWeapon.Rapid)
        {
            for (float i = 0; i < 24; i++)
            {
                AngleOfSpread += Spread;
                var offsetRotation = ProjectileSpawnPoint1.rotation * Quaternion.Euler(0, 0, AngleOfSpread);
                var Bullet = Instantiate(RapidPrefab, ProjectileSpawnPoint1.position, offsetRotation);
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * BulletSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(RapidDamage - 15, RapidDamage);
                yield return new WaitForSeconds(0.005f);
            }
            AngleOfSpread = 0;
        }
    }
}
