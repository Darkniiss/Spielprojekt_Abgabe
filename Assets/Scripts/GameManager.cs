using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        DontDestroyOnLoad(this);
        Instantiate(playerPrefab, Vector2.zero, playerPrefab.transform.rotation);
    }

    void Update()
    {
        
    }
}
