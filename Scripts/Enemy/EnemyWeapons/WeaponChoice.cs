using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponChoice : MonoBehaviour
{

    MissileControllerEnemy Missile;
    HomingMissleControllerEnemy HomingMissile;
    NukeControllerEnemy Nuke;
    MiniGunControllerEnemy MiniGun;
    FlakControllerEnemy Flak;
    DroneControllerEnemy Drone;

    RandomEnemySpawn RandomEnemySpawn;

    [ValueDropdown("Enemy Types")]
    public enum Type {Basic = 0, Missile = 1, Nuke = 2, Minigun = 3, HomingMissile = 4, Flak = 5, Drone = 6};
    public Type EnemyType = 0;
    

    int random = 0;
    float GameTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Missile = GetComponent<MissileControllerEnemy>();
        HomingMissile = GetComponent<HomingMissleControllerEnemy>();
        Nuke = GetComponent<NukeControllerEnemy>();
        MiniGun = GetComponent<MiniGunControllerEnemy>();
        Flak = GetComponent<FlakControllerEnemy>();
        Drone = GetComponent<DroneControllerEnemy>();

        GameObject EnemySpawn = GameObject.FindWithTag("EnemySpawn");
        RandomEnemySpawn = EnemySpawn.GetComponent<RandomEnemySpawn>();
        GameTime = RandomEnemySpawn.minutes;
        random = Random.Range(0,100);
        if (EnemyType == Type.Basic)
        {
            if (GameTime < 10)
            {
                BasicEnemySpawn();
            }
            else if (GameTime < 15)
            {
                Basic1EnemySpawn();
            }
            else if (GameTime < 20)
            {
                Basic2EnemySpawn();
            }
            else if (GameTime < 25)
            {
                Basic3EnemySpawn();
            }
            else
            {
                Basic4EnemySpawn();
            }
        }

        if (EnemyType == Type.Missile)
        {
            MissileEnemy();
        }
        if (EnemyType == Type.Nuke)
        {
            NukeEnemy();
        }
        if (EnemyType == Type.Minigun)
        {
            MiniGunEnemy();
        }
        if (EnemyType == Type.HomingMissile)
        {
            HomingMissileEnemy();
        }
        if (EnemyType == Type.Flak)
        {
            FlakEnemy();
        }
        if (EnemyType == Type.Drone)
        {
            DroneEnemy();
        }

    }
    public void BasicEnemySpawn()
    {
        if (random >= 0 && random < 100)
        {
            Missile.enabled = true;
            HomingMissile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
    }
    public void Basic1EnemySpawn()
    {
        if (random >= 0 && random < 100)
        {
            Missile.enabled = true;
            HomingMissile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 70 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = true;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
    }
    public void Basic2EnemySpawn()
    {
        if (random >= 0 && random < 100)
        {
            Missile.enabled = true;
            HomingMissile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 50 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = true;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 70 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = true;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 90 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = true;
            Flak.enabled = false;
            Drone.enabled = false;
        }
    }
    public void Basic3EnemySpawn()
    {
        if (random >= 0 && random < 100)
        {
            Missile.enabled = true;
            HomingMissile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 40 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = true;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 60 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = true;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 80 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = true;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 90 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = true;
            Drone.enabled = false;
        }
    }
    public void Basic4EnemySpawn()
    {
        if (random >= 0 && random < 100)
        {
            Missile.enabled = true;
            HomingMissile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 40 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = true;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 60 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = true;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 70 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = true;
            Flak.enabled = false;
            Drone.enabled = false;
        }
        if (random >= 80 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = true;
            Drone.enabled = false;
        }
        if (random >= 90 && random < 100)
        {
            Missile.enabled = false;
            Nuke.enabled = false;
            MiniGun.enabled = false;
            HomingMissile.enabled = false;
            Flak.enabled = false;
            Drone.enabled = true;
        }
    }

    public void MissileEnemy()
    {
        Missile.enabled = true;
    }
    public void NukeEnemy()
    {
        Nuke.enabled = true;
    }
    public void MiniGunEnemy()
    {
        MiniGun.enabled = true;
    }
    public void HomingMissileEnemy()
    {
        HomingMissile.enabled = true;
    }
    public void FlakEnemy()
    {
        Flak.enabled = true;
    }
    public void DroneEnemy()
    {
        Drone.enabled = true;
    }
}
