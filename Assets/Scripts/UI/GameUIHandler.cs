using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI healthPotionText;
    [SerializeField] private GameObject selectedObject;

    public EventSystem eventSystem;
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;


    void Update()
    {
        coinText.text = GameManager.Instance.inventory.coins.ToString();

        healthPotionText.text = GameManager.Instance.inventory.healthPotions.ToString();

        if (eventSystem.currentSelectedGameObject == null && Gamepad.current != null)
        {
            
                eventSystem.SetSelectedGameObject(selectedObject);
            
            
            
        }
    }

    public void OpenOptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Destroy(GameManager.Instance.player.gameObject);
        Destroy(GameManager.Instance.gameObject);
        Destroy(GameManager.Instance.gameUI.gameObject);
        Destroy(GameManager.Instance.inventory.gameObject);
    }

    
}
