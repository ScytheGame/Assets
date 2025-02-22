using UnityEngine;

public class HomingMissileAngleControllerEnemy : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float moveSpeed = 3.0f;
    public Transform weapon;
    private Vector3 currentMoveDirection;

    void Update()
    {
        Transform nearestEnemy = FindClosestEnemy();
        if (nearestEnemy != null)
        {
            PointWeaponToTarget(nearestEnemy);
        }

        MoveWeapon();
    }

    Transform FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;

        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Player");

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
    }

    void PointWeaponToTarget(Transform target)
    {

        // Direction from weapon to the target (enemy)
        Vector3 directionToTarget = target.position - weapon.position;

        // Calculate angle to rotate the weapon towards the target in a 2D plane
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

        // Offset rotation to match weapon's initial orientation, adjust as necessary
        angle += -90f;  // Adjust depending on your weapon's orientation

        // Apply the rotation to the weapon smoothly
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        weapon.rotation = Quaternion.Lerp(weapon.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Update the current movement direction to follow the weapon's rotation smoothly
        currentMoveDirection = weapon.up; // Using weapon's up direction to move forward in 2D

    }

    void MoveWeapon()
    {
        weapon.GetComponent<Rigidbody2D>().linearVelocity = weapon.up * moveSpeed;
    }
}
