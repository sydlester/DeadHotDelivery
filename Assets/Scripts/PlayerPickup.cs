using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPickup : MonoBehaviour
{
    public InventoryManager im;
    public float pickupRadius = 1.5f;
    public GameObject pickupPopup; // assign this in Inspector


    void Update()
    {
        GameObject nearestItem = FindNearestPickable();
        bool showPopup = false;

        if (nearestItem != null)
        {
            float distance = Vector2.Distance(transform.position, nearestItem.transform.position);

            if (distance <= pickupRadius)
            {
                showPopup = true;

                if (Input.GetKeyDown(KeyCode.E)) // or MouseButtonDown(0)
                {
                    im.ItemPicked(nearestItem);
                }
            }
        }

        // Show or hide the popup
        if (pickupPopup != null)
            pickupPopup.SetActive(showPopup);
    }


    GameObject FindNearestPickable()
    {
        GameObject[] pickables = GameObject.FindGameObjectsWithTag("Pizza"); // Add this tag to all pickable items
        GameObject closest = null;
        float closestDist = pickupRadius;

        foreach (GameObject item in pickables)
        {
            float dist = Vector2.Distance(transform.position, item.transform.position);
            if (dist <= closestDist)
            {
                closest = item;
                closestDist = dist;
            }
        }

        return closest;
    }
}
