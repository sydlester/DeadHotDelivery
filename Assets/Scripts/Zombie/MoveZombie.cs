using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float frameCount = 0;
    public float maxFrameCount = 500;
    public Rigidbody2D rb;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }
        frameCount++;
        // check if the zombie is close to the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(rb.position, player.transform.position);
            if (distance < 10f)
            // if close enough, move towards the player
            {
                MoveTowardsPlayer(player.transform.position);
            }
        }
    }

    // return vector to move zombie towards player
    public void MoveTowardsPlayer(Vector2 playerPosition)
    {
        Vector2 direction = (playerPosition - rb.position).normalized;
        // rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        rb.velocity = direction * moveSpeed;
    }

    // return vector to move zombie randomly
    public void MoveRandomly()
    {
        if (frameCount >= maxFrameCount)
        {
            frameCount = 0;
            float randomY = Random.Range(-1, 1);
            float randomX = Random.Range(-1, 1);
            Vector2 randomDirection = new Vector2(randomX, randomY).normalized;
            rb.velocity = randomDirection * moveSpeed;
        }
    }
}

