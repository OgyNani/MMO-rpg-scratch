using UnityEngine;

public class enemyPathFinder : MonoBehaviour
{
    private float moveSpeed;
    private float stopDistance;

    private Rigidbody2D rb;
    private Vector2 targetPosition;

    public void Init(IMobData mobData) // Инициализация данных моба
    {
        moveSpeed = mobData.GetMoveSpeed();
        stopDistance = mobData.GetStopDistance();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        float distanceToTarget = Vector2.Distance(position, targetPosition);

        if (distanceToTarget > stopDistance)
        {
            Vector2 direction = (targetPosition - position).normalized;
            rb.MovePosition(position + direction * (moveSpeed * Time.fixedDeltaTime));
        }
    }

    public void MoveTo(Vector2 newTargetPosition)
    {
        targetPosition = newTargetPosition;
    }
}
