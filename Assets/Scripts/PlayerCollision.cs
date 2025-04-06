using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool hasPizza = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pizza")
        {
            Debug.Log("Pizza Collected");
            hasPizza = true;
        }

        if (collision.gameObject.tag == "DeliveryHouse" && hasPizza)
        {
            Debug.Log("Pizza Delivered");
            hasPizza = false;
        }
    }
}
