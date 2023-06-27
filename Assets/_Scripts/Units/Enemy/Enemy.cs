using EnemySystem;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemyState currentState;
    public FreeState freeState = new();
    public WarState warState = new();

    private EnemyAIMovement enemyAIMovement;

    private void Awake()
    {
        enemyAIMovement = GetComponent<EnemyAIMovement>();
    }

    private void Start()
    {
        currentState = freeState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(IEnemyState state)
    {
        currentState = state;
    }

    public void HandleFreeMovement()
    {
        enemyAIMovement.FreeMove();
    }
}
