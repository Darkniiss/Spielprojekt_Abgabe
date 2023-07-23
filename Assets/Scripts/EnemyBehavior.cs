using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D enemyRb;
    private bool followsPlayer;
    private bool randomChosen;
    private float timePassed;
    private float rndX;
    private float rndY;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (!randomChosen)
        {
            rndX = Random.Range(-1, 2);
            rndY = Random.Range(-1, 2);

            randomChosen = true;
        }

        if (!followsPlayer && timePassed > 2)
        {
            enemyRb.velocity = new Vector2(rndX, rndY) * moveSpeed * Time.deltaTime;
        }

        if (timePassed > 3 && !followsPlayer)
        {
            enemyRb.velocity = Vector2.zero;
            timePassed = 0;
            randomChosen = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyRb.velocity = (collision.transform.position - transform.position) * moveSpeed * Time.deltaTime;
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
}
