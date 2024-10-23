using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    private float roamingRadius;
    private enemyPathFinder enemyPathFinder;
    private Vector2 startPosition;  // ��������� �������

    public void Init(IMobData mobData)
    {
        roamingRadius = mobData.GetRoamingRadius();
        enemyPathFinder.Init(mobData); // ������� ������ � enemyPathFinder
    }

    private void Awake()
    {
        enemyPathFinder = GetComponent<enemyPathFinder>();
    }

    private void Start()
    {
        startPosition = transform.position;  // �������������� ��������� ������� ��� ������
        IMobData mobData = GetComponent<IMobData>();
        Init(mobData);
        StartCoroutine(RoamingRoutine()); // ��������� ��������
    }

    private IEnumerator RoamingRoutine()
    {
        while (true)
        {
            Vector2 roamPosition = GetRoamingPosition(); // �������� ��������� �����
            enemyPathFinder.MoveTo(roamPosition); // �������� ����� ��� �����������
            yield return new WaitForSeconds(2f); // ���� 2 ������� ����� ��������� ������������
        }
    }

    private Vector2 GetRoamingPosition()
    {
        // ��������� ��������� ����� � �������� ������� �� ��������� �������
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // ����������� � �������� ����������
        float distance = Random.Range(0f, roamingRadius); // ��������� ��������� �� ������� �������
        Vector2 roamPosition = startPosition + randomDirection * distance; // ����� ������� ��� �����������

        return roamPosition;
    }
}
