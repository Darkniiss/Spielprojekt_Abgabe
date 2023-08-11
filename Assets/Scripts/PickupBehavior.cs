using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour, IPickup
{
    private AudioSource pickupAudio;
    [SerializeField] private AudioClip pickupSound;
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
        pickupAudio.PlayOneShot(pickupSound);
        Destroy(gameObject);
    }
}
