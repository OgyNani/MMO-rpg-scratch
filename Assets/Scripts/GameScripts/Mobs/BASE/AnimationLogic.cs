using UnityEngine;

public class AnimationLogic : MonoBehaviour
{
    private Animator animator;
    private enemyPathFinder pathFinder;
    private Vector2 lastDirection;
    private EnemyAttack enemyAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        pathFinder = GetComponent<enemyPathFinder>();
        enemyAttack = GetComponent<EnemyAttack>();

        lastDirection = Vector2.down;
    }

    void Update()
    {
        if (pathFinder == null || animator == null) return;

        if (enemyAttack.isAttacking) return;

        Vector2 currentDirection = pathFinder.CurrentDirection();
        bool isMoving = currentDirection != Vector2.zero;

        if (isMoving)
        {
            animator.SetBool("Walk", true);
            lastDirection = currentDirection;
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }
    }
}
