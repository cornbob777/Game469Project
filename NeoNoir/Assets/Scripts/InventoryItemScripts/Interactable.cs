using UnityEngine;
// https://www.youtube.com/watch?v=gpnEPPyhLE8 I used this youtube video to help with this script
public class Interactable : MonoBehaviour
{
    private Renderer _renderer;

    public ItemData item; // The item to be added to the inventory (if applicable)
    public QuestData questToStart; // The quest that this interactable will start (if any)

    public QuestManager questManager; // Reference to QuestManager to track progress

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // This makes the object look like it's getting scanned.
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _renderer.material.color = Color.cyan;
        }
        else if (Input.anyKey)
        {
            _renderer.material.color = Color.white;
        }
    }

    // Trigger interaction logic when clicked
    private void OnMouseDown()
    {
        Debug.Log("Successful Click");

        // Handle item collection (add the item to inventory if applicable)
        if (item != null)
        {
            PlayerInventory.instance.AddItem(item); // Add the item to the player's inventory
            InteractionEvent.ItemPickedUp(gameObject); // Trigger the event that this item was picked up
            Destroy(gameObject); // Destroy the object after picking up the item
            Debug.Log("Picked up: " + item.itemName);
        }

        // Handle quest starting (if applicable)
        if (questToStart != null)
        {
            if (questManager != null)
            {
                questManager.StartQuest(questToStart); // Start the assigned quest
            }
            Debug.Log("Quest started: " + questToStart.questName);
        }
    }
}
