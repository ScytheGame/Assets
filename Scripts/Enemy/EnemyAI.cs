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
        Speed = PlayerPrefs.GetFloat("EnemySpeed", 15);
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
        offset = new Vector3(RandomValue(100), RandomValue(100), RandomValue(100));
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
        Position = transform.position;
        Agent.SetDestination(Position);
    }

    float RandomValue(float Value)
    {
        float RandomValue = Random.Range(-Value, Value);
        return RandomValue;
    }
}