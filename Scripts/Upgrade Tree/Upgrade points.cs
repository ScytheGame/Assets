using TMPro;
using UnityEngine;

public class Upgradepoints : MonoBehaviour
{
    int Level;
    int KillCount;
    int TimePlayed;

    public float SolarPoints;
    public float CelestialPoints;

    [SerializeField] bool InMenu;

    [SerializeField] TextMeshProUGUI SolarPointsText;
    [SerializeField] TextMeshProUGUI CelestialPointsText;

    void OnEnable()
    {
        if (InMenu)
        {
            SolarPoints = PlayerPrefs.GetFloat("SolarPoints", 0);
            CelestialPoints = PlayerPrefs.GetFloat("CelestialPoints", 0);
        }
        else
        {
            Level = PlayerPrefs.GetInt("Level", 0);
            KillCount = PlayerPrefs.GetInt("KillCount", 0);
            TimePlayed = PlayerPrefs.GetInt("TimePlayed", 0);

            SolarPoints = PlayerPrefs.GetFloat("SolarPoints", 0);
            CelestialPoints = PlayerPrefs.GetFloat("CelestialPoints", 0);

            SolarPoints += Mathf.Round(Level / 10);
            SolarPoints += Mathf.Round(KillCount / 20);
            SolarPoints += Mathf.Round(TimePlayed / 10);

            PlayerPrefs.SetFloat("SolarPoints", SolarPoints);
            PlayerPrefs.SetFloat("CelestialPoints", CelestialPoints);
            Save();
        }
    }

    void Update()
    {
        SolarPointsText.text = ("Solar Points: " + SolarPoints);
        CelestialPointsText.text = ("CelestialPoints: " + CelestialPoints);
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("SolarPoints", SolarPoints);
        PlayerPrefs.SetFloat("CelestialPoints", CelestialPoints);
    }
}
