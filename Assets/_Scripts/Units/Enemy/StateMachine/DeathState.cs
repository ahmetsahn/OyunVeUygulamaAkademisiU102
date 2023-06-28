using UnityEngine;
using DG.Tweening;

public class DeathState : EnemyBaseState
{
    public override void EnterState(Enemy enemy)
    {
        enemy.HandlerDeathEnter();
    }

}
