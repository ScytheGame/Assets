using TMPro;
using UnityEngine;

public class DeathPointDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SolarPointGain;
    [SerializeField] TextMeshProUGUI CelestialPointGain;
    int Level;
    int KillCount;
    int TimePlayed;

    public float SolarPointsLevel;
    public float SolarPointsKills;
    public float SolarPointsTimePlayed;
    public float SolarPoints;
    public float CelestialPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SolarPoints = 0;
        SolarPointsLevel = 0;
        SolarPointsKills = 0;
        SolarPointsTimePlayed = 0;
        Level = PlayerPrefs.GetInt("Level", 0);
        KillCount = PlayerPrefs.GetInt("KillCount", 0);
        TimePlayed = PlayerPrefs.GetInt("TimePlayed", 0);

        SolarPoints = PlayerPrefs.GetFloat("SolarPoints", 0);
        CelestialPoints = PlayerPrefs.GetFloat("CelestialPoints", 0);

        SolarPointsLevel += Mathf.Round(Level / 10);
        SolarPointsKills += Mathf.Round(KillCount / 20);
        SolarPointsTimePlayed += Mathf.Round(TimePlayed / 10);
        SolarPoints = SolarPointsLevel + SolarPointsTimePlayed + SolarPointsKills;
        SolarPointGain.text = ("Gained " + SolarPoints + " Solar Points:  \n " + SolarPointsLevel + " From Player Level \n " + SolarPointsKills + " From Kills \n " + SolarPointsTimePlayed + " From time Played");
    }
}
