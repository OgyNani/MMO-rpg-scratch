using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public StrongAttackCollider strongAttackCollider;
    public CircleCollider2D detectCollider;

    private Animator animator;
    private Vector2 lastDirection;
    public bool isAttacking;
    private Transform target;

    private void Start()
    {
        animator = GetComponent<Animator>();
        detectCollider = GetComponentInChildren<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.transform;
            if (!isAttacking)
            {
                StartCoroutine(AttackLoop());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(AttackLoop());
            isAttacking = false;
            target = null;
        }
    }


    private IEnumerator AttackLoop()
    {
        isAttacking = true;

        while (isAttacking && target != null)
        {
            Vector2 attackDirection = (target.position - transform.position).normalized;
            lastDirection = attackDirection;

            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
            animator.SetTrigger("StrongAttack");

            SetAttackColliderDirection(attackDirection);

            yield return new WaitForSeconds(1f); // Ожидание перед следующей атакой
        }
    }


    private void SetAttackColliderDirection(Vector2 direction)
    {
        string directionKey = "";

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            directionKey = direction.x > 0 ? "Right" : "Left";
        }
        else
        {
            directionKey = direction.y > 0 ? "Up" : "Down";
        }

        strongAttackCollider.SetAttackDirection(directionKey, GetComponent<SkeletonWarriorStats>().GetAttack());
    }

    // Эти методы нужны для анимационных событий
    public void EnableAttackCollider()
    {
        strongAttackCollider.gameObject.SetActive(true);
    }

    public void DisableAttackCollider()
    {
        strongAttackCollider.DisableCollider();
    }
}
