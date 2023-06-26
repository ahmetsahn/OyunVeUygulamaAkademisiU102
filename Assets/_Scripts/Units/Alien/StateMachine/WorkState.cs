using UnityEngine;

public class WorkState : IAlienState
{
    public void UpdateState(Alien alien)
    {
        alien.HandleWorkMovement();
    }
}
