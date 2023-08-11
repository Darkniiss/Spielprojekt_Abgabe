using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IInteractable
{
    [SerializeField] int sceneIndex;
    [SerializeField] Vector2 scenePosition;
    
    public void Interact()
    {
        GameManager.Instance.player.transform.position = scenePosition;
        SceneManager.LoadScene(sceneIndex);
    }

    
}
