using UnityEngine;

public class Tentical : MonoBehaviour
{
    [SerializeField] public int Length;
    [SerializeField] LineRenderer LineRenderer;
    [SerializeField] public Vector3[] SegmentPositions;
    [SerializeField] public Vector3[] SegmentV;

    [SerializeField] public Transform Target;
    [SerializeField] public float TargetDistance;
    [SerializeField] public float SmoothSpeed;
    [SerializeField] public float TrailSpeed;

    [SerializeField] int RandomOffset;
    [SerializeField] float WiggleSpeed;
    [SerializeField] float WiggleMagnitude;
    [SerializeField] Transform Wiggle;

    private void Start()
    {
        RandomOffset = UnityEngine.Random.Range(0, 90);
        LineRenderer = GetComponent<LineRenderer>();
        LineRenderer.positionCount = Length;
        SegmentPositions = new Vector3[Length];
        SegmentV = new Vector3[Length];
        ResetPos();
    }
    private void Update()
    {
        Wiggle.localRotation = Quaternion.Euler(0, 0, Mathf.Sin((Time.time + RandomOffset) * WiggleSpeed) * WiggleMagnitude);

        SegmentPositions[0] = Target.position;
        for (int i = 1; i < Length; i++)
        {
            SegmentPositions[i] = Vector3.SmoothDamp(SegmentPositions[i], SegmentPositions[i - 1] + Target.right * TargetDistance, ref SegmentV[i], SmoothSpeed + i / TrailSpeed); 
        }
        LineRenderer.SetPositions(SegmentPositions);
    }
    void ResetPos()
    {
        SegmentPositions[0] = Target.position;
        for (int i = 1; i < Length; i++)
        {
            SegmentPositions[i]  = SegmentPositions[i - 1] + Target.right * TargetDistance;
        }
        LineRenderer.SetPositions(SegmentPositions);
    }
}
