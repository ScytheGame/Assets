using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BloomSettings : MonoBehaviour
{
    [SerializeField] Toggle BloomThreshold;
    [SerializeField] Toggle BloomIntensity;
    [SerializeField] Toggle BloomScatter;
    [SerializeField] Toggle BloomPerformanceMode;
    [SerializeField] Slider BloomThresholdSlider;
    [SerializeField] Slider BloomIntensitySlider;
    [SerializeField] Slider BloomScatterSlider;
    [SerializeField] GameObject PostProcessing;
    [SerializeField] Volume Volume;
    [SerializeField] Bloom bloom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load();
        PostProcessing = GameObject.FindWithTag("PostProcessing");
        Volume = PostProcessing.GetComponent<Volume>();
        Volume.profile.TryGet<Bloom>(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        if (BloomThreshold.isOn)
        {
            bloom.threshold.value = BloomThresholdSlider.value;
        }
        else if (!BloomThreshold.isOn)
        {
            bloom.threshold.value = 0;
        }
        if (BloomIntensity.isOn)
        {
            bloom.intensity.value = BloomIntensitySlider.value * 20;
        }
        else if (!BloomIntensity.isOn)
        {
            bloom.intensity.value = 0;
        }
        if (BloomPerformanceMode.isOn)
        {
            bloom.highQualityFiltering.value = false;
        }
        else if (!BloomPerformanceMode.isOn)
        {
            bloom.highQualityFiltering.value = true;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("BloomThresholdKey", BloomThreshold.isOn ? 1 : 0);
        PlayerPrefs.SetInt("BloomIntensityKey", BloomIntensity.isOn ? 1 : 0);
        PlayerPrefs.SetInt("BloomPerformanceModeKey", BloomPerformanceMode.isOn ? 1 : 0);

        // Save slider values
        PlayerPrefs.SetFloat("BloomThresholdSliderKey", BloomThresholdSlider.value);
        PlayerPrefs.SetFloat("BloomIntensitySliderKey", BloomIntensitySlider.value);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        BloomThreshold.isOn = PlayerPrefs.GetInt("BloomThresholdKey", 1) == 0;
        BloomIntensity.isOn = PlayerPrefs.GetInt("BloomIntensityKey", 1) == 0;
        BloomPerformanceMode.isOn = PlayerPrefs.GetInt("BloomPerformanceModeKey", 1) == 0;

        BloomThresholdSlider.value = PlayerPrefs.GetFloat("BloomThresholdSliderKey", 0.1f);
        BloomIntensitySlider.value = PlayerPrefs.GetFloat("BloomIntensitySliderKey", 0.1f);

    }
}
