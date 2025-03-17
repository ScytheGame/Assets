using Unity.VisualScripting;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    [SerializeField] GameObject MissileWeapon;
    [SerializeField] GameObject NukeWeapon;
    [SerializeField] GameObject MiniGunWeapon;
    [SerializeField] GameObject HomingMissileWeapon;
    [SerializeField] GameObject FlakWeapon;
    [SerializeField] GameObject DroneWeapon;
    [SerializeField] GameObject LaserWeapon;
    [SerializeField] GameObject MineHeavyWeapon;
    [SerializeField] GameObject MineRapidWeapon;
    [SerializeField] GameObject MineHomingWeapon;

    public void MissileUnlocked()
    {
        MissileWeapon.SetActive(true);
    }
    public void NukeUnlocked()
    {
        NukeWeapon.SetActive(true);
    }

    public void MiniGunUnlocked()
    {

        MiniGunWeapon.SetActive(true);
    }
    public void HomingMissileUnlocked()
    {

        HomingMissileWeapon.SetActive(true);
    }
    public void FlakUnlocked()
    { 
        FlakWeapon.SetActive(true);
    }
    public void DroneUnlocked()
    {
        DroneWeapon.SetActive(true);
    }
    public void LaserUnlocked()
    {
        LaserWeapon.SetActive(true);
    }
    public void MineHeavyUnlocked()
    {
        MineHeavyWeapon.SetActive(true);
    }
    public void MineRapidUnlocked()
    {
        MineRapidWeapon.SetActive(true);
    }
    public void MineHomingUnlocked()
    {
        MineHomingWeapon.SetActive(true);
    }


    private void Start()
    {
        MissileWeapon.SetActive(false);
        NukeWeapon.SetActive(false);
        MiniGunWeapon.SetActive(false);
        HomingMissileWeapon.SetActive(false);
        FlakWeapon.SetActive(false);
        DroneWeapon.SetActive(false);
        LaserWeapon.SetActive(false);
        MineHeavyWeapon.SetActive(false);
        MineRapidWeapon.SetActive(false);
        MineHomingWeapon.SetActive(false);
    }
}
