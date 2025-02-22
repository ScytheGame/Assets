using UnityEngine;

public class ValueLoad : MonoBehaviour
{
    [SerializeField] public int Level;
    [SerializeField] public int KillCount;
    [SerializeField] public int TimePlayed;

    void Start()
    {
       Level = PlayerPrefs.GetInt("Level", 0);
       KillCount = PlayerPrefs.GetInt("KillCount", 0);
       TimePlayed = PlayerPrefs.GetInt("TimePlayed", 0);
    }
}
