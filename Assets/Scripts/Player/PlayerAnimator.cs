using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerMovement player_movement;
    SpriteRenderer sprite_renderer;

    private Vector2 last_move_dir;

    void Start()
    {
        animator = GetComponent<Animator>();
        player_movement = GetComponent<PlayerMovement>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        last_move_dir = Vector2.down;
    }

    void Update()
    {
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction_to_mouse = (mouse_position - (Vector2)transform.position).normalized;

        if (player_movement.move_dir.x != 0 || player_movement.move_dir.y != 0)
        {
            animator.SetBool("Move", true);
            last_move_dir = direction_to_mouse;
        }
        else
        {
            animator.SetBool("Move", false);
        }

        SpriteDirectionChecker(direction_to_mouse);
    }

    void SpriteDirectionChecker(Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
