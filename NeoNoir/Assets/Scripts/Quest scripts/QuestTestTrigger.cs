using UnityEngine;

public class QuestTestTrigger : MonoBehaviour
{
    public QuestData questToStart; // Ensure this is of type QuestData

    private void Update()
    {
        // Temporary test trigger for starting the quest
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuestManager questManager = FindAnyObjectByType<QuestManager>(); // Updated method to find QuestManager
            if (questManager != null)
            {
                questManager.StartQuest(questToStart); // Pass QuestData to StartQuest
            }
        }
    }
}
