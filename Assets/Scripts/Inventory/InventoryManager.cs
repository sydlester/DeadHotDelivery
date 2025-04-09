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
    [SerializeField] QuestController questController;
    [SerializeField] PlayerPickup playerPickup;
    public Dictionary<int, int> inventoryCounts = new Dictionary<int, int>();
    public GameObject pickupPopup;


    public void ItemPicked(GameObject pickedItem)
    {
        emptySlot = null;
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
            ItemSO itemSO = itemPickable.itemScriptableObject;
            newItem.GetComponent<InventoryItem>().itemScriptableObject = itemSO;

            emptySlot.GetComponent<InventorySlot>().SetHeldItem(newItem);
            int pizzaNum = itemSO.num;
            if (inventoryCounts.ContainsKey(pizzaNum))
                inventoryCounts[pizzaNum]++;
            else
                inventoryCounts[pizzaNum] = 1;

        }

        //if we have all of the pizzas, turn off the ability to grab more
        if (questController.HasRequiredPizzas())
        {
            questController.DeliveryQuest();
            playerPickup.enabled = false;
            pickupPopup.SetActive(false);
        }
    }

    public void ClearInventory()
    {
        // Clear held items from slots
        foreach (GameObject slotObj in slots)
        {
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            if (slot.heldItem != null)
            {
                Destroy(slot.heldItem);
                slot.heldItem = null;
            }
        }

        // Clear inventory counts and allow more pickup
        inventoryCounts.Clear();
        playerPickup.enabled = true;
        pickupPopup.SetActive(true);
    }


    public int GetItemCount(int pizzaNum)
    {
        return inventoryCounts.ContainsKey(pizzaNum) ? inventoryCounts[pizzaNum] : 0;
    }

}
