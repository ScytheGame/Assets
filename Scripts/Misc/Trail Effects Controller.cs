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
            IsTrail = true;
        }
    }

    public void DropDownTrail(int Index)
    {
        if (Index == 1)
        {
            ToggleTrail();
        }
        else if (Index == 2)
        {
            ToggleParticles();
        }
    }

    public void ToggleTrail()
    {
        IsTrail = true;
        IsParticles = false;
        Save();
    }
    public void ToggleParticles()
    {
        IsTrail = false;
        IsParticles = true;
        Save();
    }
    void Save()
    {
        PlayerPrefs.SetInt("IsTrail", (IsTrail ? 1 : 0));
        PlayerPrefs.SetInt("IsParticles", (IsParticles ? 1 : 0));
    }
}

