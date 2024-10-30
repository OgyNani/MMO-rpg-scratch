using UnityEngine;

public class Mimic : MonoBehaviour, IMobData
{
    private readonly float moveSpeed = 0f;
    private readonly float maxHealth = 50;
    private readonly float maxMana = 0;
    private readonly float defence = 0;
    private readonly float wisdom = 0;
    private readonly float vitality = 0;
    private readonly float attack = 0;
    private readonly float critDamagePercent = 0;
    private readonly float critChancePercent = 0;
    private readonly float expOnKill = 20;
    private readonly float roamingRadius = 0f;
    private readonly float stopDistance = 0f;
    private readonly float detectionRadius = 15f;

    private enemyAi enemyAi;
    private enemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyAi = GetComponent<enemyAi>();
        enemyPathFinder = GetComponent<enemyPathFinder>();

        IMobData mobData = this as IMobData;
    }

    public float GetMoveSpeed() { return moveSpeed; }
    public float GetMaxHealth() { return maxHealth; }
    public float GetMaxMana() { return maxMana; }
    public float GetDefence() { return defence; }
    public float GetWisdom() { return wisdom; }
    public float GetVitality() { return vitality; }
    public float GetAttack() { return attack; }
    public float GetCritDamagePercent() { return critDamagePercent; }
    public float GetCritChancePercent() { return critChancePercent; }
    public float GetExpOnKill() { return expOnKill; }
    public float GetRoamingRadius() { return roamingRadius; }
    public float GetDetectionRadius() { return detectionRadius; }
    public float GetStopDistance() { return stopDistance; }
}
