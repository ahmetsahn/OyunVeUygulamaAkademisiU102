using UnityEngine;

public class FreeState : IAlienState
{
    public void UpdateState(Alien alien)
    {
        alien.HandleFreeMovement();
    }
}
