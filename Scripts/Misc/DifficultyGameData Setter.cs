using System.Collections.Generic;
using UnityEngine;

public class DifficultyGameDataSetter : MonoBehaviour
{
     // [SerializeField] RandomEnemySpawn RandomEnemySpawn;

    [SerializeField] float[] maxCount = { 10, 40, 60 };
    [SerializeField] float[] spawnDelay = { 6, 5, 4};

    [SerializeField] int[] NegativeLevelRange = { -5, -3, -1};
    [SerializeField] int[] PositiveLevelRange = { 1, 4, 9};
    [SerializeField] float[] HealthMultiplier = { 0.8f, 1.4f, 3.5f };
    [SerializeField] float[] DamageMultiplier = { 0.9f, 1.2f, 2.2f };

    [SerializeField] float[] HealthLevelMultiplier = { 1.1f, 1.4f, 1.7f };
    [SerializeField] float[] DamageLevelMultiplier = { 1.05f, 1.2f, 1.5f };

    [SerializeField] bool[] RealisticMovement = { false, false, true };

    [SerializeField] EnemySpawner EnemySpawner;
    void Awake()
    {
        int DifficultyInt = PlayerPrefs.GetInt("difficulty", 0);

        if (EnemySpawner != null)
        {
            EnemySpawner.MaxEnemyCount = maxCount[DifficultyInt];
            EnemySpawner.SpawnDelay = spawnDelay[DifficultyInt];
        }

        DifficultyGameData.NegativeLevelRange = NegativeLevelRange[DifficultyInt];
        DifficultyGameData.PositiveLevelRange = PositiveLevelRange[DifficultyInt];
        DifficultyGameData.HealthMultiplier = HealthMultiplier[DifficultyInt];
        DifficultyGameData.DamageMultiplier = DamageMultiplier[DifficultyInt];
        DifficultyGameData.HealthLevelMultiplier = HealthLevelMultiplier[DifficultyInt];
        DifficultyGameData.DamageLevelMultiplier = DamageLevelMultiplier[DifficultyInt];
        DifficultyGameData.RealisticMovement = RealisticMovement[DifficultyInt];

    }
}
