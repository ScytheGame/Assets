using SimpleKeplerOrbits;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Planet : MonoBehaviour
{
    [SerializeField] KeplerOrbitMover KeplerOrbitMover;
    [SerializeField] GameObject Moon;
    [SerializeField] float Mass;
    public bool IsSystem = false;
    public bool IsMoon = false;
    bool Done = false;
    public void SetAttractor (Transform Attractor, float AttractorMass)
    {

        KeplerOrbitMover.AttractorSettings.AttractorObject = Attractor;
        KeplerOrbitMover.AttractorSettings.AttractorMass = AttractorMass;
        Mass = 10000;

        if (!IsMoon && !IsSystem)
        {
            int MoonChance = Random.Range(0, 4);

            if (MoonChance >= 3)
            {
                Vector3 Position = new Vector3(UnityEngine.Random.Range(40, 50), UnityEngine.Random.Range(30, 50), 0) + transform.position;
                var Moon = Instantiate(this.Moon, Position, Quaternion.identity, transform);

                Moon.GetComponent<Planet>().SetAttractor(transform, Mass);

            }
        }
        Done = true;
    }
    void Update()
    {
        if (Done)
        {
            KeplerOrbitMover.enabled = true;
            Done = false;
        }
        else
        {
            KeplerOrbitMover.SetAutoCircleOrbit();
        }
    }
}
