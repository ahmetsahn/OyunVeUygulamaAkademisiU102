using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    public Transform firePoint; 
    public float shootInterval = 1f; 
    private float shootTimer = 0f;
    [SerializeField] private int damage = 10;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameObject shootEffect;
    private AudioSource audioSource;
    [SerializeField] private UnityEvent UpdateUI;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Attack()
    {
        shootTimer += Time.deltaTime; 

        if (shootTimer >= shootInterval)
        {
            Shoot(); 
            shootTimer = 0f;
        }
    }

    

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(damage);
                UpdateUI.Invoke();
            }
        }
        PlayShootSound();
        PlayShootEffect();
    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    private void PlayShootEffect()
    {
        shootEffect.SetActive(false);
        shootEffect.SetActive(true);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.forward * 100f);
    }
}
