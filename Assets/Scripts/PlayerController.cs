using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float maxHealthPoints;
    public float currentHealthPoints;
    public float weaponDamage;
    public float weaponCooldown;
    [SerializeField] private GameObject playerWeapon;
    private AudioSource playerAudio;
    [SerializeField] private List<AudioClip> weaponSounds;
    public GameObject healthBar;
    private Rigidbody2D playerRb;

    public string currentClass;
    public string currentWeapon;

    private EnemyBehavior enemyFought;

    public SpriteRenderer playerSprite;
    public SpriteRenderer playerWeaponSprite;
    public IInteractable interactable;
    public IPickup pickup;



    private Vector2 moveVec;
    private float timePassed;


    private bool isFighting;


    private void Awake()
    {

        playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        currentHealthPoints = maxHealthPoints;
        playerWeaponSprite = playerWeapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {

            timePassed += Time.deltaTime;

            playerRb.velocity = (moveVec * moveSpeed * Time.deltaTime);



            FlipSprite();
        }
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
        if (!GameManager.Instance.isPaused)
        {

            moveVec = context.ReadValue<Vector2>();
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (timePassed > weaponCooldown && isFighting && !GameManager.Instance.isPaused && context.performed)
        {
            PlayWeaponSound();
            enemyFought.healthPoints -= weaponDamage;
            timePassed = 0;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (interactable != null && context.performed && !GameManager.Instance.isPaused)
        {
            interactable.Interact();
        }
    }

    public void Flee(InputAction.CallbackContext context)
    {
        if (context.duration > 2 && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4) && !GameManager.Instance.isPaused)
        {
            SceneManager.LoadScene(2);
            GameManager.Instance.currentFloor = 0;
            transform.position = new Vector2(5f, -5.5f);
        }
    }

    public void UseHealthPotion(InputAction.CallbackContext context)
    {
        if (context.performed && GameManager.Instance.inventory.healthPotions >= 1)
        {
            currentHealthPoints += 5;
            GameManager.Instance.inventory.healthPotions--;
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!GameManager.Instance.isPaused)
            {
                GameManager.Instance.gameUI.currentObject = null;
                GameManager.Instance.optionsMenuUI.currentObject = null;
                GameManager.Instance.gameUI.pauseMenu.SetActive(true);
                GameManager.Instance.gameUI.menu.SetActive(true);
                GameManager.Instance.gameUI.optionsMenu.SetActive(false);
                GameManager.Instance.gameUI.controlsMenu.SetActive(false);
                GameManager.Instance.isPaused = true;
                Time.timeScale = 0f;
            }
            else if (GameManager.Instance.isPaused)
            {
                GameManager.Instance.gameUI.pauseMenu.SetActive(false);
                GameManager.Instance.isPaused = false;
                Time.timeScale = 1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactable = collision.gameObject.GetComponent<IInteractable>();
        }
        else if (collision.gameObject.CompareTag("Pickupable"))
        {
            pickup = collision.gameObject.GetComponent<IPickup>();
            pickup.PickupItem();
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enemyFought == null)
        {
            if (collision.gameObject.layer == 7)
            {
                enemyFought = collision.gameObject.GetComponent<EnemyBehavior>();
                isFighting = true;

            }
        }

        if (interactable == null)
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
            enemyFought = null;
            isFighting = false;
        }

    }

    private void PlayWeaponSound()
    {
        int rndIndex = Random.Range(0, weaponSounds.Count);
        playerAudio.PlayOneShot(weaponSounds[rndIndex]);
    }
}
