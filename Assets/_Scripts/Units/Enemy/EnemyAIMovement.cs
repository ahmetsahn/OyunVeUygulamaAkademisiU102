using UnityEngine;
using UnityEngine.AI;

public class EnemyAIMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float range;

    [SerializeField] private float waitTime = 3.0f;
    private EnemyAnimation enemyAnimation;
   

    private float timer;

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void FreeMove()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            enemyAnimation.SetIdleState();
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                Vector3 point;

                if (RandomPoint(transform.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    enemyAnimation.SetWalkState();
                    agent.SetDestination(point);
                    timer = 0.0f;
                }
            }

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
}
