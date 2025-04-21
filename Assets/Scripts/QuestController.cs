using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public TMP_Text questText;
    
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DeliveryData deliveryData;
    public Stack<GameObject> deliveryHouses;
    public Stack<List<int>> pizzaOrders;
    public List<int> currentOrder;
    public GameObject currentHouse;

    /// PIZZZAs= 0 is cheese, 1 is veggie and 2 is pepperoni

    void Start()
    {
        deliveryData.Initialize();
    }

    public void Setup()
    {
        Debug.Log("Setup");
        deliveryHouses = deliveryData.deliveryHouses;
        pizzaOrders = deliveryData.pizzaOrders;
        PizzaQuest();
    }


    public void PizzaQuest()
    {
        deliveryData.NewOrder();
        currentOrder = deliveryData.currentOrder;
        currentHouse = deliveryData.currentHouse;
        string[] pizzaNames = { "cheese", "veggie", "pepperoni" };
        Dictionary<int, int> pizzaCount = new Dictionary<int, int>();

        // Count each pizza type
        foreach (int pizza in currentOrder)
        {
            if (!pizzaCount.ContainsKey(pizza))
            {
                pizzaCount[pizza] = 0;
            }
            pizzaCount[pizza]++;
        }

        // Format order string like "2 pepperoni, 1 cheese"
        List<string> orderParts = new List<string>();
        foreach (var pair in pizzaCount)
        {
            int flavor = pair.Key;
            int count = pair.Value;

            if (flavor >= 0 && flavor < pizzaNames.Length)
            {
                string part = count + " " + pizzaNames[flavor];
                orderParts.Add(part);
            }
        }

        string order = string.Join(", ", orderParts);
        SetQuest("Order: " + order);
    
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
        if (deliveryHouses.Count < 0)
        {
            SetQuest("Deliver the pizza to [null]");
            return;
        }
        SetQuest("Deliver the pizza to " + currentHouse.name);
    }

    //Sets top left UI text
    public void SetQuest(string quest)
    {
        questText.text = quest;
    }
}
