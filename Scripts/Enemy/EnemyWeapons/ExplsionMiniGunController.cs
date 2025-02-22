using UnityEngine;

public class ExplosionMiniGunControllerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private Transform ExplosionSpawnPoint;
    [SerializeField] private float lifetime = 5f;

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
            
        Destroy(gameObject);
    }
}
