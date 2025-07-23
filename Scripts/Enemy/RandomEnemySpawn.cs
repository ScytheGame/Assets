using UnityEngine;
using TMPro;

public class RandomEnemySpawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform Player;
    [SerializeField] GameObject[] Enemy;
    [SerializeField] GameObject[] Bosses;
    [SerializeField] TextMeshProUGUI RunLength;
    [SerializeField] GameSettings GameSettings;
    [SerializeField] StatsController PlayerStatsController;

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
    bool CanSpawnEnemies = true;
    int enemyUpdateMaxCount = 10;
    int num = 20;
    int BossSpawnLevelinterval = 15;
    int BossSpawnLevel = 15;


    void Start()
    {
        UpdateSpawnDelay();
        SpawnEnemies(3);
    }
    void Update()
    {
        //if (GameSettings.EnemySpawnRateFloat >= 1 || GameSettings.EnemySpawnCountFloat >= 1)
        //{
        //    maxCount = GameSettings.EnemySpawnCountFloat;
        //    spawnDelay = GameSettings.EnemySpawnRateFloat;
        //}
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
            if (CanSpawnEnemies)
            {
                SpawnEnemies(Random.Range(1, 2));
                spawnTimer = 0f;
            }
        }

        int PlayerLevel = PlayerStatsController.currentLevel;
        if (PlayerLevel == BossSpawnLevel)
        {
            DeleteEnemies();
            SpawnBoss();
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
                //Debug.Log("spawn delay " + spawnDelay);
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
                int unlockedEnemies = Mathf.Min(1 + (int)(gameTime / 300f), Enemy.Length);

                int RandomEnemy = 0;
                if (unlockedEnemies == Enemy.Length)
                {
                    float bias = Mathf.Clamp01((gameTime - 300f) / 1500f);

                    float rand = Mathf.Pow(Random.value, 1f - bias);
                    RandomEnemy = Mathf.Clamp(Mathf.FloorToInt(rand * Enemy.Length), 0, Enemy.Length - 1);
                }
                else
                {
                    // Only pick from unlocked enemies
                    RandomEnemy = Random.Range(0, unlockedEnemies);
                }
                Instantiate(Enemy[RandomEnemy], groupCenter + Player.position, Quaternion.identity);
                enemyCount++;
                //Debug.Log("enemy count is " + enemyCount);
            }
        }
    }
    void SpawnBoss()
    {
        Vector3 groupCenter;
        do
        {
            groupCenter = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }
        while (Vector3.Distance(groupCenter, Vector3.zero) < minSpawnDistanceFromCenter);

        enemyCount = 0;
        CanSpawnEnemies = false;

        BossSpawnLevel += BossSpawnLevelinterval;

        int RandomEnemy = Random.Range(0, Bosses.Length);
        Instantiate(Bosses[RandomEnemy], groupCenter, Quaternion.identity);

    }
    void DeleteEnemies()
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    }
    public void DefeatedBoss()
    {
        CanSpawnEnemies = true;
    }
}
