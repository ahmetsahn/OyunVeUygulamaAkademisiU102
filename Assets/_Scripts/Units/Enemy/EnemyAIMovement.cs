using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using ScriptableObjectArchitecture;

public class EnemyAIMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float walkRange = 10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float waitTime = 3.0f;
    private EnemyAnimation enemyAnimation;
    private float timer;
    [SerializeField] private BoolReference isPlayerDead;

    public float playerRange = 5f;

    private Enemy enemy;
    private bool playerInRange = false;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        agent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void FreeMoveEnter()
    {
        agent.SetDestination(transform.position);
        agent.isStopped = false;
        enemyAnimation.SetIdleState();
        enemyAnimation.SetIdleRigHeight();
    }

    public void FreeMoveUpdate()
    {
        
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            enemyAnimation.SetIdleState();
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                Vector3 point;

                if (RandomPoint(transform.position, walkRange, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    enemyAnimation.SetWalkState();
                    agent.SetDestination(point);
                    timer = 0.0f;
                }
            }

        }

        PlayerInRangeControl();

    }

    private void PlayerInRangeControl()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerRange);

        bool playerDetected = false;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerDetected = true;
                break;
            }
        }

        if (playerDetected && !playerInRange)
        {
            
            playerInRange = true;
           
            enemy.SetState(enemy.attackState);

        }
        else if (!playerDetected && playerInRange)
        {
            
            playerInRange = false;
            enemy.SetState(enemy.freeState);

        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {

            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

  

    public void AttackEnter()
    {
        agent.isStopped = true;
        enemyAnimation.SetAttackState();
        enemyAnimation.SetAimRigHeight();
    }

    public void AttackUpdate()
    {
        
        transform.DOLookAt(playerTransform.position, 0.2f);
        PlayerInRangeControl();

        if(isPlayerDead.Value)
        {
            enemy.SetState(enemy.freeState);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerRange);
    }



}
