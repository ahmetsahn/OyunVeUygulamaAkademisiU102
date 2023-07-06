using AlienSystem;
using UnityEngine;


public class Alien : MonoBehaviour
{
    private IAlienState currentState;
    public FreeState freeState = new();
    public WorkState workState = new();
    [SerializeField] private bool isWork;
    [field: SerializeField] public bool isMine { get; set; }

    private AlienAIMovement alienAIMovement;

    private void Awake()
    {
        alienAIMovement = GetComponent<AlienAIMovement>();
    }

    private void Start()
    {
        currentState = isWork ? workState : freeState;
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
