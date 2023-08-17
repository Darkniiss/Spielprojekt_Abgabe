using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    [SerializeField] protected float chaseSpeed;
    [SerializeField] protected float idleSpeed;
    [SerializeField] protected float weaponDamage;
    [SerializeField] protected float weaponCooldown;
    [SerializeField] protected float detectionRange;
    [SerializeField] protected float fightRange;
    [SerializeField] protected GameObject enemyWeapon;
    [SerializeField] protected GameObject coinPrefab;
    [SerializeField] protected List<AudioClip> weaponSounds;

    protected bool followsPlayer;
    protected bool randomChosen;
    protected bool isFighting;
    protected float timePassed;
    protected float rndX;
    protected float rndY;
    protected float moveVecLength;
    protected Vector2 moveVec;
    protected Rigidbody2D enemyRb;
    protected AudioSource enemyAudio;
    protected SpriteRenderer enemySprite;
    protected SpriteRenderer enemyWeaponSprite;

    public float healthPoints;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAudio = GetComponent<AudioSource>();
        enemySprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        enemyWeaponSprite = enemyWeapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveVec = GameManager.Instance.player.transform.position - transform.position;
        moveVecLength = moveVec.magnitude;

        timePassed += Time.deltaTime;

        RangeDetection();

        FlipSprite();

        if (!followsPlayer && !isFighting)
        {
            IdleMovement();
        }
        else if (isFighting)
        {
            Attack();
        }

        if (healthPoints <= 0)
        {
            Instantiate(coinPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void FlipSprite()
    {
        if (moveVec.x > 0 || rndX > 0)
        {
            enemySprite.flipX = false;
            enemyWeaponSprite.flipX = true;
            enemyWeapon.transform.position = transform.position + new Vector3(0.5f, 0f, 0f);
            enemyWeapon.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
        }
        else if (moveVec.x < 0 || rndX < 0)
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

    private void RangeDetection()
    {
        if (moveVecLength <= detectionRange && moveVecLength >= fightRange)
        {
            enemyRb.velocity = moveVec * chaseSpeed * Time.deltaTime;
            followsPlayer = true;
            isFighting = false;
        }
        else if (moveVecLength < fightRange)
        {
            enemyRb.velocity = Vector2.zero;
            followsPlayer = false;
            isFighting = true;
        }
        else
        {
            followsPlayer = false;
            isFighting = false;
        }
    }

    private void Attack()
    {
        if (timePassed > weaponCooldown)
        {
            PlayWeaponSound();
            GameManager.Instance.player.currentHealthPoints -= weaponDamage;
            timePassed = 0;
        }
    }

    private void PlayWeaponSound()
    {
        int rndIndex = Random.Range(0, weaponSounds.Count);
        enemyAudio.PlayOneShot(weaponSounds[rndIndex]);
    }
}
