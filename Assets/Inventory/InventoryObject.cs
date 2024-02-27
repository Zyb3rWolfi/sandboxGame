using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

    public void ClearInventory()
    {
        items.Clear();
    }
}
