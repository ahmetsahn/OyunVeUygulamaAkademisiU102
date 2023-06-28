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

        if (currentHealth.Value <= 0)
        {
            enemy.SetState(enemy.deathState);
        }

    }
}
