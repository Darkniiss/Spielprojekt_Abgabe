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
        if (gameObject.layer == 9)
        {
            GameManager.Instance.player.weaponDamage = weaponDamage;
            GameManager.Instance.player.weaponCooldown = weaponCooldown;
            GameManager.Instance.player.playerWeaponSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else if (gameObject.layer == 10)
        {
            GameManager.Instance.player.moveSpeed = classMoveSpeed;
            GameManager.Instance.player.healthPoints = classHealthpoints;
            GameManager.Instance.player.playerSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
