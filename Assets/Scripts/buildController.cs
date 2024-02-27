using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class buildController : MonoBehaviour
{
    [SerializeField] private GameObject conveyor;
    [SerializeField] Camera _mainCamera;
    [SerializeField] private Tilemap tilemap;
    private Vector3 _cellSize;
    [SerializeField] private Tile tile;
    [SerializeField] private InventoryObject inventoryObject;
    [SerializeField] private GameObject inventorySlot;
    public static event Action<InventoryItem> addSlot;
    private InventoryItem _selectedItem;
    private void Start()
    {
        _cellSize = tilemap.cellSize;
        for (int i = 0; i < inventoryObject.items.Count; i++)
        {
            print("looping");
            addSlot?.Invoke(inventoryObject.items[i]);
        }
    }

    private void OnDisable()
    {
        inventoryUI.itemEquipped -= handleItemEquipped;
    }

    private void OnEnable()
    {
        inventoryUI.itemEquipped += handleItemEquipped;
    }

    public void onButtonClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_selectedItem == null)
            {
                return;
            } 

            Vector2 clickPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 mousePos2D = new Vector2(clickPos.x, clickPos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == null)
            {
                    Vector3Int cellPosition = tilemap.WorldToCell(clickPos);

                    Vector3 prefabPos = tilemap.GetCellCenterWorld(cellPosition);
                    Instantiate(_selectedItem.prefab, prefabPos, Quaternion.identity);
                
            }

        }
    }

    private void handleItemEquipped(InventoryItem item)
    {
        _selectedItem = item;
    }
}
