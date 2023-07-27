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
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private AudioMixer mainMixer;

    public void BackToMenu()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetVolume()
    {
        mainMixer.SetFloat("volume", Mathf.Log10(volumeSlider.value) * 20);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }
}
