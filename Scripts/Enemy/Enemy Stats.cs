using Sirenix.OdinInspector;
using UnityEngine;
using System.Collections.Generic;
public class EnemyStats : SerializedMonoBehaviour
{
    public EnemyType EnemyType;
    [SerializeField, DictionaryDrawerSettings(KeyLabel = ("Enemy Type"), ValueLabel = ("Enemy Prefab"))] Dictionary<EnemyType, GameObject> EnemyPrefabs = new Dictionary<EnemyType, GameObject>();
    [SerializeField, DictionaryDrawerSettings(KeyLabel = ("Enemy Type"), ValueLabel = ("Enemy Prefab"))] Dictionary<EnemyType, EnemyData> EnemyData = new Dictionary<EnemyType, EnemyData>();
    float Health;
    float Damage;
    float AttackRate;
    int Level;
    bool isBoss = false;
    Upgradepoints Upgradepoints;

    EnemySpawner EnemySpawner;

    private void Start()
    {
        EnemySpawner = GameObject.FindWithTag("EnemySpawn").GetComponent<EnemySpawner>();
        Upgradepoints = GameObject.FindWithTag("Value").GetComponent<Upgradepoints>();
    }
    private void OnEnable()
    {
        if (EnemyData != null)
        {
            if (EnemyPrefabs.ContainsKey(EnemyType))
            {
                Health = EnemyData[EnemyType].Health;
                Health *= DifficultyGameData.HealthMultiplier;
                Damage = EnemyData[EnemyType].Damage;
                Damage *= DifficultyGameData.DamageMultiplier;
                AttackRate = EnemyData[EnemyType].AttackRate;
                Level = GameObject.FindWithTag("Player").GetComponent<StatsController>().CurrentLevel;
                Level += Mathf.RoundToInt(Random.Range(EnemyData[EnemyType].LevelRange.x + DifficultyGameData.NegativeLevelRange, EnemyData[EnemyType].LevelRange.y + DifficultyGameData.PositiveLevelRange));
                Upgradepoints = GameObject.FindWithTag("Player").GetComponent<Upgradepoints>();

                for (int i = 0; i < Level; i++)
                {
                    int random = Random.Range(0, 3);

                    if (random == 0)
                    {
                        Health *= DifficultyGameData.HealthLevelMultiplier;
                    }
                    else if (random == 1)
                    {
                        Damage *= DifficultyGameData.DamageLevelMultiplier;
                    }
                    else if (random == 2)
                    {
                        if (AttackRate > 0.2f)
                            AttackRate *= 0.95f;
                    }

                }
            }
        }

        if (EnemyPrefabs != null)
        {
            foreach (var enemy in EnemyPrefabs)
            {
                enemy.Value.SetActive(false);
            }

            if (EnemyPrefabs.ContainsKey(EnemyType))
            {
                GameObject EnemyModel = EnemyPrefabs[EnemyType];
                EnemyModel.SetActive(true);
            }
        }

    }

    void CheckIfDead()
    {
        if (Health <= 0)
        {
            if (isBoss)
            {
                Upgradepoints.AddCelestialPoints(1);
                Upgradepoints.AddSolarPoints(10);
                EnemyDied();
            }
            else
            {
                Upgradepoints.AddSolarPoints(1);
                EnemyDied();
            }
        }
    }

    void EnemyDied()
    {
        gameObject.SetActive(false);
        EnemySpawner.EnemyDied(transform.position);
    }

    void TakeDamage(float Damage)
    {
        Health -= Damage;

        CheckIfDead();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag ("player"))
        {
            TakeDamage(col.gameObject.GetComponent<PlayerWeaponStats>().Damage);
        }
    }
}
