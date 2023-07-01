using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;
    
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        currentHealth.Value = maxHealth.Value;
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth.Value -= damage;
        GetHitEffect();

        if (currentHealth.Value <= 0)
        {
            enemy.SetState(enemy.deathState);
        }

    }

    private void GetHitEffect()
    {
        var hitEffect = HitEffectPool.Instance.Get();
        hitEffect.transform.position = MousePosition.Instance.GetMousePos();
        hitEffect.gameObject.SetActive(true);
    }
}
