using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] float Distance;
    [SerializeField] float MinDistance;
    [SerializeField] float TeleportDistance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyController EnemyController;
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Vector3 Position;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateUpAxis = false;
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            Debug.Log("Couldn't find Player");
        }
    }

    void FixedUpdate()
    {
        Agent.speed = Speed;
        Distance = Vector3.Distance(transform.position, Player.transform.position);

        if (Distance >= TeleportDistance)
        {
            Warp();
        }

        if (Distance >= MinDistance)
            FollowPlayer();
        else
            Sit();



    }

    void Warp()
    {
        offset = new Vector3(RandomValue(100), RandomValue(100), 2.5f);
        Position = Player.transform.position + offset;
        Agent.Warp(Position);
    }

    void FollowPlayer()
    {
        offset = new Vector3(RandomValue(10), RandomValue(10), RandomValue(10));
        Position = Player.transform.position + offset;
        Agent.SetDestination(Position);
    }
    void Sit()
    {
        Position = FindClosestEnemy().position;
        Agent.SetDestination(Position);
    }

    Transform FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if (closestEnemy != null)
        {
            return closestEnemy.transform;
        }
        else
        {
            return null;
        }
    }
    float RandomValue(float Value)
    {
        float RandomValue = Random.Range(-Value, Value);
        return RandomValue;
    }
}