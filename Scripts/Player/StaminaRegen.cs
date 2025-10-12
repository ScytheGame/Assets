using UnityEngine;

public class StaminaRegen : MonoBehaviour
{
    [SerializeField] private float reloadTime = 1.5f;
    [SerializeField] public PlayerController PlayerController;
    [SerializeField] public StatsController StatsController;
    [SerializeField] public float ForceReloadDelay = 1.5f;
    [SerializeField] public float ForceReloadTime = 0f;

    float MaxStamina {get => StatsController.MaxAmmo; set => StatsController.MaxAmmo = value; }
    float CurrentStamina { get => StatsController.CurrentAmmo; set => StatsController.CurrentAmmo = value; }

    public bool IsReloading = false;
    public bool CanReload = false;
    public bool CanFire = true;

    void Update()
    {
        ForceReloadTime += Time.deltaTime;
        if (CanReload == true && !IsReloading)
        {
            StartReloading();
        }
        if (IsReloading)
        {
            ReloadStamina();
        }

        if (Input.GetKey("r"))
        {

            if (ForceReloadTime >= ForceReloadDelay)
            {
                IsReloading = true;
                ForceReloadTime = 0f;
            }
        }

    }
    private void StartReloading()
    {
        IsReloading = true;
        reloadTime = 0f;

        CanFire = false;

    }

    private void ReloadStamina()
    {
        reloadTime += Time.deltaTime;
        CurrentStamina += (MaxStamina / 3) * Time.deltaTime;

        CanFire = false;

        if (CurrentStamina >= MaxStamina)
        {
            CurrentStamina = MaxStamina;
            IsReloading = false;
            CanReload = false;

            CanFire = true;
        }
        else if (CurrentStamina >= MaxStamina)
        {
            CanFire = false;
        }
    }
}
