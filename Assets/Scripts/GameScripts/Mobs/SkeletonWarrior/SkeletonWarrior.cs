using UnityEngine;

public class SkeletonWarrior : MonoBehaviour, IMobData
{
    private readonly float moveSpeed = 2f;
    private readonly float maxHealth = 100;
    private readonly float maxMana = 100;
    private readonly float defence = 0;
    private readonly float wisdom = 2;
    private readonly float vitality = 2;
    private readonly float attack = 5;
    private readonly float critDamagePercent = 4;
    private readonly float critChancePercent = 4;
    private readonly float expOnKill = 10;
    private readonly float roamingRadius = 5f;
    private readonly float stopDistance = 0.1f;
    private readonly float detectionRadius = 5f;

    private enemyAi enemyAi;
    private enemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyAi = GetComponent<enemyAi>();
        enemyPathFinder = GetComponent<enemyPathFinder>();

        IMobData mobData = this as IMobData;
    }

    public float GetMoveSpeed(){return moveSpeed;}
    public float GetMaxHealth(){return maxHealth;}
    public float GetMaxMana(){return maxMana; }
    public float GetDefence(){return defence; }
    public float GetWisdom(){return wisdom; }
    public float GetVitality(){return vitality; }
    public float GetAttack(){return attack; }
    public float GetCritDamagePercent(){return critDamagePercent; }
    public float GetCritChancePercent(){return critChancePercent; }
    public float GetExpOnKill(){return expOnKill; }
    public float GetRoamingRadius(){return roamingRadius;}
    public float GetDetectionRadius(){return detectionRadius;}
    public float GetStopDistance(){return stopDistance;}
}
