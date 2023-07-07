using ScriptableObjectArchitecture;
using StarterAssets;
using UnityEngine;

public class RiffleWeapon : BaseWeapon
{
    [SerializeField] private int damage = 10;
    [SerializeField] private IntReference currentBulletCount;
    [SerializeField] private IntReference magazineBulletCapacity;
    [SerializeField] private IntReference totalBulletCount;
    [SerializeField] private IntReference totalBulletCapacity;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip emptySound;

    private void Start()
    {
        canReload = true;
    }

    public override void Shoot()
    {
        if(currentBulletCount.Value>0)
        {
            currentBulletCount.Value--;
            PlayShootSound();
            PlayShootEffect();
            GetHitEffect();

            if (MousePosition.Instance.GetMousePos() != Vector3.zero)
            {
                if (MousePosition.Instance.hit.collider.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

        else
        {
            PlayEmptySound();
        }

       
    }

    public override void UpdateBulletCount()
    {
        int difference = magazineBulletCapacity.Value - currentBulletCount.Value;

        if (totalBulletCount.Value >= difference)
        {
            currentBulletCount.Value += difference;
            totalBulletCount.Value -= difference;
        }

        else
        {
            currentBulletCount.Value += totalBulletCount.Value;
            totalBulletCount.Value = 0;
        }

        if (totalBulletCount.Value == 0)
        {
            canReload = false;
        }

    }

    public override void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadSound);
    }

    public override void PlayEmptySound()
    {
        audioSource.PlayOneShot(emptySound);
    }

    private void GetHitEffect()
    {
        var hitEffect = HitEffectPool.Instance.Get();
        hitEffect.transform.position = MousePosition.Instance.GetMousePos();
        hitEffect.gameObject.SetActive(true);
    }

    
}
