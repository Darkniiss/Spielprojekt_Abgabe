using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour, IPickup
{
    [SerializeField] private AudioClip coinSound;
    private void Start()
    {
    }

    public void PickupItem()
    {
        GameManager.Instance.soundManager.PlaySound(coinSound);
        if (gameObject.layer == 11)
        {
            Destroy(gameObject);
            GameManager.Instance.inventory.coins++;
        }
        //else if(gameObject.name == "HealthPotion")
        //{
        //    InventoryManager.Instance.healthPotions++;
        //}




    }
}
