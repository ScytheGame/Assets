using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] float Lifetime;
    [SerializeField] GameObject ExplosionObject;

    private void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime < 0 )
        {
            Instantiate(ExplosionObject, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

}
