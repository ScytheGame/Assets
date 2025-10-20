using TMPro;
using UnityEngine;
using System.IO;
public class Upgradepoints : MonoBehaviour
{
    public int SolarPoints;
    public int CelestialPoints;

    [SerializeField] bool InMenu;

    [SerializeField] TextMeshProUGUI SolarPointsText;
    [SerializeField] TextMeshProUGUI CelestialPointsText;

    string FilePath;

    void OnEnable()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "UpgradePoints.json");
        Load();

        if (!InMenu)
            Save();
    }

    void FixedUpdate()
    {
        if (InMenu)
        {
            SolarPointsText.text = ("Solar Points: " + SolarPoints);
            CelestialPointsText.text = ("CelestialPoints: " + CelestialPoints);
        }
    }

    public void AddSolarPoints(int Amount)
    {
        SolarPoints += Amount;
        Save();
    }
    public void AddCelestialPoints(int Amount)
    {
        CelestialPoints += Amount;
        Save();
    }
    public void RemoveCelestialPoints(int Amount)
    {
        CelestialPoints -= Amount;
        Save();
    }
    public void RemoveSolarPoints(int Amount)
    {
        SolarPoints -= Amount;
        Save();
    }

    public void Load()
    {
        if (File.Exists(FilePath))
        {
            string Json = File.ReadAllText(FilePath);
            UpgradePointWrapper Data = JsonUtility.FromJson<UpgradePointWrapper>(Json);
            SolarPoints = Data.SolarPoints;
            CelestialPoints = Data.CelestialPoints;
        }
    }
    public void Save()
    {
        UpgradePointWrapper Data = new UpgradePointWrapper
        {
            SolarPoints = this.SolarPoints,
            CelestialPoints = this.CelestialPoints
        };

        string Json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(FilePath, Json);
    }
}
public class UpgradePointWrapper
{
    public int SolarPoints;
    public int CelestialPoints;
}