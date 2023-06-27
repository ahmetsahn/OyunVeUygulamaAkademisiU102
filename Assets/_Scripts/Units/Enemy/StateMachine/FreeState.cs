using UnityEngine;

namespace EnemySystem
{
    public class FreeState : IEnemyState
    {
        public void UpdateState(Enemy enemy)
        {
            enemy.HandleFreeMovement();
        }
    }
}