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
    List<int> currentOrder;
    public GameObject currentHouse;

    private void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        deliveryHouses = new Stack<GameObject>();
        pizzaOrders = new Stack<List<int>>();

        GenerateHouses();
        GeneratePizzas();

        //PizzaQuest();
        DeliveryQuest();
    }

    private void GenerateHouses()
    {
        int index1 = Random.Range(0, houses.Length);
        int index2;

        do
        {
            index2 = Random.Range(0, houses.Length);
        } while (index2 == index1);

        deliveryHouses.Push(houses[index1]);
        deliveryHouses.Push(houses[index2]);
    }

    private void GeneratePizzas() {
        //run for loop for each house
        for (int i = 0; i < deliveryHouses.ToArray().Length; i++)
        {
            // generate random number of pizzas for order
            int numPizzas = Random.Range(1, 4);
            List<int> pizzasToDeliver = new List<int>();
            //add random pizza type
            for (int j = 0; j < numPizzas; j++)
            {
                pizzasToDeliver.Add(Random.Range(0, 3));
            }
            pizzaOrders.Push(pizzasToDeliver);
        }

    }


    public void PizzaQuest()
    {
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

    public void DeliveryQuest()
    {
        currentHouse = deliveryHouses.Pop();
        SetQuest("Deliver the pizza to " + currentHouse.name);
    }


    public void SetQuest(string quest)
    {
        questText.text = quest;
    }
}
