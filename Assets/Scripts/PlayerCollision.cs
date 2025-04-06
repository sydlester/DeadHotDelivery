using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public QuestController questController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cheese" && questController.pizzaType == 0 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to the house");
        }

        if (collision.gameObject.name == "Veggie" && questController.pizzaType == 1 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to the house");

        }

        if (collision.gameObject.name == "Pepperoni" && questController.pizzaType == 2 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to the house");
        }

        if (collision.gameObject.tag == "DeliveryHouse" && questController.hasPizza)
        {
            questController.SetQuest("You win!");
            questController.hasPizza = false;
        }
    }
}
