using System;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    // Define an event that will notify when an item is picked up or interacted with
    public static event Action<GameObject> OnItemPickedUp;

    // Call this method when the item is picked up
    public static void ItemPickedUp(GameObject item)
    {
        if (OnItemPickedUp != null)
        {
            OnItemPickedUp.Invoke(item); // Trigger the event and pass the item reference
            Debug.Log("Item picked up event triggered for: " + item.name);
        }
    }
}
