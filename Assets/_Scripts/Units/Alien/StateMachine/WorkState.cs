using UnityEngine;

namespace AlienSystem
{
    public class WorkState : IAlienState
    {
        public void UpdateState(Alien alien)
        {
            alien.HandleWorkMovement();
        }
    }
}