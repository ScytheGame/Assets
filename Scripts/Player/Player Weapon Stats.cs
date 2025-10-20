using UnityEngine;

public class PlayerWeaponStats : MonoBehaviour
{
    [SerializeField] GameObject ExplosionObject;

    public float Lifetime;
    public float Damage;
    public float BulletHealth;
    public string ID;

    private void Update()
    {
        Lifetime -= Time.deltaTime;
        if (Lifetime < 0)
        {
            Instantiate(ExplosionObject, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) // enemys
        {
            // damage enemy

            Instantiate(ExplosionObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("enemy")) // enemy bullets
        {
            BulletHealth--;
            if (BulletHealth <= 0)
            {
                Instantiate(ExplosionObject, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
