using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] public float weaponDamage;
    [SerializeField] public float weaponCooldown;
    [SerializeField] public float classMoveSpeed;
    [SerializeField] public float classHealthpoints;


    public void Interact()
    {
        if (gameObject.layer == 9 && InventoryManager.Instance.coins >= 2)
        {
            if(GameManager.Instance.player.playerWeaponSprite.sprite != gameObject.GetComponent<SpriteRenderer>().sprite)
            {

            GameManager.Instance.player.weaponDamage = weaponDamage;
            GameManager.Instance.player.weaponCooldown = weaponCooldown;
            GameManager.Instance.player.playerWeaponSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                GameManager.Instance.player.weaponDamage += weaponDamage;
            }

            InventoryManager.Instance.coins -= 2;
        }
        else if (gameObject.layer == 10 && InventoryManager.Instance.coins >= 2)
        {
            if(GameManager.Instance.player.playerSprite.sprite != gameObject.GetComponent<SpriteRenderer>().sprite)
            {

            GameManager.Instance.player.moveSpeed = classMoveSpeed;
            GameManager.Instance.player.maxHealthPoints = classHealthpoints;
            GameManager.Instance.player.playerSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                GameManager.Instance.player.maxHealthPoints += (classHealthpoints/2);
            }
            
            InventoryManager.Instance.coins -= 2;
        }
    }
}
