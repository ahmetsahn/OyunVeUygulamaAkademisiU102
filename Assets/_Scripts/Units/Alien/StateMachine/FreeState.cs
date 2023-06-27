using UnityEngine;

namespace AlienSystem
{
    public class FreeState : IAlienState
    {
        public void UpdateState(Alien alien)
        {
            alien.HandleFreeMovement();
        }
    }
}