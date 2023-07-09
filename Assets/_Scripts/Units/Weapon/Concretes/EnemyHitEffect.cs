using System;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), 1f);
    }

    private void ReturnToPool()
    {
        EnemyHitEffectPool.Instance.ReturnToPool(this);
    }
}
