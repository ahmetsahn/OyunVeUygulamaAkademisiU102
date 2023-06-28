using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rig aimRig;
    [SerializeField] private Rig �dleRig;
  

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleState()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", false);
    }

    public void SetWalkState()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsAttacking", false);
    }

    public void SetAttackState() {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsAttacking", true);
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Death");
        SetIdleRigHeight();
    }

    public void SetAimRigHeight()
    {
        aimRig.weight = 1;
        �dleRig.weight = 0;
    }

    public void SetIdleRigHeight()
    {
        �dleRig.weight = 1;
        aimRig.weight = 0;
    }
}
