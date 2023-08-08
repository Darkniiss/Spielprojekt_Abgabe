using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public static GameManager Instance { get; private set; }
    public PlayerController player { get;private set; }
    public int currentFloor;
    public int money;

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
    }

    void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            player.playerCanvas.SetActive(true);
        }
        else if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(4))
        {
            player.playerCanvas.SetActive(false);
        }

       
    }
}
