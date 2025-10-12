using System.Collections.Generic;
using UnityEngine;

public class DistanceConstraintAnim : MonoBehaviour
{
    [SerializeField] GameObject AnchorObject;
    [SerializeField] GameObject Anchor;

    [SerializeField] float ConstrainedDistance = 15;
    [SerializeField] int Length = 15;
    [SerializeField] GameObject TargetObject;
    [SerializeField] public List<GameObject> Targets = new List<GameObject>();
    [SerializeField] bool GeneratedEnemy = false;
    [SerializeField] bool UseLineRenderer = false;
    LineRenderer LineRenderer;

    Vector3 NormalizedDirection = new Vector3();
    Vector3 ScaledConstraint = new Vector3();
    Vector3[] SegmentPositions;
    float Angle = 0;

    bool FirstLoop = true;
    private void Start()
    {
        if (UseLineRenderer)
        {
            LineRenderer = GetComponent<LineRenderer>();
            SegmentPositions = new Vector3[Length + 1];
            LineRenderer.positionCount = Length + 1;
        }
    }
    void Update()
    {


        if (FirstLoop && GeneratedEnemy)
        {
            GenerateHead();
        }

        NormalizedDirection = (Targets[0].transform.position - Anchor.transform.position).normalized;
        ScaledConstraint = NormalizedDirection * ConstrainedDistance;
        Targets[0].transform.position = ScaledConstraint + Anchor.transform.position;

        Angle = Mathf.Atan2(NormalizedDirection.y, NormalizedDirection.x) * Mathf.Rad2Deg;
        Targets[0].transform.rotation = Quaternion.Euler(0, 0, Angle);

        if (UseLineRenderer)
        {
            SegmentPositions[0] = Anchor.transform.position;
            SegmentPositions[1] = Targets[0].transform.position;
        }

        for (int i = 1; i < Length; i++)
        {
            if (FirstLoop && GeneratedEnemy)
            {
                GenerateBody(i);
            }
            else
            {
                NormalizedDirection = (Targets[i].transform.position - Targets[i - 1].transform.position).normalized;
                ScaledConstraint = NormalizedDirection * ConstrainedDistance;

                Targets[i].transform.position = ScaledConstraint +  Targets[i - 1].transform.position;

                Angle = Mathf.Atan2(NormalizedDirection.y, NormalizedDirection.x) * Mathf.Rad2Deg;
                Targets[i].transform.rotation = Quaternion.Euler(0, 0, Angle);
            }

            if (UseLineRenderer)
            {
                SegmentPositions[i + 1] = Targets[i].transform.position;
            }
        }
        if (UseLineRenderer)
        {

            LineRenderer.SetPositions(SegmentPositions);
        }
        FirstLoop = false;
    }
    void GenerateHead()
    {
        Anchor = Instantiate(AnchorObject, transform.position, Quaternion.identity, transform);

        var FirstTarget = Instantiate(TargetObject, Vector3.zero, Quaternion.identity, transform);
        Targets.Add(FirstTarget);
    }
    void GenerateBody(int i)
    {
        var Target = Instantiate(TargetObject, Vector3.zero, Quaternion.identity, transform);
        Targets.Add(Target);

        NormalizedDirection = (Targets[i].transform.position - Targets[i - 1].transform.position).normalized;
        ScaledConstraint = NormalizedDirection * ConstrainedDistance;

        Target.transform.position = ScaledConstraint +  Targets[i - 1].transform.position;

        Angle = Mathf.Atan2(NormalizedDirection.y, NormalizedDirection.x) * Mathf.Rad2Deg;
        Targets[i].transform.rotation = Quaternion.Euler(0, 0, Angle);
    }
}
