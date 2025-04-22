using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PizzaQuestController : QuestController
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] DeliveryData deliveryData;
    public Stack<List<int>> pizzaOrders;
    public List<int> currentOrder;
    [SerializeField] GameController gameController;

    /// PIZZZAs= 0 is cheese, 1 is veggie and 2 is pepperoni

    void Start()
    {
        //if no pizzaOrders is empty, generate pizza
        if (deliveryData.pizzaOrders == null) { deliveryData.InitializePizza(); }
        else
        {
            PizzaQuest();
        }
    }
    
    // public void Setup()
    // {
    //     pizzaOrders = deliveryData.pizzaOrders;
    //     PizzaQuest();
    // }


    public void PizzaQuest()
    {
        pizzaOrders = deliveryData.pizzaOrders;
        if (pizzaOrders.Count > 0)
        {
            //Get new order
            deliveryData.NewOrder();
            currentOrder = deliveryData.currentOrder;
    
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

            // Display in quest text
            string order = string.Join(", ", orderParts);
            SetQuest("Order: " + order);
        }
        else
        {
            SceneManager.LoadScene("WinScreen");
        }

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

}
