using System;
using UnityEngine;

public class ExplosionLifetime : MonoBehaviour
{
    public float lifetime = 0.5f;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioSource Source;
    private void Start()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager = audioManager.GetComponent<AudioManager>();
        AudioManager.PlaySFX(AudioManager.Explosion, Source);
        Destroy(gameObject, lifetime);
    }
}
