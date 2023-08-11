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
        if(gameObject.layer == 11)
        {
            InventoryManager.Instance.coins++;
        }
        //else if(gameObject.name == "HealthPotion")
        //{
        //    InventoryManager.Instance.healthPotions++;
        //}
        pickupAudio.Play();
        

        Destroy(gameObject, 0.1f);
        
        
    }
}
