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
        if (gameObject.layer == 13)
        {
        GameManager.Instance.player.transform.position = scenePosition;
        SceneManager.LoadScene(sceneIndex);
            GameManager.Instance.player.interactable = null;

        }
        else
        {
            GameManager.Instance.player.transform.position = scenePosition;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    
}
