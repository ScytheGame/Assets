using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject Stardust;
    float EnemyCount = 0;
    public float MaxEnemyCount = 0;
    public float SpawnDelay = 0;

    float SpawnTimer = 0;
    float SpawnDistance = 300;

    List<GameObject> Enemies = new List<GameObject>();


    public void Update()
    {
        if (Enemies.Count == 0)
        {

            for (int i = 0; i < MaxEnemyCount; i++)
            {
                var Enemy = Instantiate(EnemyPrefab, Vector3.zero, Quaternion.identity);
                Enemy.SetActive(false);

                Enemies.Add(Enemy);
            }
        }
        SpawnTimer += Time.deltaTime;

        if (SpawnTimer >= SpawnDelay && EnemyCount < MaxEnemyCount)
        {
            SpawnTimer = 0;
            Spawn();
        }
    }

    public void BossSpawned()
    {
        EnemyCount = 1;

    }
    public void EnemyDied(Vector3 Position)
    {
        EnemyCount--;
        var Stardust = Instantiate(this.Stardust, Position, Quaternion.identity);
    }
    public void EnemySpawned()
    {
        EnemyCount++;
    }


    public void Spawn()
    {
        EnemySpawned();
        Vector3 SpawnPosition = Random.onUnitSphere * SpawnDistance;

        for(int i = 0; i < Enemies.Count; i++)
        {
            if (!Enemies[i].activeInHierarchy)
            {
                Enemies[i].transform.position = SpawnPosition;
                Enemies[i].GetComponentInChildren<EnemyStats>().EnemyType = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length);
                Enemies[i].SetActive(true);
                break;
            }
        }
    }

}
