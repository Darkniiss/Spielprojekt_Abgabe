using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public static GameManager Instance { get; private set; }
    public PlayerController player { get; private set; }
    public InventoryManager inventory { get; private set; }
    public GameUIHandler gameUI { get; private set; }
    public OptionsMenuUIHandler optionsMenuUI { get; private set; }
    public WorldUIHandler worldUI { get; private set; }
    public SoundManager soundManager { get; private set; }
    public int currentFloor;
    public int highestFloor;
    public bool isPaused;
    public bool openedChest;

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

    void Start()
    {

        player = Instantiate(playerPrefab, Vector2.zero, playerPrefab.transform.rotation).GetComponent<PlayerController>();
        worldUI = player.GetComponentInChildren<WorldUIHandler>();
        inventory = GetComponentInChildren<InventoryManager>();
        gameUI = GetComponentInChildren<GameUIHandler>();
        optionsMenuUI = GetComponentInChildren<OptionsMenuUIHandler>();
        soundManager = GetComponentInChildren<SoundManager>();
    }

    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            player.healthBar.SetActive(true);
        }
        else if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(4))
        {
            player.healthBar.SetActive(false);
        }

        if (player.currentHealthPoints <= 0)
        {
            SceneManager.LoadScene(1);
            player.currentHealthPoints = player.maxHealthPoints;
            currentFloor = 0;
            player.transform.position = new Vector2(2, 0);
            GameManager.Instance.inventory.coins = Mathf.Round(GameManager.Instance.inventory.coins / 2);

        }
    }
}
