using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField, TabGroup("Bullet Spawn Positions")] Transform ProjectileSpawnPointLeft;
    [SerializeField, TabGroup("Bullet Spawn Positions")] Transform ProjectileSpawnPointBackLeft;
    [SerializeField, TabGroup("Bullet Spawn Positions")] Transform ProjectileSpawnPointRight;
    [SerializeField, TabGroup("Bullet Spawn Positions")] Transform ProjectileSpawnPointBackRight;

    [SerializeField, TabGroup("References")] StatsController StatsController;
    [SerializeField, TabGroup("References")] StaminaRegen StaminaRegen;
    [SerializeField, TabGroup("References")] Animator Anim;
    [SerializeField, TabGroup("References")] AudioManager AudioManager;
    [SerializeField, TabGroup("References")] AudioSource Source;

    public Weapon ActiveWeapon;
    public bool CanFire;
    public bool IsReloading;

    public float DelayTimer = 0f;
    int FireCount = 0;
    int BackwardsFireCount = 0;

    private void Update()
    {

        if (ActiveWeapon == null)
        {
            if (StatsController.ActiveWeapon != null)
            {
                ActiveWeapon = StatsController.ActiveWeapon;
            }
            else
            {
                return;
            }
        }

        if (CanFire && !IsReloading)
        {
            if (Input.GetMouseButton(0))
            {

                for (int i = 0; i < ActiveWeapon.BulletCount; i++)
                {

                    if (!ActiveWeapon.MultiShot)
                    {
                        if (FireCount == 0)
                        {
                            FireBullet(FireCount, i, ProjectileSpawnPointLeft);
                            FireCount++;
                        }
                        else if (FireCount == 1)
                        {
                            FireBullet(FireCount, i, ProjectileSpawnPointRight);
                            FireCount = 0;
                        }
                        DelayTimer = 0;
                        CanFire = false;
                    }

                    else if (ActiveWeapon.MultiShot)
                    {

                        FireBullet(0, i, ProjectileSpawnPointLeft);
                        FireBullet(1, i, ProjectileSpawnPointRight);

                        FireCount = 0;
                        DelayTimer = 0;
                        CanFire = false;
                    }

                    if (ActiveWeapon.BackwardsFire)
                    {

                        if (BackwardsFireCount == 0)
                        {
                            FireBullet(BackwardsFireCount, i, ProjectileSpawnPointBackLeft);
                            BackwardsFireCount++;
                        }
                        else if (BackwardsFireCount == 1)
                        {
                            FireBullet(BackwardsFireCount, i, ProjectileSpawnPointBackRight);
                            BackwardsFireCount = 0;
                        }
                        DelayTimer = 0;
                        CanFire = false;
                    }
                }
            }
        }
        else
        {
            DelayTimer += Time.deltaTime;

            if (DelayTimer >= ActiveWeapon.AttackSpeed)
            {
                CanFire = true;
            }
        }


    }
    async void FireBullet(int FireCount, int ShotCount, Transform SpawnPoint)
    {
        if (StatsController.CurrentAmmo < ActiveWeapon.AmmoCost)
        {
            CanFire = false;
            StaminaRegen.CanReload = true;
        }
        else
        {
            if (ShotCount != 0 && !ActiveWeapon.MultiShot)
                await Task.Delay(ActiveWeapon.IntermitentFireDelay * ShotCount);
            
            if (FireCount == 0)
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                
                StatsController.CurrentAmmo -= ActiveWeapon.AmmoCost;

                var OffsetRotation = SpawnPoint.rotation;

                if (ActiveWeapon.RandomSpread)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, Random.Range(ActiveWeapon.Spread.x, ActiveWeapon.Spread.y));

                else if (ShotCount == 1)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, ActiveWeapon.Spread.x);

                else if (ShotCount == 2)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, ActiveWeapon.Spread.y);

                var Bullet = Instantiate(ActiveWeapon.BulletPrefab, SpawnPoint.position, OffsetRotation);
                
                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * ActiveWeapon.ProjectileSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(ActiveWeapon.DamageRange.x + ActiveWeapon.DamageRange.y, ActiveWeapon.DamageRange.z + ActiveWeapon.DamageRange.y);
                Bullet.GetComponent<PlayerWeaponStats>().Lifetime = ActiveWeapon.BulletLifetime;
                
                Anim.SetTrigger("LeftWeaponShot");
            }
            else
            {
                AudioManager.PlaySFX(AudioManager.MissileShot, Source);
                
                StatsController.CurrentAmmo -= ActiveWeapon.AmmoCost;

                var OffsetRotation = SpawnPoint.rotation;

                if (ActiveWeapon.RandomSpread)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, Random.Range(ActiveWeapon.Spread.x, ActiveWeapon.Spread.y));

                else if (ShotCount == 1)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, ActiveWeapon.Spread.x);

                else if (ShotCount == 2)
                    OffsetRotation = SpawnPoint.rotation * Quaternion.Euler(0, 0, ActiveWeapon.Spread.y);

                var Bullet = Instantiate(ActiveWeapon.BulletPrefab, SpawnPoint.position, OffsetRotation);

                Bullet.GetComponent<Rigidbody2D>().linearVelocity = Bullet.transform.up * ActiveWeapon.ProjectileSpeed;
                Bullet.GetComponent<PlayerWeaponStats>().Damage = Random.Range(ActiveWeapon.DamageRange.x + ActiveWeapon.DamageRange.y, ActiveWeapon.DamageRange.z + ActiveWeapon.DamageRange.y);
                Bullet.GetComponent<PlayerWeaponStats>().Lifetime = ActiveWeapon.BulletLifetime;

                Anim.SetTrigger("RightWeaponShot");
            }

            

        }
    }
}
