using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] GameObject Player;
    [SerializeField] float Distance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] EnemyController EnemyController;
 
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            Debug.Log("Couldn't find Player");
        }
        Speed = PlayerPrefs.GetFloat("EnemySpeed", 10);
    }

    void FixedUpdate()
    {
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        FollowPlayer();

    }

    void FollowPlayer()
    {

    }
}