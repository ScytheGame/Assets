using TMPro;
using UnityEngine;

public class DeathPointDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SolarPointGain;
    [SerializeField] TextMeshProUGUI CelestialPointGain;
    [SerializeField] TextMeshProUGUI StatsText;
    int Level;
    int KillCount;
    int TimePlayed;

    public float SolarPointsLevel;
    public float SolarPointsKills;
    public float SolarPointsTimePlayed;
    public float SolarPoints;
    public float CelestialPoints;

    void Start()
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

        SolarPointsLevel += Mathf.Round(Level / 3);
        SolarPointsKills += Mathf.Round(KillCount / 10);
        SolarPointsTimePlayed += Mathf.Round(TimePlayed / 2);
        SolarPoints = SolarPointsLevel + SolarPointsTimePlayed + SolarPointsKills;
        StatsText.text = ($"Stats This Run \n Player Level: {Level} \n Kill Count: {KillCount} \n Time Played: {TimePlayed}");
        SolarPointGain.text = ($"Gained {SolarPoints} Solar Points:  \n {SolarPointsLevel} From Player Level \n {SolarPointsKills} From Kills \n {SolarPointsTimePlayed} From time Played");
    }
}
