using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float healthPoints;
    [SerializeField] private GameObject playerWeapon;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private SpriteRenderer playerWeaponSprite;
    private WeaponBehavior playerWeaponBehavior;

    private EnemyBehavior enemyFought;

    private Vector2 moveVec;
    private float timePassed;
    private ClassBehavior classBehavior;
    private WeaponBehavior weaponBehavior;
    private SpriteRenderer classSprite;
    private SpriteRenderer weaponSprite;
    private bool isFighting;
    private bool isInDoorHomeRange;
    private bool isInDoorShopRange;
    private bool isInClassRange;
    private bool isInWeaponRange;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        DontDestroyOnLoad(this);

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

    public void Interact(InputAction.CallbackContext context)
    {
        if(isInDoorHomeRange && context.performed)
        {
            Scene activeScene = SceneManager.GetActiveScene();

            if(activeScene == SceneManager.GetSceneByName("HomeScene"))
            {
                SceneManager.LoadScene("TownScene");
                transform.position = new Vector2(-7.5f, 1.5f);
            }
            else if(activeScene == SceneManager.GetSceneByName("TownScene"))
            {
            SceneManager.LoadScene("HomeScene");
                transform.position = new Vector2(-1.5f, -1.5f);
            }
        }
        else if(isInDoorShopRange)
        {
            SceneManager.LoadScene("ShopScene");
        }
        else if(isInClassRange && context.performed)
        {
            playerSprite.sprite = classSprite.sprite;
            moveSpeed = classBehavior.classMoveSpeed;
            healthPoints = classBehavior.classHealthpoints;
        }
        else if(isInWeaponRange && context.performed)
        {
            playerWeaponSprite.sprite = weaponSprite.sprite;
            playerWeaponBehavior.weaponDamage = weaponBehavior.weaponDamage;
            playerWeaponBehavior.weaponCooldown = weaponBehavior.weaponCooldown;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
        enemyFought = collision.gameObject.GetComponent<EnemyBehavior>();
        isFighting = true;

        }
        else if(collision.gameObject.layer == 9 && collision.gameObject.CompareTag("Class"))
        {
            classBehavior = collision.gameObject.GetComponent<ClassBehavior>();
            classSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            isInClassRange = true;
        }
        else if(collision.gameObject.layer == 9 && collision.gameObject.CompareTag("Weapon"))
        {
            weaponBehavior = collision.gameObject.GetComponent<WeaponBehavior>();
            weaponSprite = collision.gameObject.GetComponent <SpriteRenderer>();
            isInWeaponRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && collision.gameObject.name == "DoorHome")
        {
            isInDoorHomeRange = true;
        }
        else if (collision.gameObject.layer == 9 && collision.gameObject.name == "DoorShop")
        {
            isInDoorShopRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {

            isFighting = false;
        }
        else if (collision.gameObject.layer == 9 && collision.gameObject.name == "DoorHome")
        {
            isInDoorHomeRange = false;
        }
        else if (collision.gameObject.layer == 9 && collision.gameObject.name == "DoorShop")
        {
            isInDoorShopRange = false;
        }
        else if(collision.gameObject.layer == 9 && collision.gameObject.CompareTag("Class"))
        {
            isInClassRange = false;
        }
        else if(collision.gameObject.layer == 9 && collision.gameObject.CompareTag("Weapon"))
        {
            isInWeaponRange = false;
        }
    }
}
