using UnityEngine;

public class ValueSave : MonoBehaviour
{
    [SerializeField] public int Level;
    [SerializeField] public int KillCount;
    [SerializeField] public int TimePlayed;

    [SerializeField] StatsController StatsController;
    [SerializeField] RandomEnemySpawn RandomEnemySpawn;

    public void Save()
    {
        Level = StatsController.currentLevel;
        KillCount = RandomEnemySpawn.KillCount;
        TimePlayed = RandomEnemySpawn.minutes;
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("KillCount", KillCount);
        PlayerPrefs.SetInt("TimePlayed", TimePlayed);
    }
}
