using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class buildController : MonoBehaviour
{
    [SerializeField] private GameObject conveyor;
    [SerializeField] Camera _mainCamera;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private InventoryObject inventoryObject;
    public static event Action<InventoryItem> addSlot;
    private InventoryItem _selectedItem;
    private bool _itemSelected;
    private Vector3 _prefabPreviewLocation;
    private GameObject _prefabImage;
    private Vector3 _rotation;
    
    // Inits all the inventory objects
    private void Start()
    {
        for (int i = 0; i < inventoryObject.items.Count; i++)
        {
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
    
    // Handles the item preview 
    public void FixedUpdate()
    {
        if (_itemSelected)
        {
            Vector2 hoverPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(hoverPos);
            Vector3 prefabPos = tilemap.GetCellCenterWorld(cellPosition);
            _prefabImage.transform.position = prefabPos;
        }
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
            if (hit.collider ==  null || hit.collider.CompareTag("field"))
            {
                    Vector3Int cellPosition = tilemap.WorldToCell(clickPos);

                    Vector3 prefabPos = tilemap.GetCellCenterWorld(cellPosition);
                    Instantiate(_selectedItem.prefab, prefabPos, Quaternion.Euler(_rotation));
                
            }

        }
    }

    private void handleItemEquipped(InventoryItem item, GameObject preview)
    {
        _rotation = new Vector3(0, 0, 0);
        _selectedItem = item;
        _itemSelected = true;
        Vector2 hoverPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _prefabImage = Instantiate(preview, hoverPos, Quaternion.identity);
    }

    public void handleRotation(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rotation = new Vector3(_prefabImage.transform.eulerAngles.x,
                _prefabImage.transform.eulerAngles.y, _prefabImage.transform.eulerAngles.z + 90);
            
            _prefabImage.transform.eulerAngles = _rotation;
        }
    }
}
