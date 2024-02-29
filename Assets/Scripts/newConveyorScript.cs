using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newConveyorScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;

    private void Update()
    {
        float roation = gameObject.transform.eulerAngles.z;

        if (roation == 0)
        {
            direction = Vector2.up;
        } else if (roation == 90f)
        {
            direction = Vector2.left;
        } else if (roation == 180f)
        {
            direction = Vector2.down;
        } else if (roation == 270f)
        {
            direction = Vector2.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ore"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = direction * speed;
            
        }
    }
}
