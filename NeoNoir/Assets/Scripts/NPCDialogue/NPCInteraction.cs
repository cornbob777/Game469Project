using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public DialogueNode startingDialogue; // The starting dialogue node for this NPC
    private DialogueManager dialogueManager; // Reference to the DialogueManager

    private void Start()
    {
        // Find the DialogueManager in the scene
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // This function is called when the player clicks on the NPC
    private void OnMouseDown()
    {
        // Start the dialogue with the specified starting dialogue node
        if (dialogueManager != null && startingDialogue != null)
        {
            dialogueManager.StartDialogue(startingDialogue);
            Debug.Log("Started dialogue with NPC.");
        }
        else
        {
            Debug.LogWarning("DialogueManager or startingDialogue is missing.");
        }
    }
}

