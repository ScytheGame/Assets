using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource MusicSource;

    [Header("-----Audio Clip-----")]
    public AudioClip Background;
    public AudioClip Background1;
    public AudioClip Background2;
    public AudioClip Background3;
    public AudioClip Background4;
    public AudioClip Background5;
    public AudioClip MissileShot;
    public AudioClip NukeShot;
    public AudioClip MiniGunShot;
    public AudioClip HomingMissileShot;
    public AudioClip FlakShot;
    public AudioClip DroneShot;
    public AudioClip Explosion;

    [Header("-----SFX Audio-----")]
    public float Volume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int RR = Random.Range(1, 6);
        if (RR == 1)
        {
            MusicSource.clip = Background;
        }
        if (RR == 2)
        {
            MusicSource.clip = Background1;
        }
        if (RR == 3)
        {
            MusicSource.clip = Background2;
        }
        if (RR == 4)
        {
            MusicSource.clip = Background3;
        }
        if (RR == 5)
        {
            MusicSource.clip = Background4;
        }
        if (RR == 6)
        {
            MusicSource.clip = Background5;
        }
        MusicSource.Play();

    }
    private void Update()
    {
        if (MusicSource.isPlaying == false)
        {
            int RR = Random.Range(1, 6);
            if (RR == 1)
            {
                MusicSource.clip = Background;
            }
            if (RR == 2)
            {
                MusicSource.clip = Background1;
            }
            if (RR == 3)
            {
                MusicSource.clip = Background2;
            }
            if (RR == 4)
            {
                MusicSource.clip = Background3;
            }
            if (RR == 5)
            {
                MusicSource.clip = Background4;
            }
            if (RR == 6)
            {
                MusicSource.clip = Background5;
            }
            MusicSource.Play();
        }
    }
    public void PlaySFX(AudioClip clip, AudioSource Source)
    {
        Source.volume = Volume;
        Source.pitch = Random.Range(0.95f, 1f);
        Source.PlayOneShot(clip);
    }
}
