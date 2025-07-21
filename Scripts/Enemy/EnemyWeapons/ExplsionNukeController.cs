using UnityEngine;

public class ExplosionNukeControllerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private Transform ExplosionSpawnPoint;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float resistance = 20f;
    [SerializeField] private float damage;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);

            Destroy(gameObject);
        }
        for (float i = damage; i < resistance; i++)
        {
            if (damage >= resistance)
            {
                var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);

                Destroy(gameObject);

            }
        }
    }
}
