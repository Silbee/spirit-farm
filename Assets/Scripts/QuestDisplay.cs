using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    public Quest quest;
    public Inventory inventory;

    public Canvas questTab;
    public TMP_Text questNameText, questDescriptionText, questCompletedText;
    
    bool interactable;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            questNameText.text = quest.questName;
            questDescriptionText.text = quest.questDescription;

            questTab.enabled = true;
            interactable = true;

            //Text is zichtbaar wanneer questCompleted, anders niet
            questCompletedText.enabled = quest.questCompleted ? true : false;
        }
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            questTab.enabled = false;
            interactable = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable && !quest.questCompleted)
        {
            if (TurnInQuest())
            {
                quest.questCompleted = true;
            }
        }
    }


    bool TurnInQuest()
    {
        for (int i = 0; i < inventory.crops.Length; i++)
        {
            if (inventory.crops[i].cropAmount < quest.cropsToTurnIn[i].amount)
            {
                print("Terminated at loop " + (i + 1));
                print(false);
                return false;
            }
        }

        for (int i = 0; i < inventory.crops.Length; i++)
        {
            inventory.crops[i].cropAmount -= quest.cropsToTurnIn[i].amount;
        }
        print("Quest complete!");
        print(true);

        inventory.UpdateText();
        return true;
    }
}
    