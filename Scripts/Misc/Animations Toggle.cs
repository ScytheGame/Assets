using UnityEngine;

public class AnimationsToggle : MonoBehaviour
{

    [SerializeField] bool Animations;

    void Start()
    {
        Animations = (PlayerPrefs.GetInt("AnimationsActive") != 0);
    }

    public void Swap()
    {
        Animations = !Animations;
        PlayerPrefs.SetInt("AnimationsActive", (Animations ? 1 : 0));
    }
}
