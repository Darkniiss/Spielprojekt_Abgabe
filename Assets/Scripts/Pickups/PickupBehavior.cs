using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour, IPickup
{
    [SerializeField] private AudioClip coinSound;

    public void PickupItem()
    {
        GameManager.Instance.soundManager.PlaySound(coinSound);

        if (gameObject.layer == 11)
        {
            Destroy(gameObject);
            GameManager.Instance.inventory.coins++;
        }
    }
}
