using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item; // The item to be picked up (must be ItemData ScriptableObject)

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is colliding with the item (not very useful right now but just in case)
        if (other.CompareTag("Player"))
        {
            // Add the item to the player's inventory via the singleton instance
            PlayerInventory.instance.AddItem(item); // Add the item to the global player inventory

            // Destroy the item from the scene
            Destroy(gameObject);
        }
    }
}
