using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] float Distance;
    [SerializeField] float MinDistance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyController EnemyController;
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Vector3 Position;
 
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
        if (Distance >= MinDistance)
            FollowPlayer();
        else
            Sit();



    }

    void FollowPlayer()
    {
        Position = Player.transform.position;
        Agent.SetDestination(Position);
    }
    void Sit()
    {
        Position = transform.position;
        Agent.SetDestination(Position);
    }
}