using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject Planet1;
    public GameObject Planet2;
    public float radius;

    void Start()
    {
        SpawnSphereOnEdgeRandomly2D(Planet1);
        SpawnSphereOnEdgeRandomly2D(Planet2);
    }
    private void SpawnSphereOnEdgeRandomly2D(GameObject Planet)
    {
       long Time = System.DateTime.Now.Ticks;
        int seed = (int)(Time% int.MaxValue);
        UnityEngine.Random.InitState(seed);

        radius = UnityEngine.Random.Range(150, 300);
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;

        Vector3 direction = randomPos - transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.y;
        randomPos.z = 0;

        GameObject go = Instantiate(Planet, randomPos, Quaternion.identity);
        go.transform.position = randomPos;
    }
}