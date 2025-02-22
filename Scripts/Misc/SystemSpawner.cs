using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering.VirtualTexturing;

public class SystemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> solarSystems;
    public float radius;
    public float radius2;
    public float spawnDelay = 0f;
    public float SystemCount;
    public float MaxSystemCount;
    private void Update()
    {
        spawner();
        spawnDelay -= Time.deltaTime;
    }

    void spawner()
    {
        for (int i = 0; i < solarSystems.Count; i++)
        {
            if (SystemCount <= MaxSystemCount)
            {
                SpawnSphereWithDelay(solarSystems[i]);
                spawnDelay = 1f;
                SystemCount++;
            }

        }
    }


    void SpawnSphereWithDelay(GameObject solarSystem)
    {
        long Time = System.DateTime.Now.Ticks;
        int seed = (int)(Time % int.MaxValue);
        UnityEngine.Random.InitState(seed);

        radius = UnityEngine.Random.Range(-1800, 1800);
        radius2 = UnityEngine.Random.Range(-1800, 1800);
        Vector3 pos = new Vector3(radius, radius2, 0);
        GameObject go = Instantiate(solarSystem, pos, Quaternion.identity);
        go.transform.position = pos;
    }
}
