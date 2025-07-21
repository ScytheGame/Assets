using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetIndicator : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public Transform Player;
    public RectTransform arrowUI;
    public TextMeshProUGUI DistanceText;
    public TextMeshProUGUI ObjectText;
    float MinDistanceForEnemies = 50;
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
            if (Mathf.RoundToInt(Mathf.Sqrt(distanceToClosestEnemy)) > MinDistanceForEnemies)
            {
                ObjectText.text = ("Enemy Detected");
                DistanceText.text = "Distance: " + Mathf.RoundToInt(Mathf.Sqrt(distanceToClosestEnemy)) + "km";
                return closestEnemy.transform;
            }
            else
            {
               return FindClosestCelestialObject();
            }

        }
        else
        {
            return FindClosestCelestialObject();
        }
    }

    Transform FindClosestCelestialObject()
    {
        float distanceToClosestCelestialObject = Mathf.Infinity;
        GameObject closestCelestialObject = null;

        GameObject[] AllCelestialObject = GameObject.FindGameObjectsWithTag("CelestialObject");

        foreach (GameObject CurrentCelestialObject in AllCelestialObject)
        {
            float distanceToCelestialObject = (CurrentCelestialObject.transform.position - Player.position).sqrMagnitude;

            if (distanceToCelestialObject < distanceToClosestCelestialObject)
            {
                distanceToClosestCelestialObject = distanceToCelestialObject;
                closestCelestialObject = CurrentCelestialObject;
            }
        }

        if (closestCelestialObject != null)
        {
            ObjectText.text = ("Celestial Object Detected");
            DistanceText.text = "Distance: " + Mathf.RoundToInt(Mathf.Sqrt(distanceToClosestCelestialObject)) + "km";
            return closestCelestialObject.transform;
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