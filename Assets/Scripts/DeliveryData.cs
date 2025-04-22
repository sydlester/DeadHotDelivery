using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DeliveryData", menuName = "ScriptableObjects/DeliveryData", order = 1)]
public class DeliveryData : ScriptableObject
{
    public GameObject[] houses;
    public List<string> deliveryHouseNames = new List<string>();
    public Stack<List<int>> pizzaOrders;
    public List<int> currentOrder;
    public GameObject currentHouse;
    private PizzaQuestController questController;

    public void InitializePizza()
    {
        questController = FindObjectOfType<PizzaQuestController>();

        houses = null;
        deliveryHouseNames = new List<string>();
        deliveryHouseNames.Clear();
        pizzaOrders = new Stack<List<int>>();

        GeneratePizzas();
        questController.PizzaQuest();
    }

    //Generates 2 random houses out of the buldings tagged "House"
    public void GenerateHouses()
    {
        Debug.Log("Generating houses...");
        houses = GameObject.FindGameObjectsWithTag("House");
        if (houses.Length < 2)
        {
            Debug.LogError("Not enough houses found! Need at least 2.");
            return;
        }
        int index1 = Random.Range(0, houses.Length);
        int index2;

        do
        {
            index2 = Random.Range(0, houses.Length);
        } while (index2 == index1);

        deliveryHouseNames.Clear(); // reset before storing new ones
        deliveryHouseNames.Add(houses[index1].name);
        deliveryHouseNames.Add(houses[index2].name);

    }

    //Generates 1 to 3 pizzas for each house
    private void GeneratePizzas()
    {
        //run for loop for each house
        for (int i = 0; i < 2; i++)
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

    //pops off new order
    public void NewOrder() {
        if (pizzaOrders.Count > 0)
        {
            currentOrder = pizzaOrders.Pop();
        }
    }
}
