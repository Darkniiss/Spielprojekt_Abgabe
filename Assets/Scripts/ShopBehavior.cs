using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{
    [SerializeField] public float weaponDamage;
    [SerializeField] public float weaponCooldown;
    [SerializeField] public float classMoveSpeed;
    [SerializeField] public float classHealthpoints;
    private PlayerController player;
    public bool playerIsInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }

    public void SetShopItem()
    {
        if (gameObject.CompareTag("Weapon"))
        {
            player.weaponDamage = weaponDamage;
            player.weaponCooldown = weaponCooldown;
            player.playerWeaponSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else if (gameObject.CompareTag("Class"))
        {
            player.moveSpeed = classMoveSpeed;
            player.healthPoints = classHealthpoints;
            player.playerSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
