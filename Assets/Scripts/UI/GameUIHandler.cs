using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI healthPotionText;
    [SerializeField] private GameObject selectedObject;
    [SerializeField] private GameObject startObject;
    public EventSystem eventSystem;
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public static GameUIHandler Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        coinText.text = InventoryManager.Instance.coins.ToString();

        healthPotionText.text = InventoryManager.Instance.healthPotions.ToString();
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
        Destroy(GameUIHandler.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
    }

    public void SetStartObject()
    {
        eventSystem.SetSelectedGameObject(startObject);
    }

    public void SetSelectedObject()
    {
        eventSystem.SetSelectedGameObject(selectedObject);
    }
}
