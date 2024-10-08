using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float move_speed;
    Rigidbody2D rb;
    [HideInInspector]
    public Vector2 move_dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() //Frame rate dependent
    {
        InputManage();
    }

    void FixedUpdate() //Frame rate independent
    {
        Move();
    }

    void InputManage()
    {
        float move_x = Input.GetAxisRaw("Horizontal");
        float move_y = Input.GetAxisRaw("Vertical");

        move_dir = new Vector2 (move_x, move_y).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(move_dir.x * move_speed, move_dir.y * move_speed);
    }
}
