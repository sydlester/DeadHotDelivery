using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public QuestController questController;
    public GameController gameController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cheese" && questController.pizzaType == 0 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to " + questController.deliveryHouse.name);
        }

        if (collision.gameObject.name == "Veggie" && questController.pizzaType == 1 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to " + questController.deliveryHouse.name);

        }

        if (collision.gameObject.name == "Pepperoni" && questController.pizzaType == 2 && !questController.hasPizza)
        {
            questController.hasPizza = true;
            questController.SetQuest("Deliver the pizza to " + questController.deliveryHouse.name);
        }

        if (collision.gameObject.name == questController.deliveryHouse.name && questController.hasPizza)
        {
            gameController.Win();
            questController.hasPizza = false;
        }
    }
}
