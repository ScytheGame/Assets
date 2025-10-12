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

    [SerializeField] bool[] RealisticMovement = { false, false, true };
    void Awake()
    {
        int DifficultyInt = PlayerPrefs.GetInt("difficulty", 0);

        //if (RandomEnemySpawn != null)
        //{
        //    RandomEnemySpawn.maxCount = maxCount[DifficultyInt];
        //    RandomEnemySpawn.spawnDelay = spawnDelay[DifficultyInt];
        //}

        DifficultyGameData.NegativeLevelRange = NegativeLevelRange[DifficultyInt];
        DifficultyGameData.PositiveLevelRange = PositiveLevelRange[DifficultyInt];
        DifficultyGameData.HealthMultiplier = HealthMultiplier[DifficultyInt];
        DifficultyGameData.RealisticMovement = RealisticMovement[DifficultyInt];

    }
}
