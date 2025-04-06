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

    private void Start()
    {
        pizzaType = Random.Range(0, 3);
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
