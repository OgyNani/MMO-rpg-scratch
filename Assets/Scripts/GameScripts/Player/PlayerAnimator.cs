using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    private Vector2 lastMoveDir;
    private AnimatorOverrideController overrideController;

    private bool isShieldActive;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMoveDir = Vector2.down;

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
    }

    public void SetCharacterAnimations(Skin skin)
    {
        Dictionary<string, AnimationClip> animations = skin.GetAnimations();
        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        overrideController.GetOverrides(overrides);

        foreach (var animation in animations)
        {
            for (int i = 0; i < overrides.Count; i++)
            {
                if (overrides[i].Key.name == animation.Key)
                {
                    overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, animation.Value);
                    break;
                }
            }
        }

        overrideController.ApplyOverrides(overrides);
    }

    public void SetShieldActive(bool isActive)
    {
        isShieldActive = isActive;
        animator.SetBool("Shield", isActive);
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - (Vector2)transform.position).normalized;

        SpriteDirectionChecker(directionToMouse);

        if (!isShieldActive)
        {
            if (playerMovement.move_dir.x != 0 || playerMovement.move_dir.y != 0)
            {
                animator.SetBool("Move", true);
                lastMoveDir = directionToMouse;
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }
    }

    void SpriteDirectionChecker(Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}
