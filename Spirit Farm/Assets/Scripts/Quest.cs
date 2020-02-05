using UnityEngine;

[System.Serializable]
public class QuestItems
{
    public enum Crop
    {
        Strawberry,
        Potato,
        Eggplant
    };
    public Crop cropType;
    public int amount;
}


[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string questName = "Quest Name";
    [TextArea]
    public string questDescription = "Quest Description";

    public QuestItems[] cropsToTurnIn;

    public bool questCompleted;
}