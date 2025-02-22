using UnityEngine;

public class StarController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float particleRadius = 10f; // Radius around the player to simulate particles

    private ParticleSystem particleSystem;
    private ParticleSystem.ShapeModule shape;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shape = particleSystem.shape;

        // Ensure the particle system uses World simulation space
        if (particleSystem.main.simulationSpace != ParticleSystemSimulationSpace.World)
        {
            var main = particleSystem.main;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
        }
    }

    void Update()
    {
        // Update the position of the particle system to follow the player
        transform.position = player.position;

        // Optionally, dynamically adjust the shape size to match the radius
        shape.radius = particleRadius;
    }
}
