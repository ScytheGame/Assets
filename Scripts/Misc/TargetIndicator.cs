using UnityEngine;
using UnityEngine.UI;

public class TargetIndicator : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public Transform Player;
    public RectTransform arrowUI;

    void Update()
    {
        Transform nearestEnemy = FindClosestEnemy();
        if (nearestEnemy != null)
        {
            PointArrowToEnemy(nearestEnemy);
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

        angle += -45f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        arrowUI.rotation = Quaternion.Slerp(arrowUI.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}