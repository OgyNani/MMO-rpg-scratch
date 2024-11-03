using System.Collections;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    private float roamingRadius;
    private float detectionRadius;
    private enemyPathFinder enemyPathFinder;
    private Vector2 startPosition;
    private Transform playerTransform;
    private State state;
    private bool isChasing = false;

    private enum State
    {
        Roaming,
        ChasingPlayer
    }

    public void Init(IMobData mobData)
    {
        roamingRadius = mobData.GetRoamingRadius();
        detectionRadius = mobData.GetDetectionRadius();
        enemyPathFinder.Init(mobData);
    }

    private void Awake()
    {
        enemyPathFinder = GetComponent<enemyPathFinder>();
        state = State.Roaming;
        startPosition = transform.position;
    }

    private IEnumerator Start()
    {
        // Даем кадр на инициализацию сцены и позиций объектов
        yield return null;

        // Инициализируем игрока после загрузки сцены
        playerTransform = GameObject.FindWithTag("Player")?.transform;

        IMobData mobData = GetComponent<IMobData>();
        if (mobData != null)
        {
            Init(mobData);
        }
        else
        {
            Debug.LogError("IMobData not found on the enemy object.");
        }

        StartCoroutine(RoamingRoutine());
    }

    private void Update()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        if (playerTransform == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < detectionRadius && state != State.ChasingPlayer && !isChasing)
        {
            state = State.ChasingPlayer;
            isChasing = true;
            StopCoroutine(RoamingRoutine());
            StartCoroutine(ChasePlayer());
        }
        else if (distanceToPlayer >= detectionRadius && state == State.ChasingPlayer && isChasing)
        {
            state = State.Roaming;
            isChasing = false;
            StopCoroutine(ChasePlayer());
            StartCoroutine(RoamingRoutine());
        }
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinder.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float distance = Random.Range(0f, roamingRadius);
        Vector2 roamPosition = startPosition + randomDirection * distance;
        return roamPosition;
    }

    private IEnumerator ChasePlayer()
    {
        while (state == State.ChasingPlayer)
        {
            if (playerTransform != null)
            {
                enemyPathFinder.MoveTo(playerTransform.position);
            }
            else
            {
                isChasing = false;
                yield break;
            }
            yield return null;
        }
        isChasing = false;
    }
}
