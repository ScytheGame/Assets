using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public enum WeaponCode { None = 0, Missile = 1, Nuke = 2, MiniGun = 3, HomingMissile = 4, Flak = 5, Drone = 6, Laser = 7, MineHeavy = 8, MineRapid = 9, MineHoming =10 }

    public WeaponCode mainWeapon = WeaponCode.None;

    public bool usingMainWeaponMissile = false;
    public bool usingMainWeaponNuke = false;
    public bool usingMainWeaponMiniGun = false;
    public bool usingMainWeaponHomingMissile = false;
    public bool usingMainWeaponFlak = false;
    public bool usingMainWeaponDrone = false;
    public bool usingMainWeaponLaser = false;
    public bool usingMainWeaponMineHeavy = false;
    public bool usingMainWeaponMineRapid = false;
    public bool usingMainWeaponMineHoming = false;

    [SerializeField] GameObject[] MissileWeapon;
    [SerializeField] GameObject[] NukeWeapon;
    [SerializeField] GameObject[] MinigunWeapon;
    [SerializeField] GameObject[] HomingMissileWeapon;
    [SerializeField] GameObject[] FlakWeapon;
    [SerializeField] GameObject[] DroneWeapon;
    [SerializeField] GameObject[] LaserWeapon;
    [SerializeField] GameObject[] MineWeapon;
 
    public bool isAttacking = false;
    private bool isOwned;
    private float upgradeLevel;
    internal bool IsOwned;

    public Skill(bool isOwned, float upgradeLevel)
    {
        this.isOwned = isOwned;
        this.upgradeLevel = upgradeLevel;
    }

    public void SetMainWeapon(int weaponCode)
    {
        mainWeapon = (WeaponCode)weaponCode;
        Debug.Log("Main Weapon Set to" + mainWeapon);
    }

    void Update()
    {
        foreach (GameObject weapon in MissileWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.Missile);
        }
        foreach (GameObject weapon in NukeWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.Nuke);
        }
        foreach (GameObject weapon in MinigunWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.MiniGun);
        }
        foreach (GameObject weapon in HomingMissileWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.HomingMissile);
        }
        foreach (GameObject weapon in FlakWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.Flak);
        }
        foreach (GameObject weapon in DroneWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.Drone);
        }
        foreach (GameObject weapon in LaserWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.Laser);
        }
        foreach (GameObject weapon in MineWeapon)
        {
            weapon.SetActive(mainWeapon == WeaponCode.MineHeavy || mainWeapon == WeaponCode.MineRapid || mainWeapon == WeaponCode.MineHoming);
        }

        // for Missile


        if (mainWeapon == WeaponCode.Missile && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMissile = true;
        }
        else
        {
            usingMainWeaponMissile = false;

        }


        // for Nuke 


        if (mainWeapon == WeaponCode.Nuke && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponNuke = true;
        }
        else
        {
            usingMainWeaponNuke = false;
        }

        // for MiniGun



        if (mainWeapon == WeaponCode.MiniGun && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMiniGun = true;
        }
        else
        {
            usingMainWeaponMiniGun = false;
        }


        // for HomingMissile


        if (mainWeapon == WeaponCode.HomingMissile && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponHomingMissile = true;
        }
        else
        {
            usingMainWeaponHomingMissile = false;
        }


        // for Flak


        if (mainWeapon == WeaponCode.Flak && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponFlak = true;
        }
        else
        {
            usingMainWeaponFlak = false;
        }
        // for Drone


        if (mainWeapon == WeaponCode.Drone && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponDrone = true;
        }
        else
        {
            usingMainWeaponDrone = false;
        }


        // for LaserWeapon


        if (mainWeapon == WeaponCode.Laser && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponLaser = true;
        }
        else
        {
            usingMainWeaponLaser = false;
        }


        // for MineHeavy


        if (mainWeapon == WeaponCode.MineHeavy && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMineHeavy = true;
        }
        else
        {
            usingMainWeaponMineHeavy = false;
        }

        // for MineRapid


        if (mainWeapon == WeaponCode.MineRapid && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMineRapid = true;
        }
        else
        {
            usingMainWeaponMineRapid = false;
        }

        // for MineHoming


        if (mainWeapon == WeaponCode.MineHoming && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMineHoming = true;
        }
        else
        {
            usingMainWeaponMineHoming = false;
        }

    }
}
