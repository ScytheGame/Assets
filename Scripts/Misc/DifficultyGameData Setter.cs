using System.Collections.Generic;
using UnityEngine;

public class DifficultyGameDataSetter : MonoBehaviour
{
    public int NegativeLevelRange = -3;
    public int PositiveLevelRange = 2;
    void Awake()
    {
        DifficultyGameData.NegativeLevelRange = NegativeLevelRange;
        DifficultyGameData.PositiveLevelRange = PositiveLevelRange;
    }
}
