using UnityEngine;

public class Mimic : MonoBehaviour, IMobData
{
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float roamingRadius = 3f;
    [SerializeField] private float stopDistance = 0.15f;

    private enemyAi enemyAi;
    private enemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyAi = GetComponent<enemyAi>();
        enemyPathFinder = GetComponent<enemyPathFinder>();

        // Проверяем, что компоненты не null
        if (enemyAi == null)
        {
            Debug.LogError("enemyAi is null in SkeletonWarrior");
        }
        if (enemyPathFinder == null)
        {
            Debug.LogError("enemyPathFinder is null in SkeletonWarrior");
        }

        IMobData mobData = this as IMobData;

        // Проверяем, что mobData не null
        if (mobData != null)
        {
            enemyAi.Init(mobData);
            enemyPathFinder.Init(mobData);
        }
        else
        {
            Debug.LogError("mobData is null in SkeletonWarrior");
        }
    }


    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRoamingRadius()
    {
        return roamingRadius;
    }

    public float GetStopDistance()
    {
        return stopDistance;
    }
}
