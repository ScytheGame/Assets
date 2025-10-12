using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] public float RotationSpeed = 10;
    [SerializeField] public float RotationOffset;
    private Vector2 Direction;
    Transform Target;
    private void Awake()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Direction = Target.position - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.AngleAxis(Angle + RotationOffset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, RotationSpeed * Time.deltaTime);
    }
}
