using UnityEngine;

public class ValueSave : MonoBehaviour
{
    [SerializeField] public int Level;
    [SerializeField] public int KillCount;
    [SerializeField] public int TimePlayed;

    [SerializeField] StatsController StatsController;

    public void Save()
    {
        Level = StatsController.CurrentLevel;
        // KillCount = KillCount;
        // TimePlayed = minutes;
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("KillCount", KillCount);
        PlayerPrefs.SetInt("TimePlayed", TimePlayed);
    }
}
