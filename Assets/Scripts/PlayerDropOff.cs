using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDropOff : MonoBehaviour
{
    public InventoryManager im;
    public float dropRadius = 1.5f;
    public GameObject dropPopup; 
    [SerializeField] QuestController questController;
    [SerializeField] DeliveryData deliveryData;

    void Update()
    {
        bool showPopup = false;
        GameObject nearestItem = FindNearestDropable();
        if (nearestItem != null)
        {
            Debug.Log("Nearest item: " + nearestItem.name);
            float distance = Vector2.Distance(transform.position, nearestItem.transform.position);
            //If inside radius, show drop option and allow the player to deliver
            if (distance <= dropRadius)
            {
                showPopup = true;
                Debug.Log("Drop popup active");
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (questController.currentHouse.name == nearestItem.name)
                    {
                        im.ClearInventory();
                        showPopup = false;
                        questController.PizzaQuest();
                    }
                    else
                    {
                        Debug.Log("Wrong house!");
                    }
                }
            }
        }
        if (dropPopup != null)
            dropPopup.SetActive(showPopup);
    }

    //Finds nearest house
    GameObject FindNearestDropable()
    {
        GameObject[] dropables = GameObject.FindGameObjectsWithTag("House"); 
        Debug.Log("Dropables: " + dropables.Length);
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