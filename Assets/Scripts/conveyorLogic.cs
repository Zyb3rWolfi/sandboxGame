using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class conveyorLogic : MonoBehaviour
{
    [SerializeField] private GameObject conveyor;
    [SerializeField] private float conveyorSpeed;
    
    private bool _onConveyor;
    private Vector2 _direction;
    private int minerID;
    public static event Action<int> stopMining;


    private void Update()
    {
        if (_onConveyor)
        {
            transform.Translate(_direction * conveyorSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
        
    {
        float roation = other.transform.eulerAngles.z;

        if (roation == 0)
        {
            _direction = Vector2.up;
        } else if (roation == 90f)
        {
            _direction = Vector2.left;
        } else if (roation == 180f)
        {
            _direction = Vector2.down;
        } else if (roation == 270f)
        {
            _direction = Vector2.right;
        }
        
        _onConveyor = true;
    }

    
    private void OnTriggerExit2D(Collider2D other) {
        _onConveyor = false;
        stopMining?.Invoke(minerID);
    }

    public void setID(int id) {
        minerID = id;
        print("id is");
    }
    
}
