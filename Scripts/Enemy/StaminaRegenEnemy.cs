using UnityEngine;


public class StaminaRegenEnemy : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.5f;
    [SerializeField] public EnemyController EnemyController;
    [SerializeField] public MissileControllerEnemy WeaponController;
    [SerializeField] public MiniGunControllerEnemy MiniGunController;
    [SerializeField] public HomingMissleControllerEnemy HomingMissileController;
    [SerializeField] public NukeControllerEnemy NukeController;
    [SerializeField] public FlakControllerEnemy FlakControllerEnemy;

    private bool isReloading = false;

    void Start()
    {
    }


    void Update()
    {
        if (EnemyController.enemyStamina <= 10 && !isReloading)
        {
            StartReloading();
        }
        if (isReloading)
        {
            ReloadStamina();
        }

    }
    private void StartReloading()
    {
        isReloading = true;
        reloadTime = 0f;
        WeaponController.canFire = false;
        MiniGunController.canFire = false;
        NukeController.canFire = false;
        HomingMissileController.canFire = false;
        FlakControllerEnemy.canFire = false;
    }

    private void ReloadStamina()
    {
        reloadTime += Time.deltaTime;
        EnemyController.enemyStamina += (EnemyController.maxStamina / 3) * Time.deltaTime / 3;
        WeaponController.canFire = false;
        MiniGunController.canFire = false;
        NukeController.canFire = false;
        HomingMissileController.canFire = false;
        FlakControllerEnemy.canFire = false;

        if (EnemyController.enemyStamina >= EnemyController.maxStamina)
        {
            EnemyController.enemyStamina = EnemyController.maxStamina;
            isReloading = false;
            WeaponController.canFire = true;
            MiniGunController.canFire = true;
            NukeController.canFire = true;
            HomingMissileController.canFire = true;
            FlakControllerEnemy.canFire = true;
            WeaponController.delayTimer = 0f;
            NukeController.delayTimer = 0f;
            MiniGunController.delayTimer = 0f;
            HomingMissileController.delayTimer = 0f;
            FlakControllerEnemy.delayTimer = 0f;
        }
    }
}
