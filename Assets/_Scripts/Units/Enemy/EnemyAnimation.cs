using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleState()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
    }

    public void SetWalkState()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", true);
    }
}
