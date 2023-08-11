using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour, IPickup
{
    private AudioSource pickupAudio;

    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
    }

    public void PickupItem()
    {
        pickupAudio.Play();
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
