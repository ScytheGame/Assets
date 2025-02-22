using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    Resolution[] resolutions;
    List<Resolution> AcceptableResolutions = new List<Resolution>();
    [SerializeField] TMP_Dropdown ResolutionDropdown;
    List<string> Options = new List<string>();
    int currentResolutionIndex;
    int previousWidth = 1;
    int previousHeight = 1;

    private void Start()
    {
        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == previousWidth && resolutions[i].height == previousHeight)
            {

            }
            else
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                Options.Add(option);
                AcceptableResolutions.Add(resolutions[i]);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }

            }
            previousWidth = resolutions[i].width;
            previousHeight = resolutions[i].height;
        }

        ResolutionDropdown.AddOptions(Options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);

    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int index)
    {
        Resolution resolution = AcceptableResolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
