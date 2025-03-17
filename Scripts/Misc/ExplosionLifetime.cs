using UnityEngine;

public class ExplosionLifetime : MonoBehaviour
{
    public float lifetime = 0.5f;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioSource Source;
    [SerializeField] bool MakeNoise;
    [SerializeField] float NoiseChance;
    private void Start()
    {
        if (MakeNoise)
        {
            if (Random.Range(0, 1) <= NoiseChance)
            {
                GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
                AudioManager = audioManager.GetComponent<AudioManager>();
                AudioManager.PlaySFX(AudioManager.Explosion, Source);
            }
        }
        Destroy(gameObject, lifetime);
    }
}
