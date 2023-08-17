using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour, IInteractable
{
    [SerializeField] public float classMoveSpeed;
    [SerializeField] public float classHealthpoints;
    [SerializeField] public string className;

    public void Interact()
    {
        if (GameManager.Instance.inventory.coins >= 2)
        {
            if (GameManager.Instance.player.playerSprite.sprite != gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                GameManager.Instance.player.moveSpeed = classMoveSpeed;
                GameManager.Instance.player.maxHealthPoints = classHealthpoints;
                GameManager.Instance.player.playerSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                GameManager.Instance.player.currentClass = className;
                GameManager.Instance.inventory.coins -= 2;
            }
        }
    }
}
