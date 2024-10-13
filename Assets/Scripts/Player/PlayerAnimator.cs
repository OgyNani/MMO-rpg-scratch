using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    private Vector2 lastMoveDir;

    private AnimatorOverrideController overrideController;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMoveDir = Vector2.down;

        if (animator.runtimeAnimatorController == null)
        {
            Debug.LogError("Animator does not have a runtimeAnimatorController assigned.");
            return;
        }

        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        if (overrideController == null)
        {
            Debug.LogError("Failed to create AnimatorOverrideController.");
            return;
        }

        animator.runtimeAnimatorController = overrideController;
        Debug.Log("AnimatorOverrideController has been successfully created and assigned.");
    }

    public void SetCharacterAnimations(Skin skin)
    {
        if (overrideController == null)
        {
            Debug.LogError("AnimatorOverrideController is null.");
            return;
        }

        Dictionary<string, AnimationClip> animations = skin.GetAnimations();
        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        overrideController.GetOverrides(overrides);

        foreach (var animation in animations)
        {
            bool found = false;
            for (int i = 0; i < overrides.Count; i++)
            {
                if (overrides[i].Key.name == animation.Key)
                {
                    overrides[i] = new KeyValuePair<AnimationClip, AnimationClip>(overrides[i].Key, animation.Value);
                    found = true;
                    Debug.Log("Replaced animation for key: " + animation.Key);
                    break;
                }
            }

            if (!found)
            {
                Debug.LogError("Key not found in AnimatorOverrideController: " + animation.Key);
            }
        }

        overrideController.ApplyOverrides(overrides);
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - (Vector2)transform.position).normalized;

        if (playerMovement.move_dir.x != 0 || playerMovement.move_dir.y != 0)
        {
            animator.SetBool("Move", true);
            lastMoveDir = directionToMouse;
        }
        else
        {
            animator.SetBool("Move", false);
        }

        SpriteDirectionChecker(directionToMouse);
    }

    void SpriteDirectionChecker(Vector2 direction)
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }
}