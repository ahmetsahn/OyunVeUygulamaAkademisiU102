using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;

    private void Awake()
    {
        currentHealth.Value = maxHealth.Value;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth.Value -= damage;
    }
}
