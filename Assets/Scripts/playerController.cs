using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D _rb;

    private Vector2 _moveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = new Vector3(_moveInput.x, _moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount);
    } 

    public void moveScript(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
}
