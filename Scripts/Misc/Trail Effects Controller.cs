using Unity.VisualScripting;
using UnityEngine;

public class TrailEffectsController : MonoBehaviour
{

    [SerializeField] bool IsTrail;
    [SerializeField] bool IsParticles;
    [SerializeField] bool IsRendered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsTrail = (PlayerPrefs.GetInt("IsTrail") != 0);
        IsParticles = (PlayerPrefs.GetInt("IsParticles") != 0);
        IsRendered = (PlayerPrefs.GetInt("IsRendered") != 0);

        if (!IsTrail && !IsParticles && !IsRendered)
        {
            IsTrail = true;
        }
    }

    public void DropDownTrail(int Index)
    {
        if (Index == 0)
        {
            ToggleTrail();
        }
        else if (Index == 1)
        {
            ToggleParticles();
        }
        else if (Index == 2)
        {
            ToggleRendered();
        }
    }

    public void ToggleTrail()
    {
        IsTrail = true;
        IsParticles = false;
        IsRendered = false;
        Save();
    }
    public void ToggleParticles()
    {
        IsTrail = false;
        IsParticles = true;
        IsRendered = false;
        Save();
    }
    public void ToggleRendered()
    {
        IsTrail = false;
        IsParticles = false;
        IsRendered = true;
        Save();
    }
    void Save()
    {
        PlayerPrefs.SetInt("IsTrail", (IsTrail ? 1 : 0));
        PlayerPrefs.SetInt("IsParticles", (IsParticles ? 1 : 0));
        PlayerPrefs.SetInt("IsRendered", (IsRendered ? 1 : 0));
    }
}

