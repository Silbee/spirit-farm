using UnityEngine;

public class QuestReset : MonoBehaviour
{
    public Quest[] quests;


    void Start()
    {
        foreach (Quest quest in quests)
        {
            quest.questCompleted = false;
        }
    }
}
