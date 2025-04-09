using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    GameObject emptySlot = null;
    [SerializeField] GameObject[] slots = new GameObject[3];
    [SerializeField] GameObject itemPrefab;
   public void ItemPicked(GameObject pickedItem)
    {
        var itemPickable = pickedItem.GetComponent<ItemPickable>();
        if (itemPickable == null) return; // early exit
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i].GetComponent<InventorySlot>();
            if (slot.heldItem == null)
            {
                emptySlot = slots[i];
                break;
            }
        }
        
        if (emptySlot != null)
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.GetComponent<InventoryItem>().itemScriptableObject = itemPickable.itemScriptableObject;

            emptySlot.GetComponent<InventorySlot>().SetHeldItem(newItem);

            Destroy(pickedItem);
        }
    }
}
