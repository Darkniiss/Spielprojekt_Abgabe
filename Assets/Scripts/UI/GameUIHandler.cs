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
    private GameObject currentObject;

    public EventSystem eventSystem;
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;

    private void Start()
    {
        currentObject = eventSystem.currentSelectedGameObject;
    }

    void Update()
    {
        coinText.text = GameManager.Instance.inventory.coins.ToString();

        healthPotionText.text = GameManager.Instance.inventory.healthPotions.ToString();

        if (currentObject == null && Gamepad.current != null && menu.gameObject.activeSelf)
        {
            
                eventSystem.SetSelectedGameObject(selectedObject);
            currentObject = eventSystem.currentSelectedGameObject;
            
            
        }
    }

    public void OpenOptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
        currentObject = null;
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
