using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] float Distance;
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
        Speed = PlayerPrefs.GetFloat("EnemySpeed", 10);
    }

    void FixedUpdate()
    {
        Agent.speed = Speed;
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        FollowPlayer();

    }

    void FollowPlayer()
    {
        Position = Player.transform.position;
        Agent.SetDestination(Position);
    }
}