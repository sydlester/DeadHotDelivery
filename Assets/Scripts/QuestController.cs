using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public TMP_Text questText;
    public int pizzaType;
    string pizzaName = "";
    public bool hasPizza = false;
    private GameObject[] houses;
    public GameObject deliveryHouse;

    private void Start()
    {
        pizzaType = Random.Range(0, 3);
        houses = GameObject.FindGameObjectsWithTag("House");
        if (houses.Length > 0)
        {
            deliveryHouse = houses[Random.Range(0, houses.Length)];
        }
        else
        {
            Debug.LogWarning("No houses found with tag 'House'");
        }
        PizzaQuest();
    }

    public void PizzaQuest()
    {
        if (pizzaType == 0)
        {
            pizzaName = "cheese";
        }
        else if (pizzaType == 1)
        {
            pizzaName = "veggie";
        }
        else
        {
            pizzaName = "pepperoni";
        }
        SetQuest("grab the " + pizzaName + " pizza");
    }

    public void SetQuest(string quest)
    {
        questText.text = quest;
    }
}
