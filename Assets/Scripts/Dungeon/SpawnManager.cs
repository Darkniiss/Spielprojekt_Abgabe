using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>();
    [SerializeField] private GameObject ladderPrefab;
    private bool ladderSpawned;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.currentFloor++;
        SpawnEnemies();
    }

    // Update is called once per frame
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
            Vector2 rndPos = new Vector2(Random.Range(-8, 8), Random.Range(-4, 3));
            Instantiate(enemyPrefabs[rndIndex], rndPos, enemyPrefabs[rndIndex].transform.rotation);
        }
    }

    private void SpawnLadder()
    {
        if (!ladderSpawned)
        {
            Vector2 rndPos = new Vector2(Random.Range(-8, 8), Random.Range(-4, 3));

            Instantiate(ladderPrefab, rndPos, ladderPrefab.transform.rotation);
            ladderSpawned = true;
        }
    }
}
