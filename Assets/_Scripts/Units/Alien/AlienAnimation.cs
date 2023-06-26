using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AlienAnimation : MonoBehaviour
{
    [SerializeField] private Rig workRig;


    private Animator animator;
    
  
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleState()
    {
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsWorking", false);

    }

    public void SetWalkState()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsWorking", false);
    }

    public void SetWorkState()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsWorking", true);
    }

    public void SetGoInsideGunState()
    {
        animator.SetTrigger("IsRunToDive");
    }

    public void SetWorkRigHeight()
    {
        workRig.weight = Mathf.Lerp(workRig.weight, 1f, Time.deltaTime * 10f);
    }
}
