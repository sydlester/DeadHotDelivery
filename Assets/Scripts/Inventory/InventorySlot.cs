using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //class is used to hold the item in the inventory slot
    public GameObject heldItem;
    public void SetHeldItem(GameObject item)
    {
        heldItem = item;
        heldItem.transform.SetParent(transform, false); 
        heldItem.transform.localPosition = Vector3.zero;

    }
}
