using System;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), 1f);
    }

    private void ReturnToPool()
    {
        HitEffectPool.Instance.ReturnToPool(this);
    }
}
