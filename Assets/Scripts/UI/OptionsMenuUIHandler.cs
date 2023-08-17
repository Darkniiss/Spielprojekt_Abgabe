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
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private EventSystem eventSystem;
    public GameObject currentObject;

    private static bool resolutionSet;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        List<string> resOptions = new List<string>();

        int curResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(resOption);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resOptions);
        if (!resolutionSet)
        {

            resolutionDropdown.value = curResolutionIndex;
            resolutionSet = true;
        }
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if (currentObject == null && Gamepad.current != null && optionsMenu.gameObject.activeSelf)
        {

            eventSystem.SetSelectedGameObject(selectedObjectOptions);
            currentObject = eventSystem.currentSelectedGameObject;

        }
        else if(currentObject == null && Gamepad.current != null && controlsMenu.gameObject.activeSelf)
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
    }

    public void SetQuality(int _quality)
    {
        QualitySettings.SetQualityLevel(_quality);
    }

    public void SetFullscreen(bool _isFullscreen)
    {
        Screen.fullScreen = _isFullscreen;
    }

    public void SetResolution(int _resolution)
    {
        Screen.SetResolution(resolutions[_resolution].width, resolutions[_resolution].height, Screen.fullScreen);
    }


}
