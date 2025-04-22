using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollisionHandler : MonoBehaviour
{
    [SerializeField] AudioSource damageNoise;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController playerHealth = collision.gameObject.GetComponent<PlayerHealthController>();
            if (playerHealth != null)
            {
                damageNoise.Play();
                playerHealth.TakeDamage(10); // Adjust damage as needed
            }
        }
    }
}
