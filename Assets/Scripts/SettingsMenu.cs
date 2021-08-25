using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown aaDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown anisotropicDropdown;
    public Slider frameRateSlider;
    private int currentFrameRate = 120;
    public Camera cam;
    Resolution[] resolutions;

    private void Awake()
    {
	    QualitySettings.vSyncCount = 0;
	    Application.targetFrameRate = currentFrameRate;
    }

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

    private void Update()
    {
	    if (Application.targetFrameRate != currentFrameRate)
	    {
		    Application.targetFrameRate = currentFrameRate;
	    }
    }

    public void SetTargetBuffers(RenderTexture targetBuffers)
    {
	    RenderBuffer color = new RenderBuffer();
	    cam.SetTargetBuffers(color, color);
	    
	    
    }
    
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
        
    }

    public void SetAnisotropicFilter(int anisotropicFilter)
    {
	    anisotropicDropdown.value = anisotropicFilter;
	    switch (anisotropicFilter)
	    {
		    case 0:
			    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			    break;
		    case 1:
			    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			    break;
		    case 2:
			    QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			    break;
	    }
    }
    
    public void SetTextureQuality(int textureIndex)
    {
	    QualitySettings.masterTextureLimit = textureIndex;
	    qualityDropdown.value = 6;
    }

    public void SetFrameRate(float frameRate)
    {
	    
	    frameRateSlider.value = frameRate;
	    currentFrameRate = (int) frameRate;
    }
    
    public void SetQuality(int qualityIndex)
    {
	    if (qualityIndex != 6) 
		    
		    QualitySettings.SetQualityLevel(qualityIndex);
	    switch (qualityIndex)
	    {
		    case 0: // quality level - very low
			    textureDropdown.value = 3;
			    aaDropdown.value = 0;
			    break;
		    case 1: // quality level - low
			    textureDropdown.value = 2;
			    aaDropdown.value = 0;
			    break;
		    case 2: // quality level - medium
			    textureDropdown.value = 1;
			    aaDropdown.value = 0;
			    break;
		    case 3: // quality level - high
			    textureDropdown.value = 0;
			    aaDropdown.value = 0;
			    break;
		    case 4: // quality level - very high
			    textureDropdown.value = 0;
			    aaDropdown.value = 1;
			    break;
		    case 5: // quality level - ultra
			    textureDropdown.value = 0;
			    aaDropdown.value = 2;
			    break;
	    }
        
	    qualityDropdown.value = qualityIndex;
    }
	public void SaveSettings()
	{
		
		PlayerPrefs.SetInt("ResolutionPreference",
				   resolutionDropdown.value);
		
		PlayerPrefs.SetInt("AntiAliasingPreference",
				   aaDropdown.value);
		PlayerPrefs.SetInt("FullscreenPreference",
				   Convert.ToInt32(Screen.fullScreen));
		PlayerPrefs.SetFloat("FrameRatePreference",frameRateSlider.value);
		
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
		if (PlayerPrefs.HasKey("FrameRatePreference"))
			frameRateSlider.value = PlayerPrefs.GetFloat("FrameRatePreference");
		else
			frameRateSlider.value = currentFrameRate;
	}

	public void Quit()
	{
		Application.Quit();
	}

}

