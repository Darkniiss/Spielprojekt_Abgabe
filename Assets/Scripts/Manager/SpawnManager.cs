using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private GameObject ladderPrefab;

    private bool ladderSpawned;

    void Start()
    {
        GameManager.Instance.currentFloor++;
        if (GameManager.Instance.highestFloor < GameManager.Instance.currentFloor)
        {
            GameManager.Instance.highestFloor++;
            PlayerPrefs.SetInt("Highscore", GameManager.Instance.highestFloor);
            PlayerPrefs.Save();
        }
        SpawnEnemies();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnLadder();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < GameManager.Instance.currentFloor; i++)
        {
            int rndIndex = Random.Range(0, enemyPrefabs.Count);
            Vector2 rndPos = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));
            Instantiate(enemyPrefabs[rndIndex], rndPos, enemyPrefabs[rndIndex].transform.rotation);
        }
    }

    private void SpawnLadder()
    {
        if (!ladderSpawned)
        {
            Vector2 rndPos = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 2.5f));

            Instantiate(ladderPrefab, rndPos, ladderPrefab.transform.rotation);
            ladderSpawned = true;
        }
    }
}
