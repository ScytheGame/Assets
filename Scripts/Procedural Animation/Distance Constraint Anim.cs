using System.Collections.Generic;
using UnityEngine;

public class DistanceConstraintAnim : MonoBehaviour
{
    public Transform SpawnHeadTransform;
    public Transform SpawnBodyTransform;
    public GameObject AnchorObject;
    public GameObject Anchor;

    public float ConstrainedDistance = 15;
    public int Length = 15;
    public GameObject TargetObject;
    public List<GameObject> Targets = new List<GameObject>();
    public bool GeneratedEnemy = false;

    Vector3 NormalizedDirection = new Vector3();
    Vector3 ScaledConstraint = new Vector3();
    Vector3[] SegmentPositions;
    float Angle = 0;

    bool FirstLoop = true;
    void Update()
    {
        SpawnBodyTransform.gameObject.SetActive(SpawnHeadTransform.gameObject.activeSelf);

        if (FirstLoop && GeneratedEnemy)
        {
            GenerateHead();
        }

        NormalizedDirection = (Targets[0].transform.position - Anchor.transform.position).normalized;
        ScaledConstraint = NormalizedDirection * ConstrainedDistance;
        Targets[0].transform.position = ScaledConstraint + Anchor.transform.position;

        Angle = Mathf.Atan2(NormalizedDirection.y, NormalizedDirection.x) * Mathf.Rad2Deg;
        Targets[0].transform.rotation = Quaternion.Euler(0, 0, Angle);


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

        }
        FirstLoop = false;
    }
    void GenerateHead()
    {
        Anchor = Instantiate(AnchorObject, transform.position, Quaternion.identity, SpawnHeadTransform);

        var FirstTarget = Instantiate(TargetObject, Vector3.zero, Quaternion.identity, SpawnBodyTransform);
        Targets.Add(FirstTarget);
    }
    void GenerateBody(int i)
    {
        var Target = Instantiate(TargetObject, Vector3.zero, Quaternion.identity, SpawnBodyTransform);
        Targets.Add(Target);

        NormalizedDirection = (Targets[i].transform.position - Targets[i - 1].transform.position).normalized;
        ScaledConstraint = NormalizedDirection * ConstrainedDistance;

        Target.transform.position = ScaledConstraint +  Targets[i - 1].transform.position;

        Angle = Mathf.Atan2(NormalizedDirection.y, NormalizedDirection.x) * Mathf.Rad2Deg;
        Targets[i].transform.rotation = Quaternion.Euler(0, 0, Angle);
    }
}
