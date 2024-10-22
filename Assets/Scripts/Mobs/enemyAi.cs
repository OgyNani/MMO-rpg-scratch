using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    private float roamingRadius;
    private enemyPathFinder enemyPathFinder;
    private Vector2 startPosition;

    public void Init(IMobData mobData)
    {
        roamingRadius = mobData.GetRoamingRadius();
        enemyPathFinder.Init(mobData); // Передаём данные в enemyPathFinder
    }


    private void Awake()
    {
        enemyPathFinder = GetComponent<enemyPathFinder>();
    }


    private void Start()
    {
        enemyPathFinder = GetComponent<enemyPathFinder>();
        IMobData mobData = GetComponent<IMobData>();
        Init(mobData);
    }


    private IEnumerator RoamingRoutine()
    {
        while (true)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathFinder.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 roamPosition = startPosition + randomDirection * Random.Range(0f, roamingRadius);
        return roamPosition;
    }
}
