using UnityEngine;
using UnityEngine.Animations.Rigging;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Rig aimRig;
    [SerializeField] private ParticleSystem shootEffect;
    [SerializeField] private AudioClip shootSound;
    private AudioSource audioSource;

    public bool canReload;

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

    public void PlayShootEffect()
    {
        shootEffect.Play();
    }

    public void SetWeaponAimRigActive()
    {
        aimRig.weight = Mathf.Lerp(aimRig.weight, 1f, Time.deltaTime * 10f);
    }

    public void SetWeaponAimRigDeactive()
    {
        aimRig.weight = Mathf.Lerp(aimRig.weight, 0f, Time.deltaTime * 10f);
    }
}
