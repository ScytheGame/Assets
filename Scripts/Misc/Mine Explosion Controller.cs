using UnityEngine;
using UnityEngine.VFX;

public class MineExplosionController : MonoBehaviour
{
    [SerializeField] CircleCollider2D Collider2D;
    [SerializeField] VisualEffect vfx;
    public float Size;
    public float Damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D.radius = Size;
        if (vfx.HasFloat("Radius"))
        {
            vfx.SetFloat("Radius", Size);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
