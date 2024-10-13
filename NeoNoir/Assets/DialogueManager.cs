using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueNode currentNode;
    public TextMeshProUGUI dialogueText;
    public GameObject choicesContainer;
    public GameObject choiceButtonPrefab;
    public Button continueButton; // Button for advancing the dialogue

    public void StartDialogue(DialogueNode startingNode)
    {
        currentNode = startingNode;
        DisplayNode();
    }

    private void DisplayNode()
    {
        dialogueText.text = currentNode.dialogueText;

        // Check if this node requires a player choice
        if (currentNode.isChoiceNode && currentNode.choices.Count > 0)
        {
            ShowChoices();
        }
        else
        {
            HideChoices(); // Hide the choice UI when not on a choice node
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
            Destroy(child.gameObject); // Clear old choices
        }

        foreach (Choice choice in currentNode.choices)
        {
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer.transform);
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => SelectChoice(choice));
        }

        choicesContainer.SetActive(true); // Make sure the choices container is visible
    }

    private void HideChoices()
    {
        choicesContainer.SetActive(false); // Hide the choices container completely
    }

    private void AdvanceToNextNode()
    {
        if (currentNode.nextNode != null)
        {
            currentNode = currentNode.nextNode;
            DisplayNode();
        }
        else
        {
            EndDialogue();
        }
    }

    private void SelectChoice(Choice choice)
    {
        HideChoices(); // Hide the choices immediately after selecting an option
        currentNode = choice.nextNode;
        DisplayNode();
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        continueButton.gameObject.SetActive(false);
        HideChoices();
        // Hide the dialogue UI or trigger an end-of-dialogue event
    }
}
