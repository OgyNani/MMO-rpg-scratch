using UnityEngine;

public class SkeletonWarrior : MonoBehaviour, IMobData
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float roamingRadius = 5f;
    [SerializeField] private float stopDistance = 0.1f;

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

    public float GetStopDistance()
    {
        return stopDistance;
    }
}
