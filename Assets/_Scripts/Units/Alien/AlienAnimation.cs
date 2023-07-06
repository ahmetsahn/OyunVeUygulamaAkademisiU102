using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEngine.Rendering.DebugUI;

public class AlienAnimation : MonoBehaviour
{
    [SerializeField] private Rig workRig;


    private Animator animator;
    
  
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIdleState(bool value)
    {
        animator.SetBool("IsIdle", value);
    }

    public void SetWalkState(bool value)
    {
        animator.SetBool("IsWalking", value);
    }

    public void SetWorkState(bool value)
    {
        animator.SetBool("IsWorking", value);
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
