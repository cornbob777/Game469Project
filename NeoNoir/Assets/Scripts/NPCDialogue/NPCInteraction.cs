using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public int requiredObjectiveIndex; // The quest objective this NPC is involved with
    public string dialogue; // Default dialogue if no special quest interaction

    // Reference to the QuestManager
    private QuestManager questManager;

    private void Start()
    {
        // Use FindAnyObjectByType instead of FindObjectOfType
        questManager = FindAnyObjectByType<QuestManager>(); // Updated method to find the QuestManager instance
    }

    // When the player interacts with the NPC
    private void OnMouseDown()
    {
        if (questManager != null)
        {
            // Check if the player is on the correct objective for this NPC
            if (questManager.IsOnObjective(requiredObjectiveIndex))
            {
                // Progress the quest or trigger special interaction
                questManager.ProgressQuest();
                Debug.Log("NPC interaction progresses the quest.");
            }
            else
            {
                // If the player is not on the right objective, show regular dialogue
                Debug.Log("NPC says: " + dialogue);
            }
        }
    }
}
