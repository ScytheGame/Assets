using System.Reflection;
using UnityEngine;

public class HomingMissileAngleController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float moveSpeed = 3.0f;
    public float wait = 1;
    public Transform weapon;
    private Vector3 currentMoveDirection;

    void Update()
    {
        if (wait <= 0)
        {
            Transform nearestEnemy = FindClosestEnemy();
            if (nearestEnemy != null)
            {
                PointWeaponToTarget(nearestEnemy);
            }
            MoveWeapon();
        }
        else
        {
            wait -= Time.deltaTime;
        }
    }

    Transform FindClosestEnemy()
    {

            float distanceToClosestEnemy = Mathf.Infinity;
            GameObject closestEnemy = null;

            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - weapon.position).sqrMagnitude;

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
    
        return null;
    }

    void PointWeaponToTarget(Transform target)
    {
        Vector3 directionToTarget = target.position - weapon.position;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        angle += -90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        weapon.rotation = Quaternion.Slerp(weapon.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        currentMoveDirection = weapon.up;

    }

    void MoveWeapon()
    {
        weapon.GetComponent<Rigidbody2D>().linearVelocity = weapon.up * moveSpeed;
        // weapon.position += currentMoveDirection * moveSpeed * Time.deltaTime;
    }
}
