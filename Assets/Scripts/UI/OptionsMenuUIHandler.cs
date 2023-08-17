using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject selectedObjectOptions;
    [SerializeField] private GameObject selectedObjectControls;
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private EventSystem eventSystem;

    private Resolution[] resolutions;
    private List<Resolution> compatibleResolutions = new List<Resolution>();

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;
    public GameObject currentObject;

    private static bool resolutionSet;
    public static int resolutionIndex;
    public static int qualityIndex = 5;
    public static bool isFullscreen = true;
    public static float volumeValue = 1f;

    private void Start()
    {
        resolutions = Screen.resolutions;

        List<string> resOptions = new List<string>();

        int curResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + "x" + resolutions[i].height;
            if (resOption == "640x360" || resOption == "854x480" || resOption == "960x540" || resOption == "1280x720" ||
                resOption == "1366x768" || resOption == "1600x900" || resOption == "1920x1080")
            {
                compatibleResolutions.Add(resolutions[i]);
                resOptions.Add(resOption); ;
            }

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resOptions);
        if (!resolutionSet)
        {
            resolutionDropdown.value = curResolutionIndex;
            resolutionIndex = resolutionDropdown.value;
            resolutionSet = true;
        }
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        resolutionDropdown.value = resolutionIndex;
        qualityDropdown.value = qualityIndex;
        fullscreenToggle.isOn = isFullscreen;
        volumeSlider.value = volumeValue;

        if (currentObject == null && Gamepad.current != null && optionsMenu.gameObject.activeSelf)
        {
            eventSystem.SetSelectedGameObject(selectedObjectOptions);
            currentObject = eventSystem.currentSelectedGameObject;
        }
        else if (currentObject == null && Gamepad.current != null && controlsMenu.gameObject.activeSelf)
        {
            eventSystem.SetSelectedGameObject(selectedObjectControls);
            currentObject = eventSystem.currentSelectedGameObject;
        }
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        currentObject = null;
    }

    public void SetVolume(float _volume)
    {
        mainMixer.SetFloat("volume", Mathf.Log10(_volume) * 20);
        volumeValue = _volume;
    }

    public void SetQuality(int _quality)
    {
        QualitySettings.SetQualityLevel(_quality);
        qualityIndex = _quality;
    }

    public void SetFullscreen(bool _isFullscreen)
    {
        Screen.fullScreen = _isFullscreen;
        isFullscreen = _isFullscreen;
    }

    public void SetResolution(int _resolution)
    {
        Screen.SetResolution(compatibleResolutions[_resolution].width, compatibleResolutions[_resolution].height, Screen.fullScreen);
        resolutionIndex = _resolution;
    }
}
