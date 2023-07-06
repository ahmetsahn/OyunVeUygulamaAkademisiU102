using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using DG.Tweening;

public class AlienAIMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private float range;

    [SerializeField] private float waitTime = 3.0f;
    [SerializeField] private UnityEvent OnWork;

    private AlienAnimation alienAnimation;
    private Alien alien;
    private float timer = 0.0f;
    
    private void Awake()
    {
        alien = GetComponent<Alien>();
        agent = GetComponent<NavMeshAgent>();
        alienAnimation = GetComponent<AlienAnimation>();
    }


    public void FreeMove()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            alienAnimation.SetWalkState(false);
            alienAnimation.SetIdleState(true);
            timer += Time.deltaTime;
            
            if (timer >= waitTime)
            {
                Vector3 point;

                if (RandomPoint(transform.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    alienAnimation.SetIdleState(false);
                    alienAnimation.SetWalkState(true);
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


    public void WorkMove()
    {
        GameObject[] stones = GameObject.FindGameObjectsWithTag("Stone");
        Transform closestStone = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject stone in stones)
        {
         
            Vector3 stonePosition = stone.transform.position;

           
            float distance = Vector3.Distance(stonePosition, transform.position);

            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestStone = stone.transform;
            }
        }

        agent.SetDestination(closestStone.position);
        alienAnimation.SetIdleState(false);
        alienAnimation.SetWalkState(true);

        if (closestDistance <= agent.stoppingDistance)
        {
            alienAnimation.SetWalkState(false);
            alienAnimation.SetWorkState(true);
            alienAnimation.SetWorkRigHeight();
            OnWork.Invoke();
        }

    }

    public void GoInsideGunMovement()
    {
        
        transform.DOLookAt(GameObject.Find("Player").transform.position, 0.9f);
        alienAnimation.SetGoInsideGunState();
        transform.DOScale(0.2f, 0.5f);
        transform.DOMove(GameObject.Find("FirePoint").transform.position, 0.9f).onComplete += () =>
        {
            AlienPool.Instance.ReturnToPool(alien);
        }; 
        

    }

    public void GoOutsideGunMovement()
    {
        transform.DOScale(1f, 0.5f).onComplete += () =>
            {
                alien.SetState(alien.workState);
               
            };
    }

}
