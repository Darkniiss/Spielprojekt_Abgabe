using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        Instantiate(playerPrefab, Vector2.zero, playerPrefab.transform.rotation);
    }

    void Update()
    {
        
    }
}
