using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    public string characterName;
    [TextArea(3, 10)] public string dialogueText;
    public List<Choice> choices;
    public DialogueNode nextNode;   
    public bool isChoiceNode;   
    public Vector2 position;
}


[System.Serializable]
public class Choice
{
    public string choiceText;
    public DialogueNode nextNode;
    public ActionType action;
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

