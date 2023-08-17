using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClass : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameManager.Instance.inventory.coins >= 3)
        {
            if (GameManager.Instance.player.currentClass == "Berserker")
            {
                GameManager.Instance.player.maxHealthPoints += 2.5f;
                GameManager.Instance.player.moveSpeed += 5f;
                GameManager.Instance.inventory.coins -= 3;
            }
            else if (GameManager.Instance.player.currentClass == "Knight")
            {
                GameManager.Instance.player.maxHealthPoints += 5f;
                GameManager.Instance.player.moveSpeed += 2.5f;
                GameManager.Instance.inventory.coins -= 3;
            }
        }
    }
}
