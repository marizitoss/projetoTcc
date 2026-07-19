using System;
 

[Serializable]
public class InventorySlot
{
    public ItemData item;
    public int quantity;
 
    public InventorySlot(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
 
    public bool IsEmpty => item == null || quantity <= 0;
 
    // Quanto ainda cabe nesse slot antes de estourar o stack máximo
    public int SpaceLeft => item == null ? 0 : item.maxStackSize - quantity;
}