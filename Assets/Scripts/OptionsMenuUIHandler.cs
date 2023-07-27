using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optionsMenu;
    
    [SerializeField] private AudioMixer mainMixer;

    public void BackToMenu()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetVolume(float _volume)
    {
        mainMixer.SetFloat("volume", Mathf.Log10(_volume) * 20);
    }

    public void SetQuality(int _quality)
    {
        QualitySettings.SetQualityLevel(_quality);
    }

    public void SetFullscreen(bool _isFullscreen)
    {
        Screen.fullScreen = _isFullscreen;
    }
}
