using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float nextAttackTime = 0f;

    public Weapon weapon; 
    public GameObject attackPopup;

    void Start()
    {
        attackPopup = GameObject.Find("AttackPopup");
        attackPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        weapon = GetComponent<ManagePlayerWeapon>().playerWeapon; // Get the player's weapon from the ManageWeapons script    }
        if (Time.time >= nextAttackTime)
        {
            CheckAttack();
        }
    }

    void CheckAttack()
    {
        GameObject nearestZombie = FindNearestHitable();

        if (nearestZombie != null)
        {
            float distance = Vector2.Distance(transform.position, nearestZombie.transform.position);

            if (distance <= weapon.range)
            {
                // highlight
                nearestZombie.GetComponent<SpriteRenderer>().color = Color.yellow;

                if (attackPopup != null)
                {
                    attackPopup.SetActive(true);
                }
                
                if (Input.GetKeyDown(KeyCode.Q)) // or MouseButtonDown(0)
                {
                    nearestZombie.GetComponent<ZombieHealthController>().TakeDamage(weapon.damage);
                    nextAttackTime = Time.time + weapon.cd;
                }
            }
            if (distance > weapon.range)
            {
                // Reset color if not in range
                nearestZombie.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        if (nearestZombie == null) {
            if (attackPopup != null)
            {
                attackPopup.SetActive(false);
            }
        }
    }
    
    GameObject FindNearestHitable()
    {
        GameObject[] hitables = GameObject.FindGameObjectsWithTag("Zombie"); // Add this tag to all pickable items
        GameObject closest = null;
        float closestDist = weapon.range;

        foreach (GameObject zombie in hitables)
        {
            zombie.GetComponent<SpriteRenderer>().color = Color.white;
            float dist = Vector2.Distance(transform.position, zombie.transform.position);
            if (dist <= closestDist)
            {
                closest = zombie;
                closestDist = dist;
            }
        }

        return closest;
    }
}
