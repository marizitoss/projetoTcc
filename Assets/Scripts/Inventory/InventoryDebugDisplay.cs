using UnityEngine;

public class InventoryDebugDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
 
    private void OnGUI()
    {
        if (inventory == null) return;
 
        GUI.Box(new Rect(10, 10, 220, 300), "Inventário");
        GUI.Label(new Rect(20, 35, 200, 260), inventory.GetDebugListing());
    }
}
 