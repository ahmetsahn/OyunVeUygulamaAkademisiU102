using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;
    [SerializeField] private BoolReference isPlayerDead;
    [SerializeField] private UnityEvent OnDeath;
    

    private void Awake()
    {
       
        currentHealth.Value = maxHealth.Value;
        isPlayerDead.Value = false;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth.Value -= damage;

        if (currentHealth.Value <= 0)
        {
            OnDeath.Invoke();
            isPlayerDead.Value = true;
        }

    }
}