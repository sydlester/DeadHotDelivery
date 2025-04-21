using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DeliveryData", menuName = "ScriptableObjects/DeliveryData", order = 1)]
public class DeliveryData : ScriptableObject
{
    private GameObject[] houses;
    public Stack<GameObject> deliveryHouses;
    public Stack<List<int>> pizzaOrders;
    public List<int> currentOrder;
    public GameObject currentHouse;
    private QuestController questController;
    private GameController gameController;


    public void Initialize()
    {
        questController = FindObjectOfType<QuestController>();
        gameController = FindObjectOfType<GameController>();

        houses = GameObject.FindGameObjectsWithTag("House");
        deliveryHouses = new Stack<GameObject>();
        pizzaOrders = new Stack<List<int>>();

        GenerateHouses();
        GeneratePizzas();
        questController.Setup();
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
    private void GeneratePizzas()
    {
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

    public void NewOrder() {
        if (pizzaOrders.Count > 0)
        {
            currentOrder = pizzaOrders.Pop();
            currentHouse = deliveryHouses.Pop();
        }
        else
        {
            currentOrder = null;
            currentHouse = null;
            gameController.Win();
        }
    }
}
