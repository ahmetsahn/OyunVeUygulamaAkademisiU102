using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform spawnBulletPosition;
    [SerializeField] private AudioClip ShootSound;
    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public virtual void Shoot()
    {
        
    }

    public virtual void PlayShootSound()
    {
        audioSource.PlayOneShot(ShootSound);
    }
}
