using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData currentQuest; // The current active quest
    public int currentObjectiveIndex; // Track the current objective

    // Start a new quest
    public void StartQuest(QuestData quest)
    {
        currentQuest = quest;
        currentObjectiveIndex = 0; // Start at the first objective
        Debug.Log("Quest Started: " + quest.questName);
        ShowObjective();
    }

    // Display the current objective
    public void ShowObjective()
    {
        if (currentObjectiveIndex < currentQuest.objectives.Length)
        {
            Debug.Log("Objective: " + currentQuest.objectives[currentObjectiveIndex]);
        }
    }

    // Progress the quest automatically
    public void ProgressQuest()
    {
        if (currentObjectiveIndex < currentQuest.objectives.Length - 1)
        {
            currentObjectiveIndex++; // Move to the next objective
            Debug.Log("Progressing to next objective.");
            ShowObjective();
        }
        else
        {
            CompleteQuest();
        }
    }

    // Complete the quest
    public void CompleteQuest()
    {
        currentQuest.isCompleted = true;
        Debug.Log("Quest Completed: " + currentQuest.questName);
    }

    // Check if the player has reached a specific quest objective
    public bool IsOnObjective(int objectiveIndex)
    {
        return currentObjectiveIndex == objectiveIndex;
    }
}
