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
    [SerializeField] TMP_InputField EnemyAttackRateMultiplyer;
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
    [SerializeField] TextMeshProUGUI EnemyAttackRateMultiplyer1;
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

    // enemy stats
    [SerializeField] public float EnemyHealthFloat = 800;
    [SerializeField] public float EnemyDamageFloat = 1;
    [SerializeField] public float EnemySpawnRateFloat = 6;
    [SerializeField] public float EnemySpawnCountFloat = 25;
    [SerializeField] public float EnemySpeedFloat = 10;
    [SerializeField] public float EnemyAttackChanceFloat = 40;
    [SerializeField] public float EnemyAttackRateMultiplyerFloat = 1;


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
        EnemySpeedFloat = PlayerPrefs.GetFloat("EnemySpeed", 10);
        EnemyAttackChanceFloat = PlayerPrefs.GetFloat("EnemyAttackChance", 40);

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
        // Enemy

        EnemyHealth1.text = ("Enemy Starting Health (Currently " + EnemyHealthFloat + ")");
        EnemyDamage1.text = ("Enemy Damage Bonus (Currently " + EnemyDamageFloat + ")");
        EnemySpawnRate1.text = ("Enemy Spawn Delay (Currently " + EnemySpawnRateFloat + ")");
        EnemySpawnCount1.text = ("Max Base Enemy Spawn Count  (Currently " + EnemySpawnCountFloat + ")");
        EnemySpeed1.text = ("Enemy Speed (Currently " + EnemySpeedFloat + ")");
        EnemyAttackChance1.text = ("Enemy Attack Chance (Currently " + EnemyAttackChanceFloat + ")");

        // Player

        PlayerStartingHealth1.text = ("Player Starting Health (Currently " + PlayerStartingHealthFloat + ")");
        PlayerStartingAmmo1.text = ("Player Starting Ammo (Currently " + PlayerStartingAmmoFloat + ")");
        PlayerDamageBonus1.text = ("Player Damage Bonus (Currently " + PlayerDamageBonusFloat + ")");
        PlayerXPGain1.text = ("Player XP Gain (Currently " + PlayerXPGainFloat + ")");
        PlayerXPIncreaseCost1.text = ("Player XP Increase Cost  (Currently " + PlayerXPIncreaseCostFloat + ")");


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
                EnemySpeedFloat = 10;
            }
        }
        else
        {
            EnemySpeedFloat = 10;
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
                EnemyAttackChanceFloat = 40;
            }
        }
        else
        {
            EnemyAttackChanceFloat = 40;
        }
    }
    public void UpdateEnemyAttackRate()
    {
        if (EnemyAttackRateMultiplyer.text != null)
        {
            if (float.TryParse(EnemyAttackRateMultiplyer.text, out EnemyAttackRateMultiplyerFloat))
            {
                Save();
            }
            else
            {
                EnemyAttackRateMultiplyerFloat = 1;
            }
        }
        else
        {
            EnemyAttackRateMultiplyerFloat = 1;
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
        PlayerPrefs.SetFloat("EnemyAttackRateMultiplyer", EnemyAttackRateMultiplyerFloat);

        // player stats
        PlayerPrefs.SetFloat("PlayerHealth", PlayerStartingHealthFloat);
        PlayerPrefs.SetFloat("PlayerAmmo", PlayerStartingAmmoFloat);
        PlayerPrefs.SetFloat("PlayerDamageBonus", PlayerDamageBonusFloat);
        PlayerPrefs.SetFloat("PlayerXPGain", PlayerXPGainFloat);
        PlayerPrefs.SetFloat("PlayerXPIncreaseCost", PlayerXPIncreaseCostFloat);
        PlayerPrefs.SetFloat("PlayerXPTimeCost", PlayerXPTimeCostFloat);
    }
}
