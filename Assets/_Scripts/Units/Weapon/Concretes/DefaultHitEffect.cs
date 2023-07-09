using UnityEngine;

public class DefaultHitEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), 1f);
    }

    private void ReturnToPool()
    {
        DefaultHitEffectPool.Instance.ReturnToPool(this);
    }
}
