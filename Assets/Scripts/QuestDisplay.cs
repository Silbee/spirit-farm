using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    public Quest quest;

    public Canvas questTab;
    public TMP_Text questNameText, questDescriptionText, questCompletedText;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            questNameText.text = quest.questName;
            questDescriptionText.text = quest.questDescription;

            questTab.enabled = true;

            //Text is zichtbaar wanneer questCompleted, anders niet
            questCompletedText.enabled = quest.questCompleted ? true : false;
        }
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            questTab.enabled = false;
        }
    }
}
