using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject selectedObject;
    [SerializeField] private EventSystem eventSystem;
    private GameObject currentObject;



    private void Update()
    {
        if (currentObject == null && Gamepad.current != null && menu.gameObject.activeSelf)
        {

            eventSystem.SetSelectedGameObject(selectedObject);
            currentObject = eventSystem.currentSelectedGameObject;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void OpenOptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
        currentObject = null;
    }

    public void OpenControlsMenu()
    {
        menu.SetActive(false);
        controlsMenu.SetActive(true);
        currentObject = null;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
