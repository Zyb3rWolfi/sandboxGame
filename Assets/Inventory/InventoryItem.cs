using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int quantity;
    public GameObject prefab;
}
