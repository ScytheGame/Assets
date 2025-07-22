using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class SolarSystemGenerator : MonoBehaviour
{

    [SerializeField] GameObject Star;
    [DictionaryDrawerSettings(KeyLabel = "Position", ValueLabel = "Solar System"), ShowInInspector]
    Dictionary<Vector3, GameObject> SpawnPlanets = new Dictionary<Vector3, GameObject>();
    [SerializeField] int MinNumberOfPlanets;
    [SerializeField] int MaxNumberOfPlanets;
    [SerializeField] float MinimumDistanceToOtherPlanet;
    [SerializeField] float SizeX;
    [SerializeField] float SizeY;
    public float MinimumPlanetSize = 1.5f;
    public float MaximumPlanetSize = 5f;
    private void Start()
    {
        StarColour();
        Spawn();
    }

    void StarColour()
    {
        Color randomStarColor = SolarSystemData.StarColours[Random.Range(0, SolarSystemData.StarColours.Length)];
        Star.GetComponent<CelestialObjectColourController>().SetColour(randomStarColor);
        float Scale = UnityEngine.Random.Range(MinimumPlanetSize / 2, MaximumPlanetSize / 2);
        Star.transform.localScale = new Vector3(Scale, Scale, Scale);
    }


    async void Spawn()
    {
        int SpawnedPlanetCount = 0;
        int NumberOfPlanetsToSpawn = Random.Range(MinNumberOfPlanets, MaxNumberOfPlanets);
        for (int i = 0; i < NumberOfPlanetsToSpawn; i++)
        {
            if (SpawnedPlanetCount < NumberOfPlanetsToSpawn)
            {
                SpawnSystem();
                SpawnedPlanetCount++;
                await Task.Delay(10);
            }
        }
    }
    void SpawnSystem()
    {
        long Time = System.DateTime.Now.Ticks;
        int seed = (int)(Time % int.MaxValue);
        UnityEngine.Random.InitState(seed);

        int RandomPlanet = UnityEngine.Random.Range(0, SolarSystemData.PlanetTypes.Count);

        Vector3 Position = Vector3.zero;
        bool ValidPosition = false;
        int TryCount = 20;
        int CurrentTry = 0;

        while (!ValidPosition)
        {
            CurrentTry++;
            Position = new Vector3(UnityEngine.Random.Range(-SizeX, SizeX), UnityEngine.Random.Range(-SizeY, SizeY), 0);

            if (CheckForValidPosition(Position))
                ValidPosition = true;
            else
                ValidPosition = false;

            if (CurrentTry >= TryCount)
            {
                Debug.Log("Couldn't find a valid Planet position");
                return;
            }
        }
        Position += transform.position;

        Quaternion Rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));

        var Planet = Instantiate(SolarSystemData.PlanetTypes[RandomPlanet], Position, Rotation, transform);

        Color RandomColour = new Color(Random.value, Random.value, Random.value);
        Planet.GetComponent<CelestialObjectColourController>().SetColour(RandomColour, Star.transform);

        float Scale = UnityEngine.Random.Range(MinimumPlanetSize, MaximumPlanetSize);
        Planet.transform.localScale = new Vector3(Scale, Scale, Scale);

        SpawnPlanets.Add(Position, Planet);

    }
    bool CheckForValidPosition(Vector3 Position)
    {
        if (SpawnPlanets.Count > 0)
        {
            foreach (var planet in SpawnPlanets)
            {
                Vector3 OtherSystemPosition = planet.Key;

                float Distance = Vector3.Distance(OtherSystemPosition, Position);

                if (Distance < MinimumDistanceToOtherPlanet)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return true;
        }
    }
}
