using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown aaDropdown;
    
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
	    resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " +
					 resolutions[i].height;
			options.Add(option);
			if (resolutions[i].width == Screen.currentResolution.width
				  && resolutions[i].height == Screen.currentResolution.height)
				currentResolutionIndex = i;
		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.RefreshShownValue();
		LoadSettings(currentResolutionIndex);
	}
	
	public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        //qualityDropdown.value = 6;
        aaDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
    }

    public void OnAntialiasingChange()
    {
	    
    }
	public void SaveSettings()
	{
		
		PlayerPrefs.SetInt("ResolutionPreference",
				   resolutionDropdown.value);
		
		PlayerPrefs.SetInt("AntiAliasingPreference",
				   aaDropdown.value);
		PlayerPrefs.SetInt("FullscreenPreference",
				   Convert.ToInt32(Screen.fullScreen));
		
	}
	public void LoadSettings(int currentResolutionIndex)
	{
		
		if (PlayerPrefs.HasKey("ResolutionPreference"))
			resolutionDropdown.value =
						 PlayerPrefs.GetInt("ResolutionPreference");
		else
			resolutionDropdown.value = currentResolutionIndex;
		
		if (PlayerPrefs.HasKey("AntiAliasingPreference"))
			aaDropdown.value =
						 PlayerPrefs.GetInt("AntiAliasingPreference");
		else
			aaDropdown.value = 1;
		if (PlayerPrefs.HasKey("FullscreenPreference"))
			Screen.fullScreen =
			Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
		else
			Screen.fullScreen = true;
		
	}
}
