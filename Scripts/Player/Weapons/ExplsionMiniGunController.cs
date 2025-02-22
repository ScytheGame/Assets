using UnityEngine;

public class ExplosionMiniGunController : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private Transform ExplosionSpawnPoint;
    [SerializeField] private float lifetime = 5f;
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
            var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
            AudioManager.PlaySFX(AudioManager.Explosion, Source);

            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        var Explosion = Instantiate(ExplosionPrefab, ExplosionSpawnPoint.position, ExplosionSpawnPoint.rotation);
        AudioManager.PlaySFX(AudioManager.Explosion, Source);
        Destroy(gameObject);
    }
}