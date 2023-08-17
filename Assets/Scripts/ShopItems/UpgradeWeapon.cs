using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeapon : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (GameManager.Instance.inventory.coins >= 3)
        {
            if (GameManager.Instance.player.currentWeapon == "DoubleAxe")
            {
                GameManager.Instance.player.weaponDamage += 2f;
                GameManager.Instance.player.weaponCooldown -= 0.01f;
                GameManager.Instance.inventory.coins -= 3;
            }
            else if (GameManager.Instance.player.currentWeapon == "Sword")
            {
                GameManager.Instance.player.weaponDamage += 1f;
                GameManager.Instance.player.weaponCooldown -= 0.01f;
                GameManager.Instance.inventory.coins -= 3;
            }
        }
    }
}
