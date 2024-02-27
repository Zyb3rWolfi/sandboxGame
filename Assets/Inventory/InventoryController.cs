using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Transform parent;
    private void OnEnable()
    {
        buildController.addSlot += updateSlots;
    }

    private void OnDisable()
    {
        buildController.addSlot -= updateSlots;
    }

    private void updateSlots(InventoryItem item)
    {
        GameObject newSlot = Instantiate(slot, parent);
        inventoryUI slotUI = newSlot.GetComponent<inventoryUI>();
        slotUI.UpdateSlot(item);
    }
    
}
