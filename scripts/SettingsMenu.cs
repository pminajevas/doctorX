using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource back;
    public AudioSource click;
    public float currentVolume;
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public float GetVolume(){
        float currentVolume;
        bool result = audioMixer.GetFloat("volume", out currentVolume);
        float current = currentVolume;
        if(result){
            volumeSlider.value = current;
            return currentVolume;
        }else{
            return 0f;
        }
    }
    void Start (){
        GameObject.FindGameObjectWithTag("music").GetComponent<MusicClass>().PlayMusic();
        GetVolume();
        int currentResolutionIndex = 0;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for(int i=0;i<resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option); 
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution (int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void playClick(){
        click.Play();
    }
    public void playBack(){
        back.Play();
    }
}
