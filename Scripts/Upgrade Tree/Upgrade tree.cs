using UnityEngine;

public class UpgradeTree : MonoBehaviour
{

    // enemy stats
    [SerializeField] public float EnemyHealth = 1;
    [SerializeField] public float EnemyDamage = 1;
    [SerializeField] public float EnemySpawnRate = 6;
    [SerializeField] public float EnemySpawnCount = 25;
    [SerializeField] public float EnemySpeed = 15;
    [SerializeField] public float EnemyAttackChance = 100;
    [SerializeField] public float EnemyAttackRateMultiplier = 0.6f;
    [SerializeField] public float EnemyProjectileSpeedMultiplier = 1;


    // player stats
    [SerializeField] public float PlayerStartingHealthBonus = 1;
    [SerializeField] public float PlayerStartingAmmo = 1;
    [SerializeField] public float PlayerDamageBonus = 1;
    [SerializeField] public float PlayerAttackSpeedBonus = 1;
    [SerializeField] public float PlayerProjectileSpeedBonus = 1;
    [SerializeField] public float PlayerXPGain = 20;
    [SerializeField] public float PlayerXPIncreaseCost = 15;
    [SerializeField] public float PlayerXPTimeCost = 1;


    [SerializeField] public bool RapidFireClass;
    [SerializeField] public bool HomingClass;



    public void Unlock(string ID, float Value = 0)
    {
        // player buffs

        if (ID.Equals ("DB")) // Damage Boost
        {
            PlayerDamageBonus += Value;
        }
        if (ID.Equals ("ASB")) // Attack Speed Boost
        {
            PlayerAttackSpeedBonus += Value;
        }
        if (ID.Equals ("PSB")) // Projectile Speed Boost
        {
            PlayerProjectileSpeedBonus += Value;
        }
        if (ID.Equals ("HB")) // Health Boost
        {
            PlayerStartingHealthBonus += Value;
        }
        if (ID.Equals ("XPB")) // XP Gain Boost
        {
            PlayerXPGain += Value;
        }
        if (ID.Equals ("AB")) // Ammo Boost
        {
            PlayerStartingAmmo += Value;
        }

        // Player Classes

        if (ID.Equals ("RFC")) // Rapid Fire Class
        {
            RapidFireClass = true;
        }
        if (ID.Equals ("HC")) // Homing Class
        {
            HomingClass = true;
        }


        // Player Weapons



        // enemy debuffs

        if (ID.Equals ("EDD")) // Enemy Damage Debuff
        {
            EnemyDamage -= Value;
        }
        if (ID.Equals ("EHD")) // Enemy Health Debuff
        {
            EnemyHealth -= Value;
        }
        if (ID.Equals ("ACD")) // Attack Chance Debuff
        {
            EnemyAttackChance -= Value;
        }
        if (ID.Equals ("ARD")) // Attack Rate Debuff
        {
            EnemyAttackRateMultiplier -= Value;
        }
        if (ID.Equals ("ESD")) // Enemy Spawn Rate Debuff
        {
            EnemySpawnRate -= Value;
        }

        Save();
    }
    void Save()
    {
        PlayerPrefs.SetFloat("Damage Boost", PlayerDamageBonus);
        PlayerPrefs.SetFloat("Attack Speed Boost", PlayerAttackSpeedBonus);
        PlayerPrefs.SetFloat("Projectile Speed Boost", PlayerProjectileSpeedBonus);
        PlayerPrefs.SetFloat("Health Boost", PlayerStartingHealthBonus);
        PlayerPrefs.SetFloat("Xp Gain Boost", PlayerXPGain);
        PlayerPrefs.SetFloat("Ammo Boost", PlayerStartingAmmo);
    }
}
