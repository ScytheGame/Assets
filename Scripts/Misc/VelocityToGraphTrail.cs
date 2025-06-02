using UnityEngine;
using UnityEngine.VFX;

public class VelocityToGraphTrail : MonoBehaviour
{
    public VisualEffect vfx;
    private Vector3 lastPosition;
    float Speed;

    void FixedUpdate()
    {
        Speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        lastPosition = transform.position;

        vfx.SetFloat("Speed", Speed);
    }

}
