using UnityEngine;

public class SuspectListListener : MonoBehaviour
{
    public GameObject suspectListCanvas; // Reference to the Suspect List UI 
    [SerializeField] private GameObject targetItem; // The specific item that triggers the suspect list

    private void OnEnable()
    {
        InteractionEvent.OnItemPickedUp += OnItemPickedUp; // Subscribe to the event
    }

    private void OnDisable()
    {
        InteractionEvent.OnItemPickedUp -= OnItemPickedUp; // Unsubscribe from the event
    }

    // Method that runs when an item is picked up
    private void OnItemPickedUp(GameObject item)
    {
        Debug.Log("Item picked up: " + item.name); // Log the picked-up item's name

        // Check if the picked-up item is the one that should trigger the suspect list UI
        if (item == targetItem)
        {
            Debug.Log("Correct item picked up, activating Suspect List UI.");
            suspectListCanvas.SetActive(true); // Activate the suspect list canvas

            // Add a fallback log to confirm if the UI activation line is reached
            if (suspectListCanvas.activeSelf)
            {
                Debug.Log("Suspect List Canvas is now active.");
            }
            else
            {
                Debug.Log("Suspect List Canvas is NOT active.");
            }
        }
        else
        {
            Debug.Log("Picked-up item is not the target item.");
        }
    }
}
