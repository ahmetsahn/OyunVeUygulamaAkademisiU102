using UnityEngine;


public class Alien : MonoBehaviour
{
    private IAlienState currentState;
    public FreeState freeState = new();
    public WorkState workState = new();

    [SerializeField] private AlienAIMovement alienAIMovement;

    private void Start()
    {
        currentState = freeState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SetState(IAlienState state)
    {
        currentState = state;
    }

    public void HandleFreeMovement()
    {
        alienAIMovement.FreeMove();
    }

    public void HandleWorkMovement()
    {
        alienAIMovement.WorkMove();
    }

    public void HandleGoInsideGunMovement()
    {
        alienAIMovement.GoInsideGunMovement();
    }

    public void HandleGoOutsideGunMovement()
    {
        alienAIMovement.GoOutsideGunMovement();
    }

}