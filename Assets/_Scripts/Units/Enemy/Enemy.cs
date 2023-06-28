using EnemySystem;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyBaseState currentState;
    public FreeState freeState = new();
    public AttackState attackState = new();
    public DeathState deathState = new();
    private EnemyAIMovement enemyAIMovement;
    private EnemyAttack enemyAttack;


    private void Awake()
    {
        enemyAIMovement = GetComponent<EnemyAIMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Start()
    {
        currentState = freeState;
        currentState?.EnterState(this);
    }

    private void Update()
    {
        currentState?.UpdateState(this);
    }

    public void SetState(EnemyBaseState state)
    {
        currentState = state;
        currentState?.EnterState(this);
    }

    public void HandleFreeMovementEnter()
    {
        enemyAIMovement.FreeMoveEnter();
    }

    public void HandleFreeMovementUpdate()
    {
        enemyAIMovement.FreeMoveUpdate();
    }
    
    public void HandlerAttackEnter()
    {
        enemyAIMovement.AttackEnter();
    }

    public void HandlerAttackUpdate()
    {
        enemyAIMovement.AttackUpdate();
        enemyAttack.Attack();
    }

    public void HandlerDeathEnter()
    {
        enemyAIMovement.DeathEnter();
    }

  
}
