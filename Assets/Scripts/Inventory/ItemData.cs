using UnityEngine;

public enum ItemType
{
    Resource,   
    Tool,
    Equipment,
    Consumable,
    Misc
}

// Cada item do jogo é um asset ScriptableObject.
// Cria pelo botão direito na Project -> Create -> Inventory -> Item
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [Header("Identificação")]
    public string itemId;      
    public string displayName; 

    [Header("Info")]
    [TextArea]
    public string description;
    public Sprite icon;
    public ItemType itemType = ItemType.Resource;

    [Header("Empilhamento")]
    public bool isStackable = true;
    public int maxStackSize = 99;
}