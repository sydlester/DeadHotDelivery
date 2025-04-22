using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerDropOff : MonoBehaviour
{
    public InventoryManager im;
    public float dropRadius = 1.5f;
    public GameObject dropPopup; 
    [SerializeField] DeliveryQuestController questController;
    [SerializeField] DeliveryData deliveryData;
    AudioSource[] audioSources;

    void Update()
    {
        bool showPopup = false;
        GameObject nearestItem = FindNearestDropable();
        if (nearestItem != null)
        {
            float distance = Vector2.Distance(transform.position, nearestItem.transform.position);
            //If inside radius, show drop option and allow the player to deliver
            if (distance <= dropRadius)
            {
                showPopup = true;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    audioSources = nearestItem.GetComponents<AudioSource>();
                    Debug.Log(audioSources.Length);
                    if (questController.currentHouse.name == nearestItem.name)
                    {
                        audioSources[0].Play();
                        im.ClearInventory();
                        showPopup = false;
                        questController.SetQuest("Return to the Pizza Place!");
                    }
                    else
                    {
                        audioSources[1].Play();
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
        GameObject closest = null;
        float closestDist = dropRadius;
        // Debug.Log(deliveryData.houses.Length);
        // Debug.Log(deliveryData.deliveryHouses.Count);
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