using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer spriteRenderer;    // Start is called before the first frame update
    public MoveZombie moveZombie; // Reference to the MoveZombie script
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveZombie = GetComponent<MoveZombie>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Zombie took damage: " + amount + ", Current Health: " + currentHealth);
        spriteRenderer.color = Color.red; // red overlay
        Invoke("ResetColor", 0.1f); // reset overlay after delay
        moveZombie.canMove = false;
        // set velocity to backward (impulse)
        Vector2 direction = (transform.position - Camera.main.transform.position).normalized;
        moveZombie.rb.velocity = direction * moveZombie.moveSpeed * 2;
        Invoke("ResumeMovement", 0.25f); 

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
        moveZombie.canMove = true; // Resume the zombie's movement
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
