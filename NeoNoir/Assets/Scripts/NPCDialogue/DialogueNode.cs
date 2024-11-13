using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string characterName; // Name of the character speaking
    [TextArea(3, 10)] public string dialogueText; // The dialogue text displayed to the player
    public List<Choice> choices; // List of player choices for branching dialogue
    public DialogueNode nextNode; // Next dialogue node for linear progression
    public bool isChoiceNode; // Flag to indicate if this node offers player choices
    public bool triggersQuest; // Does this node trigger a quest action?
    public QuestData questToTrigger; // The quest associated with this node, if any
    public ActionType action; // Type of action to perform on the quest
    public Vector2 position; // Optional position data for layout purposes
}

[System.Serializable]
public class Choice
{
    public string choiceText; // The text displayed for the player's choice
    public DialogueNode nextNode; // The node to navigate to if this choice is selected
    public ActionType action; // Action to perform when this choice is selected
}

public enum ActionType
{
    None,
    UseAbility,
    GatherClue,
    InfluenceNPC,
    StartQuest,   // Start a quest
    ProgressQuest // Progress the quest
}
