using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Quest[] quests;


    void Start()
    {
        Time.timeScale = 0;

        foreach (Quest quest in quests)
        {
            quest.questCompleted = false;
        }

        Application.targetFrameRate = 65;
    }


    public bool CheckQuestCompletion()
    {
        foreach (Quest quest in quests)
        {
            if (!quest.questCompleted)
            {
                return false;
            }
        }

        return true;
    }
}
