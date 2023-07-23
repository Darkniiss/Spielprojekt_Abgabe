using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] public float healthPoints;
    [SerializeField] private GameObject playerWeapon;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private SpriteRenderer playerWeaponSprite;
    private WeaponBehavior playerWeaponBehavior;

    private EnemyBehavior enemyFought;

    private Vector2 moveVec;
    private float timePassed;
    private bool isFighting;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        playerWeaponSprite = playerWeapon.GetComponent<SpriteRenderer>();
        playerWeaponBehavior = playerWeapon.GetComponent<WeaponBehavior>();
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        playerRb.velocity = (moveVec * moveSpeed * Time.deltaTime);

        

        FlipSprite();
    }

    public void FlipSprite()
    {
        

        if (moveVec.x > 0)
        {
            playerSprite.flipX = false;
            playerWeaponSprite.flipX = true;
            playerWeapon.transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
            playerWeapon.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
        }
        else if (moveVec.x < 0)
        {
            playerSprite.flipX = true;
            playerWeaponSprite.flipX = false;
            playerWeapon.transform.position = transform.position + new Vector3(-0.5f, 0f, 0f);
            playerWeapon.transform.rotation = Quaternion.Euler(0f, 0f, 25f);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveVec = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(timePassed > playerWeaponBehavior.weaponCooldown && isFighting)
        {
            enemyFought.healthPoints -= playerWeaponBehavior.weaponDamage;
            timePassed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyFought = collision.gameObject.GetComponent<EnemyBehavior>();
            isFighting = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isFighting = false;
        }
    }
}
