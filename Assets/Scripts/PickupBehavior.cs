using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour, IPickup
{
    public void PickupItem()
    {
        if(gameObject.layer == 11)
        {
            InventoryManager.Instance.coins++;
        }
        //else if(gameObject.name == "HealthPotion")
        //{
        //    InventoryManager.Instance.healthPotions++;
        //}

        Destroy(gameObject);
    }
}
