using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.player.currentHealthPoints = GameManager.Instance.player.currentHealthPoints;
    }
}
