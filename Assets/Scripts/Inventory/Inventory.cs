using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int maxSlots = 24;

    [SerializeField] private List<InventorySlot> slots = new List<InventorySlot>();

    public event Action OnInventoryChanged;

    public IReadOnlyList<InventorySlot> Slots => slots;


    public int AddItem(ItemData item, int amount)
    {
        if (item == null || amount <= 0) return amount;

        int remaining = amount;

        if (item.isStackable)
        {
            foreach (var slot in slots)
            {
                if (remaining <= 0) break;
                if (slot.item == item && slot.SpaceLeft > 0)
                {
                    int toAdd = Mathf.Min(slot.SpaceLeft, remaining);
                    slot.quantity += toAdd;
                    remaining -= toAdd;
                }
            }
        }

        while (remaining > 0 && slots.Count < maxSlots)
        {
            int stackSize = item.isStackable ? item.maxStackSize : 1;
            int toAdd = Mathf.Min(stackSize, remaining);
            slots.Add(new InventorySlot(item, toAdd));
            remaining -= toAdd;
        }

        if (remaining != amount)
            OnInventoryChanged?.Invoke();

        return remaining; // sobrou (não coube) — 0 se deu tudo certo
    }
    public bool RemoveItem(ItemData item, int amount)
    {
        if (item == null || amount <= 0) return false;
        if (GetQuantity(item) < amount) return false;

        int remaining = amount;
        for (int i = slots.Count - 1; i >= 0; i--)
        {
            if (remaining <= 0) break;
            var slot = slots[i];
            if (slot.item != item) continue;

            int toRemove = Mathf.Min(slot.quantity, remaining);
            slot.quantity -= toRemove;
            remaining -= toRemove;

            if (slot.quantity <= 0)
                slots.RemoveAt(i);
        }

        OnInventoryChanged?.Invoke();
        return true;
    }


    public int GetQuantity(ItemData item)
    {
        return slots.Where(s => s.item == item).Sum(s => s.quantity);
    }

    public bool HasItem(ItemData item, int amount = 1)
    {
        return GetQuantity(item) >= amount;
    }

    public bool HasSpace => slots.Count < maxSlots;

    public string GetDebugListing()
    {
        if (slots.Count == 0) return "Inventário vazio.";

        var sb = new StringBuilder();
        foreach (var slot in slots.OrderBy(s => s.item.displayName))
        {
            sb.AppendLine($"{slot.item.displayName} x{slot.quantity}");
        }
        return sb.ToString();
    }
}