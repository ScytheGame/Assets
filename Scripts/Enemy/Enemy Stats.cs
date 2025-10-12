using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyData EnemyData;
    float Health;
    float Damage;
    float AttackRate;
    int Level;

    private void Start()
    {
        Health =  EnemyData.Health;
        Damage =  EnemyData.Damage;
        AttackRate =  EnemyData.AttackRate;
        Level =  GameObject.FindWithTag("Player").GetComponent<StatsController>().CurrentLevel;
        Level += Mathf.RoundToInt(Random.Range(EnemyData.LevelRange.x, EnemyData.LevelRange.y));

        for (int i = 0; i < Level; i++)
        {

        }
    }

    private void Update()
    {
        
    }

    void CheckIfDead()
    {
        if (Health <= 0)
        {

        }
    }

    void TakeDamage(float Damage)
    {
        Health -= Damage;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag ("player"))
        {
            TakeDamage(col.GetComponent<PlayerWeaponStats>().Damage);
        }
    }
}
