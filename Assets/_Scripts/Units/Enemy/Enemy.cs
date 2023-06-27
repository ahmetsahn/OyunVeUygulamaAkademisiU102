using EnemySystem;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemyState currentState;
    public FreeState freeState = new();
    public AttackState attackState = new();
    private EnemyAIMovement enemyAIMovement;
    [field: SerializeField] public Transform playerTransform { get; private set; }

    private void Awake()
    {
        enemyAIMovement = GetComponent<EnemyAIMovement>();
    }

    private void Start()
    {
        currentState = freeState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(IEnemyState state)
    {
        currentState = state;
        currentState.EnterState(this);
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
    }

  
}
