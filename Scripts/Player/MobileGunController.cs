using UnityEngine;

public class MobileGunController : MonoBehaviour
{
    public Transform Player;
    public float MaxDistance = 50f;
    public float rotationSpeed = 5f;
    public int Value;
    void Update()
    {
        Transform nearestEnemy = FindClosestEnemy();
        if (nearestEnemy != null)
        {
            float Distance = Vector2.Distance(Player.position, nearestEnemy.position);
            if (Distance <= MaxDistance)
            {
                PointArrowToEnemy(nearestEnemy);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, 0, 0, 0), rotationSpeed * Time.deltaTime);
            }
        }
    }

    Transform FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - Player.position).sqrMagnitude;

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

    void PointArrowToEnemy(Transform enemy)
    {
        Vector3 directionToEnemy = enemy.position - Player.position;

        float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;

        angle += Value;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
