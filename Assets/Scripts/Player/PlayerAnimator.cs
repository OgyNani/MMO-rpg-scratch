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
        Vector2 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ѕолучаем позицию мыши в мировых координатах
        Vector2 direction_to_mouse = (mouse_position - (Vector2)transform.position).normalized; // ¬ектор направлени€ от персонажа до мыши

        if (player_movement.move_dir.x != 0 || player_movement.move_dir.y != 0)
        {
            animator.SetBool("Move", true);
            last_move_dir = direction_to_mouse; // Ќаправление беретс€ из позиции мышки
        }
        else
        {
            animator.SetBool("Move", false);
        }

        SpriteDirectionChecker(direction_to_mouse); // »спользуем направление на мышь дл€ обновлени€ анимации
    }

    void SpriteDirectionChecker(Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
