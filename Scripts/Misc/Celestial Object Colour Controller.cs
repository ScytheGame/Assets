using SimpleKeplerOrbits;
using System.Threading.Tasks;
using UnityEngine;

public class CelestialObjectColourController : MonoBehaviour
{
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] KeplerOrbitMover KeplerOrbitMover;

    public void SetColour(Color colour, Transform Atractor = null)
    {
        SpriteRenderer.color = colour;
        if (KeplerOrbitMover != null)
        {
            KeplerOrbitMover.AttractorSettings.AttractorObject = Atractor;
            KeplerOrbitMover.SetAutoCircleOrbit();
        }
    }
}
