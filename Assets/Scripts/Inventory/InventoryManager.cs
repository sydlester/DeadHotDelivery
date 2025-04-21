using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    GameObject emptySlot = null;
    [SerializeField] GameObject[] slots = new GameObject[3];
    [SerializeField] GameObject itemPrefab;
    [SerializeField] QuestController questController;
    [SerializeField] PlayerPickup playerPickup;
    [SerializeField] PlayerDropOff playerDropOff;
    public Dictionary<int, int> inventoryCounts = new Dictionary<int, int>();
    public GameObject pickupPopup;
    public GameObject dropPopup;


    //Puts an item into an inventory slot
    public void ItemPicked(GameObject pickedItem)
    {
        emptySlot = null;
        var itemPickable = pickedItem.GetComponent<ItemPickable>();
        if (itemPickable == null) return;

        //Checks for lowest open slot
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot slot = slots[i].GetComponent<InventorySlot>();
            if (slot.heldItem == null)
            {
                emptySlot = slots[i];
                break;
            }
        }

        //If there is an empty slot, create item in that slot
        if (emptySlot != null)
        {
            GameObject newItem = Instantiate(itemPrefab);
            ItemSO itemSO = itemPickable.itemScriptableObject;
            newItem.GetComponent<InventoryItem>().itemScriptableObject = itemSO;
            emptySlot.GetComponent<InventorySlot>().SetHeldItem(newItem);

            //Updates count of pizzas in inventory
            int pizzaNum = itemSO.num;
            if (inventoryCounts.ContainsKey(pizzaNum))
                inventoryCounts[pizzaNum]++;
            else
                inventoryCounts[pizzaNum] = 1;

        }

        //if we have all of the pizzas, turn off the ability to grab more and start delivery quest
        if (questController.HasRequiredPizzas())
        {
            questController.DeliveryQuest();
            playerPickup.enabled = false;
        }
    }
    //Clears all items from slots and inventory count and enables player ability to pick up more items
    public void ClearInventory()
    {
        foreach (GameObject slotObj in slots)
        {
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            if (slot.heldItem != null)
            {
                Destroy(slot.heldItem);
                slot.heldItem = null;
            }
        }

        inventoryCounts.Clear();
        playerDropOff.enabled = false;
        dropPopup.SetActive(false);
    }

    //Returns count of pizza in inventory
    public int GetItemCount(int pizzaNum)
    {
        return inventoryCounts.ContainsKey(pizzaNum) ? inventoryCounts[pizzaNum] : 0;
    }

    public bool NeedMoreOfPizzaType(GameObject pizza)
    {
        int pizzaType = pizza.GetComponent<ItemPickable>().itemScriptableObject.num;
        int inventoryCount = GetItemCount(pizza.GetComponent<ItemPickable>().itemScriptableObject.num);
        foreach (int orderPizza in questController.currentOrder)
        {
            if (orderPizza == pizzaType)
                inventoryCount--;
        }
        return inventoryCount < 0;
    }
}
