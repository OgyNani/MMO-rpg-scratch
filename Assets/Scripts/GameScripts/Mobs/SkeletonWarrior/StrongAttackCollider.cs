using System.Collections.Generic;
using UnityEngine;

public class StrongAttackCollider : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;
    private float attackDamage;

    private Dictionary<string, Vector2[]> attackDirections = new Dictionary<string, Vector2[]>
    {
        { "Left", new Vector2[] {
            new Vector2(-0.12f, 0.88f), new Vector2(-0.43f, 0.88f), new Vector2(-0.64f, 0.69f),
            new Vector2(-0.76f, 0.43f), new Vector2(-0.75f, 0.12f), new Vector2(-0.56f, -0.07f),
            new Vector2(-0.41f, -0.07f), new Vector2(-0.25f, 0.06f), new Vector2(-0.26f, 0.24f),
            new Vector2(-0.49f, 0.26f), new Vector2(-0.48f, 0.48f)
        }},
        { "Down", new Vector2[] {
            new Vector2(0.31f, 0.63f), new Vector2(0.31f, 0.27f), new Vector2(0.24f, 0.14f),
            new Vector2(0.11f, 0.07f), new Vector2(-0.19f, 0.06f), new Vector2(-0.32f, 0.25f),
            new Vector2(-0.50f, 0.25f), new Vector2(-0.64f, 0.10f), new Vector2(-0.61f, -0.02f),
            new Vector2(-0.31f, -0.19f), new Vector2(0.13f, -0.19f), new Vector2(0.31f, -0.07f),
            new Vector2(0.44f, 0.14f), new Vector2(0.44f, 0.49f), new Vector2(0.37f, 0.63f)
        }},
         { "Up", new Vector2[] {
            new Vector2(0.31f, 0.66f), new Vector2(0.18f, 0.82f), new Vector2(-0.18f, 0.81f),
            new Vector2(-0.26f, 0.69f), new Vector2(-0.36f, 0.62f), new Vector2(-0.43f, 0.44f),
            new Vector2(-0.50f, 0.44f), new Vector2(-0.51f, 0.79f), new Vector2(-0.30f, 0.99f),
            new Vector2(-0.18f, 1.06f), new Vector2(0.24f, 1.06f), new Vector2(0.51f, 0.88f),
            new Vector2(0.62f, 0.67f), new Vector2(0.62f, 0.49f), new Vector2(0.38f, 0.32f),
            new Vector2(0.37f, 0.41f), new Vector2(0.31f, 0.50f)
        }},
        { "Right", new Vector2[] {
            new Vector2(0.50f, 0.26f), new Vector2(0.50f, 0.49f), new Vector2(0.44f, 0.50f),
            new Vector2(0.38f, 0.63f), new Vector2(0.31f, 0.69f), new Vector2(0.23f, 0.81f),
            new Vector2(0.12f, 0.83f), new Vector2(0.12f, 0.87f), new Vector2(0.42f, 0.88f),
            new Vector2(0.48f, 0.82f), new Vector2(0.56f, 0.75f), new Vector2(0.62f, 0.70f),
            new Vector2(0.69f, 0.57f), new Vector2(0.75f, 0.43f), new Vector2(0.75f, 0.13f),
            new Vector2(0.57f, -0.05f), new Vector2(0.44f, -0.06f), new Vector2(0.32f, 0.01f),
            new Vector2(0.26f, 0.07f), new Vector2(0.26f, 0.18f), new Vector2(0.33f, 0.26f)
        }}
    };

    private void Awake()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.enabled = false;
    }

    public void SetAttackDirection(string direction, float damage)
    {
        attackDamage = damage;

        if (attackDirections.ContainsKey(direction))
        {
            polygonCollider.SetPath(0, attackDirections[direction]);
            polygonCollider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        polygonCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerHitbox"))
        {
            PlayerStats playerStats = collision.GetComponentInParent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(attackDamage);
            }
        }
    }

}