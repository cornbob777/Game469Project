using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName; // Name of the item
    public string description; // Description of the item
    public Sprite itemIcon; // Icon to represent the item in the UI
    public bool isKeyItem; // Is this a key item or regular inventory item
}

