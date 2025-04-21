using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took damage: " + amount + ", Current Health: " + currentHealth);

        spriteRenderer.color = Color.red; // red overlay
        Invoke("ResetColor", 0.1f); // reset overlay after delay

        // set velocity to backward (impulse)
        movement.canMove = false; // Disable player movement
        // reverse direction
        Vector2 direction = -1 * transform.position.normalized;
        rb.velocity = direction * movement.moveSpeed;
        Invoke("ResumeMovement", 0.2f); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ResetColor()
    {
        spriteRenderer.color = Color.white; // Reset color to white
    }
    void ResumeMovement()
    {
        rb.velocity = Vector2.zero; // Stop the player
        movement.canMove = true;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
