using UnityEngine;
using TMPro;

public class RandomEnemySpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy1;
    [SerializeField] TextMeshProUGUI RunLength;
    [SerializeField] GameSettings GameSettings;

    [Space(10)]
    [Header("RandomGen Coordinates")]
    [SerializeField] float minX;
    [SerializeField] float minY;
    [SerializeField] float maxX;
    [SerializeField] float maxY;
    [SerializeField] float minSpawnDistanceFromCenter = 5f;

    [Space(10)]
    [Header("Enemy Spawn Settings")]
    [SerializeField] float numberOfEnemies;
    public float enemyCount = 0;
    public int KillCount;
    public float maxCount = 15;
    public float spawnDelay = 15;
    private float spawnTimer = 0;
    public float gameTime = 0;
    public int minutes;
    private bool toManyEnemies = false;
    private float timeMinute = 60;
    private float timeChunks = 1;
    private bool spawnEnemy1 = false;
    int bossEnemyChance = 0;
    int enemyUpdateMaxCount = 10;
    int num = 20;

    void Start()
    {
        UpdateSpawnDelay();
        SpawnEnemies(3);
    }
    void Update()
    {
        if (GameSettings.EnemySpawnRateFloat >= 1 || GameSettings.EnemySpawnCountFloat >= 1)
        {
            maxCount = GameSettings.EnemySpawnCountFloat;
            spawnDelay = GameSettings.EnemySpawnRateFloat;
        }
        gameTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        RunLength.text = "Run Length " + $"{minutes:D2}:{seconds:D2}";

        UpdateSpawnDelay();

        spawnTimer += Time.deltaTime;
        if (enemyCount >= maxCount)
        {
            toManyEnemies = true;
        }
        else
        {
            toManyEnemies = false;
        }
        if (spawnTimer >= spawnDelay)
        {
            SpawnEnemies(Random.Range(1, 2));
            spawnTimer = 0f;
        }
        if (minutes > enemyUpdateMaxCount)
        {
            enemyUpdateMaxCount += 5;
            maxCount += 5;

        }
        if (minutes >= num)
        {
            num += 5;
            bossEnemyChance += 1;
            if ( bossEnemyChance > 4)
            {
                bossEnemyChance--;
            }
        }
    }

    void UpdateSpawnDelay()
    {

        if (gameTime >= timeMinute)
        {
            if (gameTime >= timeMinute + timeMinute)
            {
                timeMinute += 60;
                timeChunks++;
                if (spawnDelay >= 4f)
                {
                    spawnDelay -= 2f;
                }
                Debug.Log("spawn delay " + spawnDelay);
            }
        }
    }

    void SpawnEnemies(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            Vector3 groupCenter;
            do
            {
                groupCenter = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            }
            while (Vector3.Distance(groupCenter, Vector3.zero) < minSpawnDistanceFromCenter);

            if (toManyEnemies == false)
            {
                if (Random.Range(1, 11) <= bossEnemyChance)
                {
                    Instantiate(Enemy1, groupCenter, Quaternion.identity);
                    enemyCount++;
                    Debug.Log("enemy count is " + enemyCount);
                }
                else
                {
                    Instantiate(Enemy, groupCenter, Quaternion.identity);
                    enemyCount++;
                    Debug.Log("enemy count is " + enemyCount);
                }
            }
        }
    }
}
