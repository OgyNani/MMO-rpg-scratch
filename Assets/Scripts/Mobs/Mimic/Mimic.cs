using UnityEngine;

public class Mimic : MonoBehaviour, IMobData
{
    private float moveSpeed = 1.5f;
    private float roamingRadius = 3f;
    private float stopDistance = 0.15f;
    private float detectionRadius = 0f;

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
