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

    private PlayerSkills playerSkills;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSkills = GetComponent<PlayerSkills>();
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
        if (playerSkills != null && !playerSkills.IsShieldActive())
        {
            rb.velocity = move_dir * move_speed;
        }
        else
        {
            // Stop movement if shield is active
            rb.velocity = Vector2.zero;
        }
    }
}
