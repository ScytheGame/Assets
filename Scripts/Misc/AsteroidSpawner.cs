using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject Asteroid;
    [SerializeField] float AsteroidSpeed;
    [SerializeField] float minX;
    [SerializeField] float minY;
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minSpawnDistanceFromCenter = 5f;
    [SerializeField] float gameTime;
    [SerializeField] float SpawnInterval = 300;
    [SerializeField] float SpawnIntervalIncreaseAmount = 300;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > SpawnInterval)
        {
            StartCoroutine(SpawnAsteroids(5));
            SpawnInterval += SpawnIntervalIncreaseAmount;
        }
    }
    IEnumerator SpawnAsteroids(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            Vector3 groupCenter;
            do
            {
                long Time = System.DateTime.Now.Ticks;
                int seed = (int)(Time % int.MaxValue);
                UnityEngine.Random.InitState(seed);
                groupCenter = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), 0);
            }
            while (Vector3.Distance(groupCenter, Vector3.zero) < minSpawnDistanceFromCenter);

            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

            GameObject AsteroidInstance = Instantiate(Asteroid, groupCenter, spawnRotation);


            Vector2 downLeftDirection = new Vector2(-1f, -1f).normalized;


            AsteroidInstance.GetComponent<Rigidbody2D>().linearVelocity = downLeftDirection * AsteroidSpeed;


            yield return new WaitForSeconds(3f);
        }
    }

}
