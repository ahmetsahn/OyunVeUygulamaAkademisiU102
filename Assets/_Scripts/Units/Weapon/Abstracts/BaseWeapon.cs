using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private GameObject shootEffect;
    [SerializeField] private AudioClip shootSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public virtual void Shoot()
    {
        
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public virtual void PlayShootEffect()
    {
        shootEffect.SetActive(false);
        shootEffect.SetActive(true);
    }
}
