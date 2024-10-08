using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator animator;
    PlayerMovement player_movement;
    SpriteRenderer sprite_renderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        player_movement = GetComponent<PlayerMovement>();
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player_movement.move_dir.x != 0 || player_movement.move_dir.y != 0)
        {
            animator.SetBool("Move", true);
            SpriteDirectionChecker();
        }
        else {
            animator.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        animator.SetFloat("Horizontal", player_movement.move_dir.x);
        animator.SetFloat("Vertical", player_movement.move_dir.y);
    }
}
