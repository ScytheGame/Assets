using UnityEngine;

public class MissileExplosionEnemy : MonoBehaviour
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
        if (col.gameObject.name == "Enemy(Clone)")
        {

        }
        else if (col.gameObject.name == "Enemy Variant(Clone)")
        {

        }
        else
        {
            var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
            
            Destroy(gameObject);
        }
    }
}
