using Unity.VisualScripting;
using UnityEngine;

public class TrailEffectsController : MonoBehaviour
{

    [SerializeField] bool IsTrail;
    [SerializeField] bool IsParticles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);

        if (!IsTrail && !IsParticles)
        {
            IsParticles = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Swap()
    {
        if (IsTrail)
        {
            IsTrail = false;
            IsParticles = true;
        }
        else if (IsParticles)
        {
            IsParticles = false;
            IsTrail = true;
        }
        PlayerPrefs.SetInt("IsTrail", (IsTrail ? 1 : 0));
        PlayerPrefs.SetInt("IsParticles", (IsParticles ? 1 : 0));
    }
}

