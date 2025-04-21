using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryQuestController : QuestController
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DeliveryData deliveryData;
    public List<int> currentOrder;
    public GameObject currentHouse;

    private void Start()
    {
        StartCoroutine(WaitThenStartDeliveryQuest());
    }

    private IEnumerator WaitThenStartDeliveryQuest()
    {
        Debug.Log("Waiting for houses to initialize...");
        // If needed, initialize houses
        if (deliveryData.houses == null || deliveryData.houses.Length == 0)
        {
            Debug.Log("Initializing houses...");
            deliveryData.GenerateHouses();
        }

        // Wait until houses are initialized
        yield return new WaitUntil(() => deliveryData.deliveryHouseNames != null && deliveryData.deliveryHouseNames.Count > 0);

        // Now safe to run DeliveryQuest
        DeliveryQuest();
    }




    //Checks if player has all of the pizzas in order in their inventory
    public bool HasRequiredPizzas()
    {
        if (currentOrder != null)
        {
            Dictionary<int, int> pizzaCount = new Dictionary<int, int>();

            //Counting pizzas in current order
            foreach (int pizza in currentOrder)
            {
                if (!pizzaCount.ContainsKey(pizza))
                    pizzaCount[pizza] = 0;

                pizzaCount[pizza]++;
            }

            //Compares each owned amount to current order amount
            foreach (var pair in pizzaCount)
            {
                int type = pair.Key;
                int requiredAmount = pair.Value;

                int ownedAmount = inventoryManager.GetItemCount(type);

                if (ownedAmount < requiredAmount)
                    return false;
            }

            return true;
        }
        else
            return false;
    }

    //Sets quest to delivery
    public void DeliveryQuest()
    {
        string houseName = deliveryData.deliveryHouseNames[deliveryData.deliveryHouseNames.Count - 1];
        deliveryData.deliveryHouseNames.RemoveAt(deliveryData.deliveryHouseNames.Count - 1);

        GameObject house = GameObject.Find(houseName);

        if (house == null)
        {
            Debug.LogError("Could not find house with name: " + houseName);
            return;
        }

        currentHouse = house;

        SetQuest("Deliver the pizza to " + currentHouse.name);
    }
}
