using UnityEngine;

namespace EnemySystem
{
    public class FreeState : IEnemyState
    {
        public void EnterState(Enemy enemy)
        {
            enemy.HandleFreeMovementEnter();
        }

        public void UpdateState(Enemy enemy)
        {
            enemy.HandleFreeMovementUpdate();
            
        }
    }
}