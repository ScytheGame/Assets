using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] GameObject ExplosionPrefab; 
    [SerializeField] public float Size;
    [SerializeField] public float Damage;
    [SerializeField] string Tag;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tag)
        {
            var Explosion = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Explosion.GetComponent<MineExplosionController>().Size = Size;
            Explosion.GetComponent<MineExplosionController>().Damage = Damage;
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy Mine")
        {
            var Explosion = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Explosion.GetComponent<MineExplosionController>().Size = Size;
            Explosion.GetComponent<MineExplosionController>().Damage = Damage;
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Mine")
        {
            var Explosion = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Explosion.GetComponent<MineExplosionController>().Size = Size;
            Explosion.GetComponent<MineExplosionController>().Damage = Damage;
            Destroy(gameObject);
        }
    }
}
