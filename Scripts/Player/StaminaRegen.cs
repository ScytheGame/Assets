using UnityEngine;

public class StaminaRegen : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.5f;
    [SerializeField] public PlayerController playerController;
    [SerializeField] public MissleControllerPlayer WeaponController;
    [SerializeField] public NukeControllerPlayer NukeWeaponController;
    [SerializeField] public MiniGunControllerPlayer MiniGunControllerPlayer;
    [SerializeField] public HomingMissleControllerPlayer HomingMissleControllerPlayer;
    [SerializeField] public FlakControllerPlayer FlakControllerPlayer;
    [SerializeField] public DroneControllerPlayer DroneControllerPlayer;
    [SerializeField] public StatsController StatsController;
    [SerializeField] public LaserGunControllerPlayer LaserGunControllerPlayer;
    [SerializeField] public float ForceReloadDelay = 1.5f;
    [SerializeField] public float ForceReloadTime = 0f;
    public bool isReloading = false;

    void Start()
    {
        
    }


    void Update()
    {
        ForceReloadTime += Time.deltaTime;
        if (playerController.canReload == true && !isReloading)
        {
            StartReloading();
        }
        if (isReloading)
        {
            ReloadStamina();
        }

        if (Input.GetKey("r"))
        {

            if (ForceReloadTime >= ForceReloadDelay)
            {
                isReloading = true;
                ForceReloadTime = 0f;
            }
        }

    }
    private void StartReloading()
    {
        isReloading = true;
        reloadTime = 0f;

        WeaponController.canFire = false;
        NukeWeaponController.canFire = false;
        MiniGunControllerPlayer.canFire = false;
        MiniGunControllerPlayer.betweenBurst = false;
        HomingMissleControllerPlayer.canFire = false;
        FlakControllerPlayer.canFire = false;
        DroneControllerPlayer.canFire = false;
        LaserGunControllerPlayer.canFire = false;

    }

    private void ReloadStamina()
    {
        reloadTime += Time.deltaTime;
        StatsController.CurrentStamina += (StatsController.MaxStamina / 3) * Time.deltaTime;

        WeaponController.canFire = false;
        NukeWeaponController.canFire = false;
        MiniGunControllerPlayer.canFire = false;
        HomingMissleControllerPlayer.canFire = false;
        FlakControllerPlayer.canFire = false;
        DroneControllerPlayer.canFire = false;
        LaserGunControllerPlayer.canFire = false;

        if (StatsController.CurrentStamina >= StatsController.MaxStamina)
        {
            StatsController.CurrentStamina = StatsController.MaxStamina;
            isReloading = false;
            playerController.canReload = false;

            WeaponController.canFire = true;
            NukeWeaponController.canFire = true;
            MiniGunControllerPlayer.canFire = true;
            HomingMissleControllerPlayer.canFire = true;
            FlakControllerPlayer.canFire = true;
            DroneControllerPlayer.canFire = true;
            LaserGunControllerPlayer.canFire = true;
        }
        else if (StatsController.CurrentStamina >= StatsController.MaxStamina)
        {
            WeaponController.canFire = false;
            NukeWeaponController.canFire = false;
            MiniGunControllerPlayer.canFire = false;
            HomingMissleControllerPlayer.canFire = false;
            FlakControllerPlayer.canFire = false;
            DroneControllerPlayer.canFire = false;
            LaserGunControllerPlayer.canFire = false;
        }
    }
}
