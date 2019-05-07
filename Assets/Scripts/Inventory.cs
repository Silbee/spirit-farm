using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Canvas inventoryCanvas;
    public Image currentCropImage;

    public Sprite[] cropSprites;

    
    public void ToggleInventory()
    {
        inventoryCanvas.enabled = !inventoryCanvas.enabled;
    }
}
