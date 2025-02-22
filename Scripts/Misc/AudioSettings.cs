using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] AudioManager AudioManager;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] Slider BMGSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Toggle BMGToggle1;
    [SerializeField] Toggle SFXToggle1;
    [SerializeField] bool SFXMuted;
    [SerializeField] bool BMGMuted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject MusicManager = GameObject.FindGameObjectWithTag("MusicManager");
        MusicSource = MusicManager.GetComponent<AudioSource>();
    }
    private void Awake()
    {
        Load();
    }
    // Update is called once per frame
    void Update()
    {
        if (SFXMuted == true)
        {
            AudioManager.Volume = 0;
        }
        else
        {
            AudioManager.Volume = SFXSlider.value;
        }

        if (BMGMuted == true)
        {
            MusicSource.volume = 0;
        }
        else
        {
            MusicSource.volume = BMGSlider.value;
        }
        Save();

        if (BMGToggle1.isOn == true)
        {
            BMGMuted = false;
        }
        else if (BMGToggle1.isOn == false)
        {
            BMGMuted = true;
        }

        if (SFXToggle1.isOn == true)
        {
            SFXMuted = false;
        }
        else if (SFXToggle1.isOn == false)
        {
            SFXMuted = true;
        }
    }

    void Save()
    {
        PlayerPrefs.SetFloat("SFXSlider", SFXSlider.value);
        PlayerPrefs.SetFloat("BMGSlider", BMGSlider.value);
        PlayerPrefs.SetInt("BMGToggle", BMGToggle1.isOn? 1 : 0);
        PlayerPrefs.SetInt("SFXToggle", SFXToggle1.isOn? 1 : 0);
    }
    void Load()
    {
      SFXSlider.value = PlayerPrefs.GetFloat("SFXSlider", 1);
      BMGSlider.value = PlayerPrefs.GetFloat("BMGSlider", 1);
      BMGToggle1.isOn = PlayerPrefs.GetInt("BMGToggle",0) == 1;
      SFXToggle1.isOn = PlayerPrefs.GetInt("SFXToggle",0) == 1;
    }
}
