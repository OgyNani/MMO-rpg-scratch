using UnityEngine;

public class SkeletonWarrior : MonoBehaviour, IMobData
{
    private float moveSpeed = 2f;
    private float roamingRadius = 5f;
    private float stopDistance = 0.1f;
    private float detectionRadius = 5f;

    private enemyAi enemyAi;
    private enemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyAi = GetComponent<enemyAi>();
        enemyPathFinder = GetComponent<enemyPathFinder>();

        IMobData mobData = this as IMobData;
    }


    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRoamingRadius()
    {
        return roamingRadius;
    }

    public float GetDetectionRadius()
    {
        return detectionRadius;
    }

    public float GetStopDistance()
    {
        return stopDistance;
    }
}
