using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float idleSpeed;
    [SerializeField] public float healthPoints;
    [SerializeField] private GameObject enemyWeapon;

    private PlayerController player;
    private Rigidbody2D enemyRb;
    private SpriteRenderer enemySprite;
    private SpriteRenderer enemyWeaponSprite;
    private bool followsPlayer;
    private bool randomChosen;
    private bool isFighting;
    private float timePassed;
    private float rndX;
    private float rndY;


    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        enemyWeaponSprite = enemyWeapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }

        if (!followsPlayer)
        {
        IdleMovement();
        }
        else if(isFighting)
        {
            Attack();
        }

        FlipSprite();

    }

    public void FlipSprite()
    {
        if (enemyRb.velocity.x > 0)
        {
            enemySprite.flipX = false;
            enemyWeaponSprite.flipX = true;
            enemyWeapon.transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
            enemyWeapon.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
        }
        else if (enemyRb.velocity.x < 0)
        {
            enemySprite.flipX = true;
            enemyWeaponSprite.flipX = false;
            enemyWeapon.transform.position = transform.position + new Vector3(-0.5f, 0f, 0f);
            enemyWeapon.transform.rotation = Quaternion.Euler(0f, 0f, 25f);
        }
    }

    private void IdleMovement()
    {
        if (!randomChosen)
        {
            rndX = Random.Range(-1, 2);
            rndY = Random.Range(-1, 2);

            randomChosen = true;
        }

        if (timePassed > 3)
        {
            enemyRb.velocity = Vector2.zero;
            timePassed = 0;
            randomChosen = false;
        }
        else if (timePassed > 2)
        {
            enemyRb.velocity = new Vector2(rndX, rndY) * idleSpeed * Time.deltaTime;
        }
        
    }

    private void Attack()
    {
        if(timePassed > 2)
        {
            player.healthPoints--;
            timePassed = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFighting)
        {
            enemyRb.velocity = (collision.transform.position - transform.position) * chaseSpeed * Time.deltaTime;
            followsPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            followsPlayer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFighting = true;
            timePassed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isFighting = false;
        }
    }
}
