using UnityEngine;

namespace EnemySystem
{
    public class AttackState : IEnemyState
    {
        public void EnterState(Enemy enemy)
        {
            enemy.HandlerAttackEnter();    
        }
        
        public void UpdateState(Enemy enemy)
        {
            enemy.HandlerAttackUpdate();

            
        }
    }
}