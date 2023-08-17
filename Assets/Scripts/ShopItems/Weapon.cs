using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] public float weaponDamage;
    [SerializeField] public float weaponCooldown;
    [SerializeField] public string weaponName;

    public void Interact()
    {
        if (GameManager.Instance.inventory.coins >= 2)
        {
            if (GameManager.Instance.player.playerWeaponSprite.sprite != gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                GameManager.Instance.player.weaponDamage = weaponDamage;
                GameManager.Instance.player.weaponCooldown = weaponCooldown;
                GameManager.Instance.player.playerWeaponSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                GameManager.Instance.player.currentWeapon = weaponName;
                GameManager.Instance.inventory.coins -= 2;
            }
        }
    }
}
