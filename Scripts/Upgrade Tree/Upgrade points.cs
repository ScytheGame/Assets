using UnityEngine;

public class Upgradepoints : MonoBehaviour
{
    int Level;
    int KillCount;
    int TimePlayed;

    public float SkillPoints;

    void Start()
    {
        Level = PlayerPrefs.GetInt("Level", 0);
        KillCount = PlayerPrefs.GetInt("KillCount", 0);
        TimePlayed = PlayerPrefs.GetInt("TimePlayed", 0);

        SkillPoints = PlayerPrefs.GetFloat("SkillPoints", 0);

        SkillPoints += Mathf.Round(Level / 10);
        SkillPoints += Mathf.Round(KillCount / 20);
        SkillPoints += Mathf.Round(TimePlayed / 10);

        PlayerPrefs.SetFloat("SkillPoints", SkillPoints);

    }
}
