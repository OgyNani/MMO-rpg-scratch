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
        if (player_movement.move_dir.x != 0 || player_movement.move_dir.y != 0)
        {
            animator.SetBool("Move", true);
            last_move_dir = player_movement.move_dir;
            SpriteDirectionChecker(player_movement.move_dir);
        }
        else
        {
            animator.SetBool("Move", false);
            SpriteDirectionChecker(last_move_dir);
        }
    }

    void SpriteDirectionChecker(Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
