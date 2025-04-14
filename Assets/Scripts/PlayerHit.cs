using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitRadius = 1.5f; //update this to coordinate to the weapon range

    // Update is called once per frame
    void Update()
    {
        GameObject nearestZombie = FindNearestHitable();

        if (nearestZombie != null)
        {
            float distance = Vector2.Distance(transform.position, nearestZombie.transform.position);

            if (distance <= hitRadius)
            {
                if (Input.GetKeyDown(KeyCode.Q)) // or MouseButtonDown(0)
                {
                    // zombie dies
                }
            }
        }
    }

    GameObject FindNearestHitable()
    {
        GameObject[] hitables = GameObject.FindGameObjectsWithTag("Zombie"); // Add this tag to all pickable items
        GameObject closest = null;
        float closestDist = hitRadius;

        foreach (GameObject zombie in hitables)
        {
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
