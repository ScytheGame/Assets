using UnityEngine;

public class PlayerWeaponStats : MonoBehaviour
{
    [SerializeField] GameObject ExplosionObject;

    public float Lifetime;
    public float Damage;
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

}
