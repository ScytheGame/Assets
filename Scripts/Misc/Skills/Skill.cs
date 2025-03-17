using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public enum WeaponCode { None = 0, Missile = 1, Nuke = 2, MiniGun = 3, HomingMissile = 4, Flak = 5, Drone = 6, Laser = 7, MineHeavy = 8, MineRapid = 9, MineHoming =10 }

    public WeaponCode mainWeapon = WeaponCode.None;
    public WeaponCode backupWeapon = WeaponCode.None;

    public bool usingMainWeaponMissile = false;
    public bool usingBackupWeaponMissile = false;
    public bool usingMainWeaponNuke = false;
    public bool usingBackupWeaponNuke = false;
    public bool usingMainWeaponMiniGun = false;
    public bool usingBackupWeaponMiniGun = false;
    public bool usingMainWeaponHomingMissile = false;
    public bool usingBackupWeaponHomingMissile = false;
    public bool usingMainWeaponFlak = false;
    public bool usingBackupWeaponFlak = false;
    public bool usingMainWeaponDrone = false;
    public bool usingBackupWeaponDrone = false;
    public bool usingMainWeaponLaser = false;
    public bool usingBackupWeaponLaser = false;
    public bool usingMainWeaponMineHeavy = false;
    public bool usingBackupWeaponMineHeavy = false;
    public bool usingMainWeaponMineRapid = false;
    public bool usingBackupWeaponMineRapid = false;
    public bool usingMainWeaponMineHoming = false;
    public bool usingBackupWeaponMineHoming = false;

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

    public void SetBackupWeapon(int weaponCode)
    {
        backupWeapon = (WeaponCode)weaponCode;
        Debug.Log("Backup Weapon Set to" + backupWeapon);
    }
    void Update()
    {
        // for Missile


        if (mainWeapon == WeaponCode.Missile && Input.GetMouseButton(0) || isAttacking == true)
        {
            usingMainWeaponMissile = true;
        }
        else
        {
            usingMainWeaponMissile = false;

        }

        if (backupWeapon == WeaponCode.Missile && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponMissile = true;
        }
        else
        {
            usingBackupWeaponMissile = false;
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

        if (backupWeapon == WeaponCode.Nuke && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponNuke = true;
        }
        else
        {
            usingBackupWeaponNuke = false;
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

        if (backupWeapon == WeaponCode.MiniGun && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponMiniGun = true;
        }
        else
        {
            usingBackupWeaponMiniGun = false;
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

        if (backupWeapon == WeaponCode.HomingMissile && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponHomingMissile = true;
        }
        else
        {
            usingBackupWeaponHomingMissile = false;
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

        if (backupWeapon == WeaponCode.Flak && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponFlak = true;
        }
        else
        {
            usingBackupWeaponFlak = false;
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

        if (backupWeapon == WeaponCode.Drone && Input.GetMouseButton(1) || isAttacking == true )
        {
            usingBackupWeaponDrone = true;
        }
        else
        {
            usingBackupWeaponDrone = false;
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

        if (backupWeapon == WeaponCode.Laser && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponLaser = true;
        }
        else
        {
            usingBackupWeaponLaser = false;
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

        if (backupWeapon == WeaponCode.MineHeavy && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponMineHeavy = true;
        }
        else
        {
            usingBackupWeaponMineHeavy = false;
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

        if (backupWeapon == WeaponCode.MineRapid && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponMineRapid = true;
        }
        else
        {
            usingBackupWeaponMineRapid = false;
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

        if (backupWeapon == WeaponCode.MineHoming && Input.GetMouseButton(1) || isAttacking == true)
        {
            usingBackupWeaponMineHoming = true;
        }
        else
        {
            usingBackupWeaponMineHoming = false;
        }
    }
}
