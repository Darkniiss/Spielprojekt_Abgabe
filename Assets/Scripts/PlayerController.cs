using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float healthPoints;
    public float weaponDamage;
    public float weaponCooldown;
    [SerializeField] private GameObject playerWeapon;
    public GameObject playerCanvas;
    private Rigidbody2D playerRb;

    private EnemyBehavior enemyFought;

    public SpriteRenderer playerSprite;
    public SpriteRenderer playerWeaponSprite;
    public IInteractable interactable;

    

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
        DontDestroyOnLoad(this);

        playerWeaponSprite = playerWeapon.GetComponent<SpriteRenderer>();
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
        if (timePassed > weaponCooldown && isFighting)
        {
            enemyFought.healthPoints -= weaponDamage;
            timePassed = 0;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if(interactable != null && context.performed)
        {
            interactable.Interact();
        }
    }

    public void Flee(InputAction.CallbackContext context)
    {
        if( context.duration > 5 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            SceneManager.LoadScene(2);
            transform.position = new Vector2(5f, -5.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            enemyFought = collision.gameObject.GetComponent<EnemyBehavior>();
            isFighting = true;

        }
        else if(collision.gameObject.CompareTag("Interactable")) 
        {
            interactable = collision.gameObject.GetComponent<IInteractable>();
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(interactable == null)
        {
           if (collision.gameObject.CompareTag("Interactable"))
            {
                interactable = collision.gameObject.GetComponent<IInteractable>();
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactable = null;
        }
        if (collision.gameObject.layer == 7)
        {

            isFighting = false;
        }

    }
}
