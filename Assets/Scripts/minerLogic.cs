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
    private GameObject _veinField;

    private void Start()
    {
        StartCoroutine(MineOre(waitTime));
    }

    private IEnumerator MineOre(float waitTime)
    {
        yield return new WaitForSeconds(1f);
        veinManager veinManager = _veinField.GetComponent<veinManager>();
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (_veinField.gameObject != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), Vector2.zero);
                if (hit.collider == null)
                {
                    Instantiate(ore, new Vector2(transform.position.x, transform.position.y + 1f), transform.rotation);
                    veinManager.oreMined();
                        
                }
                else
                {
                    if (!hit.collider.CompareTag("Ore"))
                    {
                        Instantiate(ore, new Vector2(transform.position.x, transform.position.y + 1f), transform.rotation); 
                        veinManager.oreMined();
                    } 
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("colliding with miner");
        if (other.gameObject.CompareTag("field"))
        {
            _veinField = other.gameObject;
        }
    }
}
