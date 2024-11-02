using UnityEngine;

public class ListInteractable : MonoBehaviour
{
    public QuestManager questManager; // Reference to the QuestManager
    public QuestData questToProgress; // The quest this interaction is tied to

    // This will be called when the player interacts with the machine or item
    private void OnMouseDown()
    {
        Debug.Log("Player interacted with the list.");
        
        // Simulate data decryption and revealing the clue
        RevealSuspectData();
        
        // Progress the quest automatically
        if (questToProgress != null && questManager != null)
        {
            questManager.ProgressQuest(); // Progress the quest
        }
    }

    // Reveal the decrypted suspect data
    private void RevealSuspectData()
    {
        Debug.Log("Suspect data decrypted. Revealing intoxication clue...");
        // Show the list UI, and highlight the intoxicated suspect in the UI (can be implemented visually)
    }
}
