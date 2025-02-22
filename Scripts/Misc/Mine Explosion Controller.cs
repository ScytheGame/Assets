using UnityEngine;

public class MineExplosionController : MonoBehaviour
{
    [SerializeField] CircleCollider2D Collider2D;
    [SerializeField] ParticleSystem ParticleSystem;
    public float Size;
    public float Damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D.radius = Size;
        ParticleSystem.MainModule main = ParticleSystem.main;
        main.startLifetime =  Size;
        main.startSize = Size;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
