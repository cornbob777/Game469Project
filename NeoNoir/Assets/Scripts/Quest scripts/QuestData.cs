using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class QuestData : ScriptableObject
{
    public string questName; // The name of the quest
    public string[] objectives; // The list of objectives for the quest
    public bool isCompleted; // Flag to track whether the quest is completed
    public int currentObjectiveIndex; // Tracks which objective the player is currently on
}
