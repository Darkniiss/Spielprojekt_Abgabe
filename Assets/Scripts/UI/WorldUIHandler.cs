using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableUI;
    [SerializeField] private TextMeshProUGUI interactableText;

    public void EnableInteractableText()
    {
        interactableUI.SetActive(true);
        interactableText.text = GameManager.Instance.player.interactableGameObject.name;
    }

    public void DisableInteractableText()
    {
        interactableUI.SetActive(false);
    }
}
