using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public TMP_Text questText;
    private GameObject[] houses;
    public Stack<GameObject> deliveryHouses;
    Stack<List<int>> pizzaOrders;
    public List<int> currentOrder;
    public GameObject currentHouse;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameController gameController;

    /// PIZZZAs= 0 is cheese, 1 is veggie and 2 is pepperoni
    

    private void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        deliveryHouses = new Stack<GameObject>();
        pizzaOrders = new Stack<List<int>>();

        //generate orders
        GenerateHouses();
        GeneratePizzas();

        PizzaQuest();
    }

    //Generates 2 random houses out of the buldings tagged "House"
    private void GenerateHouses()
    {
        if (houses.Length == 0)
        {
            return;
        }
        int index1 = Random.Range(0, houses.Length);
        int index2;

        do
        {
            index2 = Random.Range(0, houses.Length);
        } while (index2 == index1);

        deliveryHouses.Push(houses[index1]);
        deliveryHouses.Push(houses[index2]);
    }

    //Generates 1 to 3 pizzas for each house
    private void GeneratePizzas() {
        //run for loop for each house
        for (int i = 0; i < deliveryHouses.ToArray().Length; i++)
        {
            // generate random number of pizzas for order between 1 and 3
            int numPizzas = Random.Range(1, 4);
            List<int> pizzasToDeliver = new List<int>();
            //add random pizza type for each num of pizza
            for (int j = 0; j < numPizzas; j++)
            {
                pizzasToDeliver.Add(Random.Range(0, 3));
            }
            pizzaOrders.Push(pizzasToDeliver);

            //Ex. [0,2,2] for 1 cheese, 2 pepperoni
        }

    }


    public void PizzaQuest()
    {
        //If there are no more orders in stack, player wins game
        if (pizzaOrders.Count <= 0)
        {
            currentOrder = null;
            gameController.Win();
        }
        else
        {
            //Pop current order from stack
            currentOrder = pizzaOrders.Pop();
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
        if (deliveryHouses.Count <= 0)
        {
            SetQuest("Deliver the pizza to [null]");
            return;
        }
        currentHouse = deliveryHouses.Pop();
        SetQuest("Deliver the pizza to " + currentHouse.name);
    }

    //Sets top left UI text
    public void SetQuest(string quest)
    {
        questText.text = quest;
    }
}
