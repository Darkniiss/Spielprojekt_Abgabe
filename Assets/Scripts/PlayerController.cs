using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject weapon;

    private SpriteRenderer sprite;

    private Vector2 moveVec;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(moveVec * moveSpeed * Time.deltaTime);

        if (moveVec.x > 0)
        {
            sprite.flipX = false;
            weapon.transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
        }
        else if (moveVec.x < 0) 
        {
            sprite.flipX = true;
            weapon.transform.position = transform.position + new Vector3(-0.5f, 0f, 0f);
            weapon.transform.rotation = Quaternion.Euler(0f, 0f, 25f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVec = context.ReadValue<Vector2>();
    }
}
