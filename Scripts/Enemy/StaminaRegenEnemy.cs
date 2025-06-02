using UnityEngine;


public class StaminaRegenEnemy : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.5f;
    [SerializeField] GameObject Weapon;
    EnemyController EnemyController;
    MissileControllerEnemy MissileController;
    MiniGunControllerEnemy MiniGunController;
    HomingMissleControllerEnemy HomingMissileController;
    NukeControllerEnemy NukeController;
    FlakControllerEnemy FlakControllerEnemy;
    DroneControllerEnemy DroneControllerEnemy;
    

    private bool isReloading = false;

    void Start()
    {
        EnemyController = GetComponent<EnemyController>();
        if (Weapon.GetComponent<MissileControllerEnemy>() != null)
        {
            MissileController = Weapon.GetComponent<MissileControllerEnemy>();
        }
        if (Weapon.GetComponent<MiniGunControllerEnemy>() != null)
        {
            MiniGunController = Weapon.GetComponent<MiniGunControllerEnemy>();
        }
        if (Weapon.GetComponent<HomingMissleControllerEnemy>() != null)
        {
            HomingMissileController = Weapon.GetComponent<HomingMissleControllerEnemy>();
        }
        if (Weapon.GetComponent<NukeControllerEnemy>() != null)
        {
            NukeController = Weapon.GetComponent<NukeControllerEnemy>();
        }
        if (Weapon.GetComponent<FlakControllerEnemy>() != null)
        {
            FlakControllerEnemy = Weapon.GetComponent<FlakControllerEnemy>();
        }
        if (Weapon.GetComponent<DroneControllerEnemy>() != null)
        {
            DroneControllerEnemy = Weapon.GetComponent<DroneControllerEnemy>();
        }
    }


    void Update()
    {
        if (isReloading)
        {
            ReloadStamina();
        }

    }
    public void StartReloading()
    {
        isReloading = true;
        reloadTime = 0f;

        if (MissileController != null)
        {
            MissileController.canFire = false;
        }
        if (MiniGunController != null)
        {
            MiniGunController.canFire = false;
        }
        if (HomingMissileController != null)
        {
            HomingMissileController.canFire = false;
        }
        if (NukeController != null)
        {
            NukeController.canFire = false;
        }
        if (FlakControllerEnemy != null)
        {
            FlakControllerEnemy.canFire = false;
        }
        if (DroneControllerEnemy != null)
        {
            DroneControllerEnemy.canFire = false;
        }
    }

    private void ReloadStamina()
    {
        reloadTime += Time.deltaTime;
        EnemyController.enemyStamina += (EnemyController.maxStamina / 3) * Time.deltaTime / 3;
        if (MissileController != null)
        {
            MissileController.canFire = false;
        }
        if (MiniGunController != null)
        {
            MiniGunController.canFire = false;
        }
        if (HomingMissileController != null)
        {
            HomingMissileController.canFire = false;
        }
        if (NukeController != null)
        {
            NukeController.canFire = false;
        }
        if (FlakControllerEnemy != null)
        {
            FlakControllerEnemy.canFire = false;
        }
        if (DroneControllerEnemy != null)
        {
            DroneControllerEnemy.canFire = false;
        }

        if (EnemyController.enemyStamina >= EnemyController.maxStamina)
        {
            EnemyController.enemyStamina = EnemyController.maxStamina;

            if (MissileController != null)
            {
                MissileController.canFire = true;
            }
            if (MiniGunController != null)
            {
                MiniGunController.canFire = true;
            }
            if (HomingMissileController != null)
            {
                HomingMissileController.canFire = true;
            }
            if (NukeController != null)
            {
                NukeController.canFire = true;
            }
            if (FlakControllerEnemy != null)
            {
                FlakControllerEnemy.canFire = true;
            }
            if (DroneControllerEnemy != null)
            {
                DroneControllerEnemy.canFire = true;
            }

            if (MissileController != null)
            {
                MissileController.delayTimer = 0;
            }
            if (MiniGunController != null)
            {
                MiniGunController.delayTimer = 0;
            }
            if (HomingMissileController != null)
            {
                HomingMissileController.delayTimer = 0;
            }
            if (NukeController != null)
            {
                NukeController.delayTimer = 0;
            }
            if (FlakControllerEnemy != null)
            {
                FlakControllerEnemy.delayTimer = 0;
            }
            if (DroneControllerEnemy != null)
            {
                DroneControllerEnemy.delayTimer = 0;
            }
        }
    }
}
