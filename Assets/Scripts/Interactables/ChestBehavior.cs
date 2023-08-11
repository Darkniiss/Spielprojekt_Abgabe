using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private float weaponDamage;
    [SerializeField] private float weaponCooldown;
    [SerializeField] private Sprite openedChestSprite;
    private SpriteRenderer chestSprite;
    private static bool chestOpened;

    private void Start()
    {
        chestSprite = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (!chestOpened)
        {

        GameManager.Instance.player.weaponCooldown = weaponCooldown;
        GameManager.Instance.player.weaponDamage = weaponDamage;
        GameManager.Instance.player.playerWeaponSprite.sprite = itemSprite;
            chestOpened = true;
            chestSprite.sprite = openedChestSprite;
        }
    }
}
