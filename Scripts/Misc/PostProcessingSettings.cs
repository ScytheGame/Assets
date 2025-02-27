using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PostProcessingSettings : MonoBehaviour
{
    [SerializeField] Toggle ChromaticAberrationToggle;
    [SerializeField] Toggle VignetteToggle;
    [SerializeField] Slider ChromaticAberrationSlider;
    [SerializeField] Slider VignetteSlider;
    [SerializeField] GameObject PostProcessing;
    [SerializeField] Volume Volume;
    [SerializeField] Vignette Vignette;
    [SerializeField] ChromaticAberration ChromaticAberration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Load();
        PostProcessing = GameObject.FindWithTag("PostProcessing");
        Volume = PostProcessing.GetComponent<Volume>();
        Volume.profile.TryGet<Vignette>(out Vignette);
        Volume.profile.TryGet<ChromaticAberration>(out ChromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChromaticAberrationToggle.isOn)
        {
            ChromaticAberration.intensity.value = ChromaticAberrationSlider.value;
        }
        else if (!ChromaticAberrationToggle.isOn)
        {
            ChromaticAberration.intensity.value = 0;
        }
        if (VignetteToggle.isOn)
        {
            Vignette.intensity.value = VignetteSlider.value;
        }
        else if (!VignetteToggle.isOn)
        {
            Vignette.intensity.value = 0;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("ChromaticAberation", ChromaticAberrationToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Vignette", VignetteToggle.isOn ? 1 : 0);

        // Save slider values
        PlayerPrefs.SetFloat("ChromaticAberationSlider", ChromaticAberrationSlider.value);
        PlayerPrefs.SetFloat("VignetteSlider", VignetteSlider.value);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        ChromaticAberrationToggle.isOn = PlayerPrefs.GetInt("ChromaticAberation", 1) != 0;
        VignetteToggle.isOn = PlayerPrefs.GetInt("Vignette", 1) != 0;

        ChromaticAberrationSlider.value = PlayerPrefs.GetFloat("ChromaticAberationSlider", 0.1f);
        VignetteSlider.value = PlayerPrefs.GetFloat("VignetteSlider", 0.1f);

    }
}
