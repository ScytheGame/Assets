using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 5;
    [SerializeField] public float MinEnemyDistance = 3;

    [SerializeField] int MinScale;
    [SerializeField] int MaxScale;

    int Scale;
    Rigidbody2D rb;
    Transform Target;

    private void Awake()
    {
        Target = GameObject.FindWithTag("Player").transform;
        Scale = UnityEngine.Random.Range(MinScale, MaxScale);
        transform.localScale = new Vector3(Scale, Scale, Scale);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            rb.AddForce(transform.up * MoveSpeed);
            AvoidOtherEnemies();
        }
    }

    async void AvoidOtherEnemies()
    {
        GameObject[] AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");


        foreach (GameObject CurrentEnemy in AllEnemies)
        {
            float DistanceToEnemy = (CurrentEnemy.transform.position - transform.position).sqrMagnitude;
            Vector3 OppositeDirectionToEnemy = -(CurrentEnemy.transform.position - transform.position).normalized;

            if (DistanceToEnemy < MinEnemyDistance)
            {
                    rb.AddForce(OppositeDirectionToEnemy * MoveSpeed);
            }
        }
        
    }
}
