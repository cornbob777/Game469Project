using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Panel that contains the inventory UI
    public GameObject itemSlotPrefab; // Prefab for displaying an item in the UI
    public Transform itemSlotContainer; // Container that holds the item slots

    // Update the inventory UI with the items from the player's inventory
    public void UpdateInventoryUI(List<ItemData> items)
    {
        // Clear any existing UI items
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject); // Destroy all existing item slots
        }

        // Populate the inventory with the current items
        foreach (ItemData item in items)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotContainer); // Create a new item slot
            Image itemIcon = itemSlot.GetComponentInChildren<Image>(); // Get the image component for the icon
            itemIcon.sprite = item.itemIcon; // Set the item icon
        }
    }
}
