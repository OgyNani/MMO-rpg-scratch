using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed;
    private Rigidbody2D rb;
    [HideInInspector]
    public Vector2 move_dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move_dir = context.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = move_dir * move_speed;
    }
}
