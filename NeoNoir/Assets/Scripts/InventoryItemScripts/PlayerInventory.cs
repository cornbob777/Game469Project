using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    // Singleton instance
    public static PlayerInventory instance;

    public List<ItemData> items = new List<ItemData>(); // List of items in the player's inventory
    public InventoryUI inventoryUI; // Reference to the inventory UI to update it when items are added

    private void Awake()
    {
        // Ensure only one instance of PlayerInventory exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    // Add an item to the inventory
    public void AddItem(ItemData item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log("Added item: " + item.itemName);

            // Update the inventory UI
            inventoryUI.UpdateInventoryUI(items); // Notify the UI that the inventory has changed
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(ItemData item)
    {
        return items.Contains(item); // Return true if the item exists in the inventory
    }
}
