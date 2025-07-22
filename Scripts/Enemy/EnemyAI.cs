using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] PlayerController PlayerController;
    [SerializeField] float Distance;
    [SerializeField] float MinDistance;
    [SerializeField] float TeleportDistance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyController EnemyController;
    [SerializeField] NavMeshAgent Agent;
    [SerializeField] Vector2 Position;
    [SerializeField] Vector2 offset;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateUpAxis = false;
        Player = GameObject.FindWithTag("Player");
        PlayerController = Player.GetComponent<PlayerController>();
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
            GoToNearestWormhole();
        }

        FollowPlayer();



    }

    void GoToNearestWormhole()
    {
        Position = FindClosestCelestialObject().position;
        Agent.SetDestination(Position);
    }
    Transform FindClosestCelestialObject()
    {
        float distanceToClosestCelestialObject = Mathf.Infinity;
        GameObject closestCelestialObject = null;

        GameObject[] AllCelestialObject = GameObject.FindGameObjectsWithTag("CelestialObject");

        foreach (GameObject CurrentCelestialObject in AllCelestialObject)
        {
            float distanceToCelestialObject = (CurrentCelestialObject.transform.position - transform.position).sqrMagnitude;

            if (distanceToCelestialObject < distanceToClosestCelestialObject)
            {
                distanceToClosestCelestialObject = distanceToCelestialObject;
                closestCelestialObject = CurrentCelestialObject;
            }
        }

        if (closestCelestialObject != null)
        {
            return closestCelestialObject.transform;
        }
        else
        {
            return null;
        }
    }

    void FollowPlayer()
    {
        offset = new Vector2(RandomValue(10), RandomValue(10));
        Position = (Vector2)Player.transform.position;
        Position += (PlayerController.GetPlayerVelocity() * offset);
        Agent.SetDestination(Position);
    }
    float RandomValue(float Value)
    {
        float RandomValue = Random.Range(-Value, Value);
        return RandomValue;
    }
}