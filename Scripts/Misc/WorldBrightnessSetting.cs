using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class WorldBrightnessSetting : MonoBehaviour
{

    [SerializeField] Slider WorldBrightnessSlider;
    [SerializeField] Light2D Light2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light2D.intensity = WorldBrightnessSlider.value;
    }
}
