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
    [SerializeField] private GameObject selectedObject;
    [SerializeField] private EventSystem eventSystem;


    private void Update()
    {
        
        if(eventSystem.currentSelectedGameObject == null && Gamepad.current != null)
        {
            
                eventSystem.SetSelectedGameObject(selectedObject);
            
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
        GameObject currentGameobject = eventSystem.currentSelectedGameObject;
        currentGameobject = null;
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
