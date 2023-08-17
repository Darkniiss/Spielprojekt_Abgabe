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
    [SerializeField] private TextMeshProUGUI floorText;
    [SerializeField] public GameObject currentObject;

    public EventSystem eventSystem;
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    public GameObject pauseMenu;

    void Update()
    {
        coinText.text = GameManager.Instance.inventory.coins.ToString();

        healthPotionText.text = GameManager.Instance.inventory.healthPotions.ToString();

        floorText.text = $"Current Floor: {GameManager.Instance.currentFloor}\nHighest Floor: {GameManager.Instance.highestFloor}";

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

    public void OpenControlsMenu()
    {
        menu.SetActive(false);
        controlsMenu.SetActive(true);
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
