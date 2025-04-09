using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject heldItem;
    public void SetHeldItem(GameObject item)
    {
        heldItem = item;
        heldItem.transform.SetParent(transform, false); // Use false to preserve UI scale
        heldItem.transform.localPosition = Vector3.zero;

    }
}
