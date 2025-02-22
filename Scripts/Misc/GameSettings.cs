using Sirenix.OdinInspector;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemyHealth;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemyDamage;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemySpawnRate;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemySpawnCount;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemySpeed;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemyAttackChance;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemyAttackRateMultiplier;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField EnemyProjectileSpeedMultiplier;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerStartingHealth;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerStartingAmmo;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerDamageBonus;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerXPGain;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerXPIncreaseCost;
    [TabGroup("Input field")]
    [SerializeField] TMP_InputField PlayerXPTimeCost;

    // text field
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemyHealth1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemyDamage1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemySpawnRate1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemySpawnCount1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemySpeed1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemyAttackChance1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemyAttackRateMultiplier1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI EnemyProjectileSpeedMultiplier1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerStartingHealth1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerStartingAmmo1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerDamageBonus1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerXPGain1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerXPIncreaseCost1;
    [TabGroup("Text Field")]
    [SerializeField] TextMeshProUGUI PlayerXPTimeCost1;
    [TabGroup("Text Field")]
    [SerializeField] bool MainMenu;

    // enemy stats
    [SerializeField] public float EnemyHealthFloat = 800;
    [SerializeField] public float EnemyDamageFloat = 1;
    [SerializeField] public float EnemySpawnRateFloat = 6;
    [SerializeField] public float EnemySpawnCountFloat = 25;
    [SerializeField] public float EnemySpeedFloat = 15;
    [SerializeField] public float EnemyAttackChanceFloat = 100;
    [SerializeField] public float EnemyAttackRateMultiplierFloat = 1;
    [SerializeField] public float EnemyProjectileSpeedMultiplierFloat = 1;


    // player stats
    [SerializeField] public float PlayerStartingHealthFloat = 2500;
    [SerializeField] public float PlayerStartingAmmoFloat = 100;
    [SerializeField] public float PlayerDamageBonusFloat = 1;
    [SerializeField] public float PlayerXPGainFloat = 20;
    [SerializeField] public float PlayerXPIncreaseCostFloat = 15;
    [SerializeField] public float PlayerXPTimeCostFloat = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // enemy stats
        EnemyHealthFloat = PlayerPrefs.GetFloat("EnemyHealth", 800);
        EnemyDamageFloat = PlayerPrefs.GetFloat("EnemyDamage", 1);
        EnemySpawnRateFloat = PlayerPrefs.GetFloat("EnemySpawnRate", 6);
        EnemySpawnCountFloat = PlayerPrefs.GetFloat("EnemySpawnCount", 25);
        EnemySpeedFloat = PlayerPrefs.GetFloat("EnemySpeed", 15);
        EnemyAttackChanceFloat = PlayerPrefs.GetFloat("EnemyAttackChance", 100);
        EnemyAttackRateMultiplierFloat = PlayerPrefs.GetFloat("EnemyAttackRateMultiplier", 1);
        EnemyProjectileSpeedMultiplierFloat = PlayerPrefs.GetFloat("EnemyProjectileSpeedMultiplier", 1);

        // player stats
        PlayerStartingHealthFloat = PlayerPrefs.GetFloat("PlayerHealth", 2500);
        PlayerStartingAmmoFloat = PlayerPrefs.GetFloat("PlayerAmmo", 100);
        PlayerDamageBonusFloat = PlayerPrefs.GetFloat("PlayerDamageBonus", 1);
        PlayerXPGainFloat = PlayerPrefs.GetFloat("PlayerXPGain", 20);
        PlayerXPIncreaseCostFloat = PlayerPrefs.GetFloat("PlayerXPIncreaseCost", 15);
        PlayerXPTimeCostFloat = PlayerPrefs.GetFloat("PlayerXPTimeCost", 1);
    }
    private void Update()
    {
        if (MainMenu)
        {
            // Enemy

            EnemyHealth1.text = ("Enemy Starting Health \n (Currently " + EnemyHealthFloat + ")");
            EnemyDamage1.text = ("Enemy Damage Bonus \n (Currently " + EnemyDamageFloat + ")");
            EnemySpawnRate1.text = ("Enemy Spawn Delay \n (Currently " + EnemySpawnRateFloat + ")");
            EnemySpawnCount1.text = ("Max Base Enemy Spawn Count  \n (Currently " + EnemySpawnCountFloat + ")");
            EnemySpeed1.text = ("Enemy Speed \n (Currently " + EnemySpeedFloat + ")");
            EnemyAttackChance1.text = ("Enemy Attack Chance \n (Currently " + EnemyAttackChanceFloat + ")");
            EnemyAttackRateMultiplier1.text = ("Enemy Attack Rate Multiplier \n (Currently " + EnemyAttackRateMultiplierFloat + ")");
            EnemyProjectileSpeedMultiplier1.text = ("Enemy Projectile Speed Multiplier \n (Currently " + EnemyProjectileSpeedMultiplierFloat + ")");

            // Player

            PlayerStartingHealth1.text = ("Player Starting Health \n (Currently " + PlayerStartingHealthFloat + ")");
            PlayerStartingAmmo1.text = ("Player Starting Ammo \n (Currently " + PlayerStartingAmmoFloat + ")");
            PlayerDamageBonus1.text = ("Player Damage Bonus \n (Currently " + PlayerDamageBonusFloat + ")");
            PlayerXPGain1.text = ("Player XP Gain \n (Currently " + PlayerXPGainFloat + ")");
            PlayerXPIncreaseCost1.text = ("Player XP Increase Cost  \n (Currently " + PlayerXPIncreaseCostFloat + ")");
        }

    }
    public void ResetStats()
    {
        PlayerPrefs.DeleteKey("EnemyHealth");
        PlayerPrefs.DeleteKey("EnemyDamage");
        PlayerPrefs.DeleteKey("EnemySpawnCount");
        PlayerPrefs.DeleteKey("EnemySpawnRate");
        PlayerPrefs.DeleteKey("EnemySpeed");
        PlayerPrefs.DeleteKey("EnemyAttackChance");
        PlayerPrefs.DeleteKey("EnemyAttackRate");
        PlayerPrefs.DeleteKey("EnemyProjectileSpeedMultiplier");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("PlayerAmmo");
        PlayerPrefs.DeleteKey("PlayerDamageBonus");
        PlayerPrefs.DeleteKey("PlayerXPGain");
        PlayerPrefs.DeleteKey("PlayerXPIncreaseCost");
        PlayerPrefs.DeleteKey("PlayerXPTimeCost");
    }
    // Enemy Stats
    public void UpdateHealth()
    {
        if (EnemyHealth.text != null)
        {
            if (float.TryParse(EnemyHealth.text, out EnemyHealthFloat))
            {
                Save();
            }
            else
            {
                EnemyHealthFloat = 800f;
            }
        }
        else
        {
            EnemyHealthFloat = 800f;
        }
    }
    public void UpdateDamage()
    {

        if (EnemyDamage.text != null)
        {
            if (float.TryParse(EnemyDamage.text, out EnemyDamageFloat))
            {
                Save();
            }
            else
            {
                EnemyDamageFloat = 1;
            }
        }
        else
        {
            EnemyDamageFloat = 1;
        }
    }
    public void UpdateSpawnRate()
    {
        if (EnemySpawnRate.text != null)
        {
            if (float.TryParse(EnemySpawnRate.text, out EnemySpawnRateFloat))
            {
                Save();
            }
            else
            {
                EnemySpawnRateFloat = 6;
            }
        }
        else
        {
            EnemySpawnRateFloat = 6;
        }
    }
    public void UpdateSpawnCount()
    {
        if (EnemySpawnCount.text != null)
        {
            if (float.TryParse(EnemySpawnCount.text, out EnemySpawnCountFloat))
            {
                Save();
            }
            else
            {
                EnemySpawnCountFloat = 25;
            }
        }
        else
        {
            EnemySpawnCountFloat = 25;
        }
    }
    public void UpdateEnemySpeed()
    {
        if (EnemySpeed.text != null)
        {
            if (float.TryParse(EnemySpeed.text, out EnemySpeedFloat))
            {
                Save();
            }
            else
            {
                EnemySpeedFloat = 15;
            }
        }
        else
        {
            EnemySpeedFloat = 15;
        }
    }
    public void UpdateEnemyAttackChance()
    {
        if (EnemyAttackChance.text != null)
        {
            if (float.TryParse(EnemyAttackChance.text, out EnemyAttackChanceFloat))
            {
                Save();
            }
            else
            {
                EnemyAttackChanceFloat = 100;
            }
        }
        else
        {
            EnemyAttackChanceFloat = 100;
        }
    }
    public void UpdateEnemyAttackRate()
    {
        if (EnemyAttackRateMultiplier.text != null)
        {
            if (float.TryParse(EnemyAttackRateMultiplier.text, out EnemyAttackRateMultiplierFloat))
            {
                Save();
            }
            else
            {
                EnemyAttackRateMultiplierFloat = 1;
            }
        }
        else
        {
            EnemyAttackRateMultiplierFloat = 1;
        }
    }
    public void UpdateEnemyProjectileSpeed()
    {
        if (EnemyProjectileSpeedMultiplier.text != null)
        {
            if (float.TryParse(EnemyProjectileSpeedMultiplier.text, out EnemyProjectileSpeedMultiplierFloat))
            {
                Save();
            }
            else
            {
                EnemyProjectileSpeedMultiplierFloat = 1;
            }
        }
        else
        {
            EnemyProjectileSpeedMultiplierFloat = 1;
        }
    }




    // Player Stats
    public void UpdatePlayerHealth()
    {
        if (PlayerStartingHealth.text != null)
        {
            if (float.TryParse(PlayerStartingHealth.text, out PlayerStartingHealthFloat))
            {
                Save();
            }
            else
            {
                PlayerStartingHealthFloat = 2500f;
            }
        }
        else
        {
            PlayerStartingHealthFloat = 2500f;
        }
    }
    public void UpdatePlayerAmmo()
    {
        if (PlayerStartingAmmo.text != null)
        {
            if (float.TryParse(PlayerStartingAmmo.text, out PlayerStartingAmmoFloat))
            {
                Save();
            }
            else
            {
                PlayerStartingAmmoFloat = 100f;
            }
        }
        else
        {
            PlayerStartingAmmoFloat = 100f;
        }
    }
    public void UpdatePlayerDamage()
    {
        if (PlayerDamageBonus.text != null)
        {
            if (float.TryParse(PlayerDamageBonus.text, out PlayerDamageBonusFloat))
            {
                Save();
            }
            else
            {
                PlayerDamageBonusFloat = 1f;
            }
        }
        else
        {
            PlayerDamageBonusFloat = 1f;
        }
    }
    public void UpdatePlayerXPGain()
    {
        if (PlayerXPGain.text != null)
        {
            if (float.TryParse(PlayerXPGain.text, out PlayerXPGainFloat))
            {
                Save();
            }
            else
            {
                PlayerXPGainFloat = 20f;
            }
        }
        else
        {
            PlayerXPGainFloat = 20f;
        }
    }
    public void UpdatePlayerXPIncreaseCost()
    {
        if (PlayerXPIncreaseCost.text != null)
        {
            if (float.TryParse(PlayerXPIncreaseCost.text, out PlayerXPIncreaseCostFloat))
            {
                Save();
            }
            else
            {
                PlayerXPIncreaseCostFloat = 15f;
            }
        }
        else
        {
            PlayerXPIncreaseCostFloat = 15f;
        }
    }
    public void UpdatePlayerXPTimeCost()
    {
        if (PlayerXPTimeCost.text != null)
        {
            if (float.TryParse(PlayerXPTimeCost.text, out PlayerXPTimeCostFloat))
            {
                Save();
            }
            else
            {
                PlayerXPTimeCostFloat = 1f;
            }
        }
        else
        {
            PlayerXPTimeCostFloat = 1f;
        }
    }
    public void Save()
    {
        // enemy stats
        PlayerPrefs.SetFloat("EnemyHealth", EnemyHealthFloat);
        PlayerPrefs.SetFloat("EnemyDamage", EnemyDamageFloat);
        PlayerPrefs.SetFloat("EnemySpawnRate", EnemySpawnRateFloat);
        PlayerPrefs.SetFloat("EnemySpawnCount", EnemySpawnCountFloat);
        PlayerPrefs.SetFloat("EnemySpeed", EnemySpeedFloat);
        PlayerPrefs.SetFloat("EnemyAttackChance", EnemyAttackChanceFloat);
        PlayerPrefs.SetFloat("EnemyAttackRateMultiplier", EnemyAttackRateMultiplierFloat);
        PlayerPrefs.SetFloat("EnemyProjectileSpeedMultiplier", EnemyProjectileSpeedMultiplierFloat);

        // player stats
        PlayerPrefs.SetFloat("PlayerHealth", PlayerStartingHealthFloat);
        PlayerPrefs.SetFloat("PlayerAmmo", PlayerStartingAmmoFloat);
        PlayerPrefs.SetFloat("PlayerDamageBonus", PlayerDamageBonusFloat);
        PlayerPrefs.SetFloat("PlayerXPGain", PlayerXPGainFloat);
        PlayerPrefs.SetFloat("PlayerXPIncreaseCost", PlayerXPIncreaseCostFloat);
        PlayerPrefs.SetFloat("PlayerXPTimeCost", PlayerXPTimeCostFloat);
    }
}
