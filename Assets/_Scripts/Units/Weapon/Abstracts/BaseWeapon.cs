using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Rig aimRig;
    [SerializeField] private ParticleSystem shootEffect;
    [SerializeField] private AudioClip shootSound;
    protected AudioSource audioSource;
    [field : SerializeField] public BoolReference isHave { get; set; }

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

    public virtual void UpdateBulletCount()
    {

    }

    public virtual void PlayReloadSound()
    {
        
    }

    public virtual void PlayEmptySound()
    {
        
    }

}
