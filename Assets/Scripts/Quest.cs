using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string questName = "Quest Name", questDescription = "Quest Description";

    public enum Crop { Strawberry, Rice, Potato };
    public Crop crop;

    public int amountToHarvest = 3;

    public bool questCompleted;
}
