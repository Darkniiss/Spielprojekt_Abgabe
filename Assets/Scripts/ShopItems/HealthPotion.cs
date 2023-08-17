using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameManager.Instance.inventory.coins >= 1)
        {
            GameManager.Instance.inventory.healthPotions++;
            GameManager.Instance.inventory.coins -= 1;
        }
    }
}
