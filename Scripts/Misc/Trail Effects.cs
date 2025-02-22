using UnityEngine;

public class TrailEffects : MonoBehaviour
{
    [Header("References")]
    [SerializeField] bool IsTrail;
    [SerializeField] bool IsParticles;
    [SerializeField] GameObject[] Trails;
    [SerializeField] GameObject[] Particles;

    [Header("Explosion Extras")]
    [SerializeField] bool IsExplosion;
    [SerializeField] SpriteRenderer[] Sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);

        if (!IsTrail && !IsParticles)
        {
            IsParticles = true;

            PlayerPrefs.SetInt("IsTrail", (IsTrail ? 1 : 0));
            PlayerPrefs.SetInt("IsParticles", (IsParticles ? 1 : 0));
        }

    }

    // Update is called once per frame
    void Update()
    {
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);
        foreach (GameObject obj in Trails)
        {
            obj.SetActive(IsTrail);
        }
        foreach (GameObject obj in Particles)
        {
            obj.SetActive(IsParticles);
        }

        if (IsExplosion)
        {
            foreach (SpriteRenderer Sprite in Sprite)
            {
                Sprite.enabled = IsTrail;
            }
        }
    }
}
