using UnityEngine;

namespace EnemySystem
{
    public class FreeState : EnemyBaseState
    {
        public override void EnterState(Enemy enemy)
        {
            enemy.HandleFreeMovementEnter();
        }

        public override void UpdateState(Enemy enemy)
        {
            enemy.HandleFreeMovementUpdate();
            
        }
    }
}