using UnityEngine;

namespace EnemySystem
{
    public class AttackState : EnemyBaseState
    {
        public override void EnterState(Enemy enemy)
        {
            enemy.HandlerAttackEnter();    
        }
        
        public override void UpdateState(Enemy enemy)
        {
            enemy.HandlerAttackUpdate();
 
        }
    }
}