using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPickup : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float pickupRadius = 1.5f;
    public GameObject pickupPopup; 


    void Update()
    {
        //Find nearest item, if its within radius, allow it to be picked up
        GameObject nearestItem = FindNearestPickable();
        bool showPopup = false;

        if (nearestItem != null && inventoryManager.NeedMoreOfPizzaType(nearestItem))
        {
            float distance = Vector2.Distance(transform.position, nearestItem.transform.position);

            if (distance <= pickupRadius)
            {
                showPopup = true;
                if (Input.GetKeyDown(KeyCode.E )) 
                {
                    inventoryManager.ItemPicked(nearestItem);
                    showPopup = false;
                }
            }
        }

        if (pickupPopup != null)
            pickupPopup.SetActive(showPopup);
    }

    //Finds nearest pizza
    GameObject FindNearestPickable()
    {
        GameObject[] pickables = GameObject.FindGameObjectsWithTag("Pizza"); 
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
