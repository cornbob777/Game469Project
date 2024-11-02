using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueNode currentNode; // The current node in the dialogue
    public TextMeshProUGUI dialogueText; // The text UI for displaying dialogue
    public GameObject choicesContainer; // The container holding choice buttons
    public GameObject choiceButtonPrefab; // The prefab for choice buttons
    public Button continueButton; // Button for advancing dialogue when there are no choices
    public QuestManager questManager; // Reference to the QuestManager, which handles quests

    public QuestData currentQuest; // Reference to the current quest, used for starting or progressing quests

    // Start the dialogue with a specific node
    public void StartDialogue(DialogueNode startingNode)
    {
        currentNode = startingNode; // Set the starting node
        DisplayNode(); // Display the node's dialogue text
    }

    // Display the current node's text and choices
    private void DisplayNode()
    {
        dialogueText.text = currentNode.dialogueText; // Display the dialogue text in the UI

        // If the current node is a choice node and has choices
        if (currentNode.isChoiceNode && currentNode.choices.Count > 0)
        {
            ShowChoices(); // Show the available choices
        }
        else
        {
            HideChoices(); // Hide the choices if it's not a choice node
            continueButton.gameObject.SetActive(true); // Show the continue button if there are no choices
            continueButton.onClick.RemoveAllListeners(); // Clear previous listeners
            continueButton.onClick.AddListener(() => AdvanceToNextNode()); // Set the listener for advancing dialogue
        }
    }

    // Show the available choices for a choice node
    private void ShowChoices()
    {
        continueButton.gameObject.SetActive(false); // Hide the continue button if there are choices

        // Clear old choice buttons
        foreach (Transform child in choicesContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Create new buttons for each choice
        foreach (Choice choice in currentNode.choices)
        {
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer.transform);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText; // Set the choice button text
            choiceButton.GetComponent<Button>().onClick.AddListener(() => SelectChoice(choice)); // Add listener for choice selection
        }

        choicesContainer.SetActive(true); // Show the choices container
    }

    // Hide the choices container
    private void HideChoices()
    {
        choicesContainer.SetActive(false); // Hide the choices UI
    }

    // Advance to the next node in the dialogue sequence
    private void AdvanceToNextNode()
    {
        if (currentNode.nextNode != null) // Check if there is a next node
        {
            currentNode = currentNode.nextNode; // Move to the next node
            DisplayNode(); // Display the new node's text and choices
        }
        else
        {
            EndDialogue(); // End the dialogue if there's no next node
        }
    }

    // Select a choice and move to the corresponding node
    private void SelectChoice(Choice choice)
    {
        // Trigger quest-related actions if the choice has quest actions
        if (choice.action == ActionType.StartQuest && questManager != null)
        {
            questManager.StartQuest(currentQuest); // Start the assigned quest  
        }
        else if (choice.action == ActionType.ProgressQuest && questManager != null)
        {
            questManager.ProgressQuest(); // Progress the assigned quest  

        HideChoices(); // Hide the choices after selection
        currentNode = choice.nextNode; // Move to the node linked to the selected choice
        DisplayNode(); // Display the new node
        }
    }

    // End the dialogue and hide the UI
    private void EndDialogue()
    {
        dialogueText.text = ""; // Clear the dialogue text
        continueButton.gameObject.SetActive(false); // Hide the continue button
        HideChoices(); // Hide the choices UI
        // Additional logic can be added here for what happens after dialogue ends
    }
}

