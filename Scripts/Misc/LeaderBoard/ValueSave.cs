using UnityEngine;

public class ValueSave : MonoBehaviour
{
    [SerializeField] public int Level;
    [SerializeField] public int KillCount;
    [SerializeField] public int TimePlayed;

    [SerializeField] StatsController StatsController;
    [SerializeField] RandomEnemySpawn RandomEnemySpawn;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            StatsController = player.GetComponent<StatsController>();

            if (StatsController == null)
            {
                Debug.LogWarning("StatsController component not found on Player GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'Player' not found.");
            StatsController = null;
        }


        GameObject EnemyGenerator = GameObject.FindWithTag("EnemySpawn");

        if (EnemyGenerator != null)
        {

            RandomEnemySpawn = EnemyGenerator.GetComponent<RandomEnemySpawn>();

            if (RandomEnemySpawn == null)
            {
                Debug.LogWarning("RandomEnemySpawn component not found on EnemyGenerator GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'EnemySpawn' not found.");
            RandomEnemySpawn = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Level = StatsController.currentLevel;
        KillCount = RandomEnemySpawn.KillCount;
        TimePlayed = RandomEnemySpawn.minutes;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("KillCount", KillCount);
        PlayerPrefs.SetInt("TimePlayed", TimePlayed);
    }
}
