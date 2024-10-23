using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    private float roamingRadius;
    private enemyPathFinder enemyPathFinder;
    private Vector2 startPosition;  // Начальная позиция

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
        startPosition = transform.position;  // Инициализируем стартовую позицию при старте
        IMobData mobData = GetComponent<IMobData>();
        Init(mobData);
        StartCoroutine(RoamingRoutine()); // Запускаем движение
    }

    private IEnumerator RoamingRoutine()
    {
        while (true)
        {
            Vector2 roamPosition = GetRoamingPosition(); // Получаем случайную точку
            enemyPathFinder.MoveTo(roamPosition); // Передаем точку для перемещения
            yield return new WaitForSeconds(2f); // Ждем 2 секунды перед следующим перемещением
        }
    }

    private Vector2 GetRoamingPosition()
    {
        // Генерация случайной точки в пределах радиуса от стартовой позиции
        Vector2 randomDirection = Random.insideUnitCircle.normalized; // Направление в пределах окружности
        float distance = Random.Range(0f, roamingRadius); // Случайная дистанция до границы радиуса
        Vector2 roamPosition = startPosition + randomDirection * distance; // Новая позиция для перемещения

        return roamPosition;
    }
}
