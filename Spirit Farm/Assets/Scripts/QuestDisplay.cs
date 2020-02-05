using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    public Quest quest;
    public GameHandler game;
    public Inventory inventory;
    public CommonFunctions functions;

    public SpriteRenderer playerHat;

    public Canvas questTab;
    public TMP_Text questNameText, questDescriptionText, questCompletedText;
    
    bool interactable;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            UpdateText();

            functions.DisplayCanvas(questTab);
            interactable = true;
        }
    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            functions.CloseCanvas(questTab);
            interactable = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable && !quest.questCompleted)
        {
            if (CanTurnInQuest())
            {
                quest.questCompleted = true;
                UpdateText();

                if (game.CheckQuestCompletion())
                {
                    playerHat.enabled = true;
                }
            }
        }
    }


    void UpdateText()
    {
        questNameText.text = quest.questName;
        questDescriptionText.text = quest.questDescription;

        questCompletedText.enabled = quest.questCompleted ? true : false;

        if (quest.questCompleted)
            questDescriptionText.fontStyle = FontStyles.Strikethrough;
        else
            questDescriptionText.fontStyle = FontStyles.Normal;
    }


    bool CanTurnInQuest()
    {
        for (int i = 0; i < inventory.crops.Length; i++)
        {
            if (inventory.crops[i].cropAmount < quest.cropsToTurnIn[i].amount)
            {
                return false;
            }
        }

        for (int i = 0; i < inventory.crops.Length; i++)
        {
            inventory.crops[i].cropAmount -= quest.cropsToTurnIn[i].amount;
        }

        UpdateText();
        inventory.UpdateText();
        return true;
    }
}
    