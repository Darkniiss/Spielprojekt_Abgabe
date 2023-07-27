using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject optionsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenOptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    
}
