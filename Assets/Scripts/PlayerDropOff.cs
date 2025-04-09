using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDropOff : MonoBehaviour
{
    public InventoryManager im;
    public float dropRadius = 1.5f;
    public GameObject dropPopup; // assign this in Inspector
    [SerializeField] QuestController questController;


    void Update()
    {
        GameObject nearestItem = FindNearestDropable();
        bool showPopup = false;

        if (nearestItem != null)
        {
            float distance = Vector2.Distance(transform.position, nearestItem.transform.position);

            if (distance <= dropRadius)
            {
                showPopup = true;

                if (Input.GetKeyDown(KeyCode.E)) // or MouseButtonDown(0)
                {
                    if (questController.currentHouse.name == nearestItem.name)
                    {
                        im.ClearInventory();
                        questController.PizzaQuest();
                    } else
                    {
                        Debug.Log("Wrong house!");
                    }
                }
            }
        }

        // Show or hide the popup
        if (dropPopup != null)
            dropPopup.SetActive(showPopup);
    }


    GameObject FindNearestDropable()
    {
        GameObject[] dropables = GameObject.FindGameObjectsWithTag("House"); // Add this tag to all pickable items
        GameObject closest = null;
        float closestDist = dropRadius;

        foreach (GameObject item in dropables)
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