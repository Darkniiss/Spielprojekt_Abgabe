using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableUI;
    [SerializeField] private GameObject fleeUI;
    [SerializeField] private TextMeshProUGUI interactableText;
    [SerializeField] private Slider fleeBar;

    private void Update()
    {
        fleeBar.value = (float)GameManager.Instance.player.fleeDuration;
    }

    public void EnableInteractableText()
    {
        interactableUI.SetActive(true);
        interactableText.text = GameManager.Instance.player.interactableGameObject.name.Split(new char[] { '(' })[0];
    }

    public void DisableInteractableText()
    {
        interactableUI.SetActive(false);
    }

    public void EnableFleeBar()
    {
        fleeUI.SetActive(true);
    }

    public void DisableFleeBar()
    {
        fleeUI.SetActive(false);
    }
}
