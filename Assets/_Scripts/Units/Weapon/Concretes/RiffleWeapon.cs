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

    
    public override void Shoot()
    {
        canReload = true;

        if (currentBulletCount.Value>0)
        {
            currentBulletCount.Value--;
            PlayShootSound();
            PlayShootEffect();
            base.Shoot();

            if (MousePosition.Instance.GetMousePos() != Vector3.zero)
            {
                if (MousePosition.Instance.hit.collider.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(damage);
                    GetEnemyHitEffect();
                    Debug.Log("Enemy Hit");
                }

                else
                {
                    GetDefaultHitEffect();
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

        if (totalBulletCount.Value == 0 || currentBulletCount.Value == magazineBulletCapacity.Value)
        {
            canReload = false;
        }

        base.UpdateBulletCount();

    }

    public override void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadSound);
    }

    public override void PlayEmptySound()
    {
        audioSource.PlayOneShot(emptySound);
    }

    private void GetEnemyHitEffect()
    {
        var hitEffect = EnemyHitEffectPool.Instance.Get();
        hitEffect.transform.position = MousePosition.Instance.GetMousePos();
        hitEffect.gameObject.SetActive(true);

        
    }

    private void GetDefaultHitEffect()
    {
        var hitEffect = DefaultHitEffectPool.Instance.Get();
        hitEffect.transform.position = MousePosition.Instance.GetMousePos();
        hitEffect.gameObject.SetActive(true);
    }


}
