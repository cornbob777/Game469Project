using UnityEngine;

public enum QuestState
{
    NotStarted,
    InProgress,
    Completed
}

public class Quest : MonoBehaviour
{
    public string questName;
    public QuestState currentState = QuestState.NotStarted; // Start quest as "NotStarted"
    public string[] objectives; // Each objective in the quest
    private int currentObjectiveIndex = 0; // Tracks current objective index

    public void StartQuest()
    {
        currentState = QuestState.InProgress;
        Debug.Log("Starting quest: " + questName);
        ShowObjective();
    }

    public void ProgressQuest()
    {
        currentObjectiveIndex++; // Move to the next objective
        if (currentObjectiveIndex >= objectives.Length)
        {
            CompleteQuest();
        }
        else
        {
            ShowObjective();
        }
    }

    void ShowObjective()
    {
        Debug.Log("Current Objective: " + objectives[currentObjectiveIndex]);
    }

    public void CompleteQuest()
    {
        currentState = QuestState.Completed;
        Debug.Log("Quest Completed: " + questName);
    }
}
