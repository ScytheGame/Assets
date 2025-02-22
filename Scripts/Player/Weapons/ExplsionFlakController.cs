using SimpleKeplerOrbits.Examples;
using UnityEngine;

public class ExplosionFlakController : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private Transform ExplosionSpawnPoint;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] Vector2 vector2;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioSource Source;
    private void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
    }
    void Update()
    {

        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            // Original explosion at the weapon's position
            Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
            AudioManager.PlaySFX(AudioManager.Explosion, Source);

            // Angle of the weapon in radians (convert from degrees to radians)
            float angleInRadians = ExplosionSpawnPoint.rotation.eulerAngles.z * Mathf.Deg2Rad;

            // Define offset distance
            float offsetDistance = 1f;

            // Calculate offset positions based on the weapon's angle
            Vector2 offsetPosition1 = new Vector2(
                ExplosionSpawnPoint.position.x + offsetDistance * Mathf.Cos(angleInRadians + 0.3f), // 0.3 radians offset
                ExplosionSpawnPoint.position.y + offsetDistance * Mathf.Sin(angleInRadians + 0.3f)
            );

            Vector2 offsetPosition2 = new Vector2(
                ExplosionSpawnPoint.position.x + offsetDistance * Mathf.Cos(angleInRadians - 0.3f), // -0.3 radians offset
                ExplosionSpawnPoint.position.y + offsetDistance * Mathf.Sin(angleInRadians - 0.3f)
            );

            // Instantiate explosions with the adjusted offset positions and rotations
            Instantiate(ExplosionPrefab, offsetPosition1, ExplosionSpawnPoint.rotation);
            AudioManager.PlaySFX(AudioManager.Explosion, Source);

            Instantiate(ExplosionPrefab, offsetPosition2, ExplosionSpawnPoint.rotation);
            AudioManager.PlaySFX(AudioManager.Explosion, Source);


            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Original explosion at the weapon's position
        Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
        AudioManager.PlaySFX(AudioManager.Explosion, Source);


        // Angle of the weapon in radians (convert from degrees to radians)
        float angleInRadians = ExplosionSpawnPoint.rotation.eulerAngles.z * Mathf.Deg2Rad;

        // Define offset distance
        float offsetDistance = 1f;

        // Calculate offset positions based on the weapon's angle
        Vector2 offsetPosition1 = new Vector2(
            ExplosionSpawnPoint.position.x + offsetDistance * Mathf.Cos(angleInRadians + 0.3f), // 0.3 radians offset
            ExplosionSpawnPoint.position.y + offsetDistance * Mathf.Sin(angleInRadians + 0.3f)
        );

        Vector2 offsetPosition2 = new Vector2(
            ExplosionSpawnPoint.position.x + offsetDistance * Mathf.Cos(angleInRadians - 0.3f), // -0.3 radians offset
            ExplosionSpawnPoint.position.y + offsetDistance * Mathf.Sin(angleInRadians - 0.3f)
        );

        // Instantiate explosions with the adjusted offset positions and rotations
        Instantiate(ExplosionPrefab, offsetPosition1, ExplosionSpawnPoint.rotation);
        AudioManager.PlaySFX(AudioManager.Explosion, Source);

        Instantiate(ExplosionPrefab, offsetPosition2, ExplosionSpawnPoint.rotation);
        AudioManager.PlaySFX(AudioManager.Explosion, Source);



        Destroy(gameObject);
    }
}