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

    public Canvas inventoryCanvas;
    public Image currentCropImage;


    private void Start()
    {
        UpdateText();
    }


    public void ToggleInventory()
    {
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }


    public void UpdateText()
    {
        for (int i = 0; i < crops.Length; i++)
        {
            crops[i].cropCounterText.text = "x " + crops[i].cropAmount;
        }
    }
}
