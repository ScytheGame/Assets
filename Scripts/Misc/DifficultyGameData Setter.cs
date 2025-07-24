using System.Collections.Generic;
using UnityEngine;

public class DifficultyGameDataSetter : MonoBehaviour
{
    public int NegativeLevelRange = -3;
    public int PositiveLevelRange = 2;
    public float HealthMultiplier = 1;
    void Awake()
    {
        DifficultyGameData.NegativeLevelRange = NegativeLevelRange;
        DifficultyGameData.PositiveLevelRange = PositiveLevelRange;
        DifficultyGameData.HealthMultiplier = HealthMultiplier;
    }
}
