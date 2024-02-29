using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public TextMeshProUGUI itemName;

    public TextMeshProUGUI descriptionText;

    public Image iconImage;

    public TextMeshProUGUI quantityText;
    private InventoryItem _item;
    private GameObject _prefabPreview;
    public static event Action<InventoryItem, GameObject> itemEquipped;

    public void UpdateSlot(InventoryItem item)
    {
        itemName.text = item.name;
        _item = item;
        _prefabPreview = item.prefabPreview;
    }
    
    public void slotPressed()
    {
        itemEquipped?.Invoke(_item, _prefabPreview);
    } 
}
