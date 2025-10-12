using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;
using SimpleKeplerOrbits;

public class SystemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> solarSystems;
    [SerializeField] GameObject BlackHole;
    [DictionaryDrawerSettings(KeyLabel = "Position", ValueLabel = "Solar System Object")]
    Dictionary<Vector2, GameObject> SpawnedSystems = new Dictionary<Vector2, GameObject>();
    public float SizeY = 28000;
    public float spawnDelay = 0f;
    public float SystemCount;
    public float MaxSystemCount;
    public float MinimumDistanceToOtherSystem = 1500;
    private void Start()
    {
        Spawn();
    }

    async void Spawn()
    {
        for (int i = 0;  i < MaxSystemCount; i++)
        {
            if (SystemCount < MaxSystemCount)
            {
                SpawnSystem();
                SystemCount++;
                await Task.Delay(10);
            }
        }
    }

    void SpawnSystem()
    {
        long Time = System.DateTime.Now.Ticks;
        int seed = (int)(Time % int.MaxValue);
        UnityEngine.Random.InitState(seed);

        int RandomSystem = UnityEngine.Random.Range(0, solarSystems.Count);

        Vector2 Position = Vector2.zero;
        bool ValidPosition = false;
        int TryCount = 20;
        int CurrentTry = 0;

        while (!ValidPosition)
        {
            CurrentTry++;
            Position = new Vector2(0, UnityEngine.Random.Range(-SizeY, SizeY));
            if (CheckForValidPosition(Position))
                ValidPosition = true;
            else
                ValidPosition = false;

            if (CurrentTry >= TryCount)
            {
                return;
            }
        }
        Quaternion Rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));

        var system = Instantiate(solarSystems[RandomSystem], Position, Rotation, transform);

        system.GetComponent<Planet>().SetAttractor(BlackHole.transform, 100000);
        system.GetComponent<KeplerOrbitMover>().TimeScale = UnityEngine.Random.Range(1, 3);

        SpawnedSystems.Add(Position, system);
    }
    bool CheckForValidPosition(Vector2 Position)
    {
        if (SpawnedSystems.Count > 0)
        {
            foreach (var system in SpawnedSystems)
            {
                Vector2 OtherSystemPosition = system.Key;

                float Distance = Vector2.Distance(OtherSystemPosition, Position);

                if (Distance < MinimumDistanceToOtherSystem)
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
