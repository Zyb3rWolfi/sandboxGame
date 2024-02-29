using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class minerLogic : MonoBehaviour
{
    [SerializeField] private GameObject miner;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject ore;
    private bool canMine = true;
    private int minerID;

    private void OnEnable() {
        conveyorLogic.stopMining += stopMining;
    }

    private void OnDisable() {
        conveyorLogic.stopMining += stopMining;
    }

    private void stopMining(int id) {
        canMine = false;
    }
    
    private void Start()
    {
        StartCoroutine(MineOre(waitTime));
        minerID = gameObject.GetInstanceID();
        print(minerID);
    }

    private IEnumerator MineOre(float waitTime)
    {
        while (canMine)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject newObject = Instantiate(ore, new Vector2(transform.position.x, transform.position.y + 1f), transform.rotation);
            newObject.GetComponent<conveyorLogic>().setID(minerID);
        }
    }

}
