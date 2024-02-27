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

    private void Start()
    {
        StartCoroutine(MineOre(waitTime));
    }

    private IEnumerator MineOre(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(ore, new Vector2(transform.position.x, transform.position.y + 1f), transform.rotation);
        }
    }
}
