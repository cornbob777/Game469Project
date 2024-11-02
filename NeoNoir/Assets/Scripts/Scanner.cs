using UnityEngine;

public class Scanner : MonoBehaviour
{
    public SuspectListUIManager suspectListUIManager; // Reference to the Suspect List UI Manager
    public QuestManager questManager; // Reference to QuestManager to track progress

    void Update()
    {
        // Check for space bar input to activate the scanner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar pressed, activating scanner.");

            // If the suspect list UI manager is set, decrypt data
            if (suspectListUIManager != null)
            {
                suspectListUIManager.DecryptData(); // Decrypt the data and show the UI
                Debug.Log("Suspect data decrypted.");
            }

            // Optionally progress the quest
            if (questManager != null)
            {
                questManager.ProgressQuest();
                Debug.Log("Quest progressed.");
            }
        }
    }
}
