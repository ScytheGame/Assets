using UnityEngine;

public class TrailEffects : MonoBehaviour
{
    [Header("References")]
    [SerializeField] bool IsTrail;
    [SerializeField] bool IsParticles;
    [SerializeField] bool IsRendered;
    [SerializeField] GameObject[] Trails;
    [SerializeField] GameObject[] Particles;
    [SerializeField] GameObject[] Rendered;

    [Header("Explosion Extras")]
    [SerializeField] bool IsExplosion;
    [SerializeField] SpriteRenderer[] Sprite;

    GameMenu GameMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);
        IsRendered = (PlayerPrefs.GetInt("IsRendered") != 0);

        if (!IsTrail && !IsParticles && !IsRendered)
        {
            IsTrail = true;

            PlayerPrefs.SetInt("IsTrail", (IsTrail ? 1 : 0));
            PlayerPrefs.SetInt("IsParticles", (IsParticles ? 1 : 0));
            PlayerPrefs.SetInt("IsRendered", (IsRendered ? 1 : 0));
        }
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);
        IsRendered = (PlayerPrefs.GetInt("IsRendered") != 0);
        foreach (GameObject obj in Trails)
        {
            obj.SetActive(IsTrail);
        }
        foreach (GameObject obj in Particles)
        {
            obj.SetActive(IsParticles);
        }
        foreach (GameObject obj in Rendered)
        {
            obj.SetActive(IsRendered);
        }

        if (IsExplosion)
        {
            foreach (SpriteRenderer Sprite in Sprite)
            {
                Sprite.enabled = IsTrail;
            }
        }
        GameMenu = GameObject.FindWithTag("Canvas").GetComponent<GameMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMenu.gamePaused)
        {
            IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
            IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);
            IsRendered = (PlayerPrefs.GetInt("IsRendered") != 0);
            foreach (GameObject obj in Trails)
            {
                obj.SetActive(IsTrail);
            }
            foreach (GameObject obj in Particles)
            {
                obj.SetActive(IsParticles);
            }
            foreach (GameObject obj in Rendered)
            {
                obj.SetActive(IsRendered);
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
}
