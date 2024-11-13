using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI; // Reference to the main dialogue UI panel (set this in the Inspector)
    public DialogueNode currentNode; // The current node in the dialogue
    public TextMeshProUGUI dialogueText; // The text UI for displaying dialogue
    public GameObject choicesContainer; // The container holding choice buttons
    public GameObject choiceButtonPrefab; // The prefab for choice buttons
    public Button continueButton; // Button for advancing dialogue when there are no choices
    public QuestManager questManager; // Reference to the QuestManager, which handles quests
    public QuestData currentQuest; // Reference to the current quest, used for starting or progressing quests

    private void Start()
    {
        // Make sure the dialogue UI is hidden at the start
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }
    }

    // Start the dialogue with a specific node
    public void StartDialogue(DialogueNode startingNode)
    {
        currentNode = startingNode; // Set the starting node
        DisplayNode(); // Display the node's dialogue text
        
        // Show the dialogue UI when dialogue starts
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true);
        }
    }

    // Display the current node's text and choices
    private void DisplayNode()
    {
        dialogueText.text = currentNode.dialogueText; // Display the dialogue text in the UI

        if (currentNode.triggersQuest && currentNode.questToTrigger != null && questManager != null)
        {
            if (currentNode.action == ActionType.StartQuest)
            {
                questManager.StartQuest(currentNode.questToTrigger);
            }
            else if (currentNode.action == ActionType.ProgressQuest)
            {
                questManager.ProgressQuest(currentNode.questToTrigger);
            }
        }

        if (currentNode.isChoiceNode && currentNode.choices.Count > 0)
        {
            ShowChoices();
        }
        else
        {
            HideChoices();
            continueButton.gameObject.SetActive(true);
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() => AdvanceToNextNode());
        }
    }

    private void ShowChoices()
    {
        continueButton.gameObject.SetActive(false); // Hide the continue button if there are choices

        foreach (Transform child in choicesContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Choice choice in currentNode.choices)
        {
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer.transform);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => SelectChoice(choice));
        }

        choicesContainer.SetActive(true); // Show the choices container
    }

    private void HideChoices()
    {
        choicesContainer.SetActive(false); // Hide the choices UI
    }

    // Advance to the next node in the dialogue sequence
    private void AdvanceToNextNode()
    {
        if (currentNode.nextNode != null)
        {
            currentNode = currentNode.nextNode;
            DisplayNode();
        }
        else
        {
            EndDialogue(); // If no next node, end the dialogue
        }
    }

    private void SelectChoice(Choice choice)
    {
        if (choice.action == ActionType.StartQuest && questManager != null)
        {
            questManager.StartQuest(currentQuest);
        }
        else if (choice.action == ActionType.ProgressQuest && questManager != null)
        {
            questManager.ProgressQuest(currentQuest);
        }

        HideChoices();
        currentNode = choice.nextNode;
        DisplayNode();
    }

    // End the dialogue and hide the UI
    private void EndDialogue()
    {
        dialogueText.text = ""; // Clear the dialogue text
        continueButton.gameObject.SetActive(false); // Hide the continue button
        HideChoices();

        // Hide the dialogue UI when dialogue ends
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }
    }
}
