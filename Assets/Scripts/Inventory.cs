using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class InventorySlots
{
    public enum Crop
    {
        Strawberry,
        Potato,
        Eggplant
    };
    public Crop cropType;

    public Sprite cropSprite;
    public TMP_Text cropCounterText;
    public int cropAmount;
}


public class Inventory : MonoBehaviour
{
    public InventorySlots[] crops;
    
    public Image currentCropImage;


    private void Start()
    {
        UpdateText();
    }


    public void UpdateText()
    {
        for (int i = 0; i < crops.Length; i++)
        {
            crops[i].cropCounterText.text = "x " + crops[i].cropAmount;
        }
    }


    public void AddCrop()
    {
        for (int i = 0; i < crops.Length; i++)
        {
            if (currentCropImage.sprite == crops[i].cropSprite)
            {
                crops[i].cropAmount++;
            }
        }

        currentCropImage.enabled = false;
        UpdateText();
    }
}
