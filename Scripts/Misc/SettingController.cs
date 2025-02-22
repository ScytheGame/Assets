using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] Toggle DamageToggle;

    public bool DamageTextEnabled = true;

    void Update()
    {
        if (DamageToggle.isOn)
        {
            DamageTextEnabled = true;
        }
        else if (DamageToggle.isOn == false)
        { 
            DamageTextEnabled = false;
        }
    }
}
