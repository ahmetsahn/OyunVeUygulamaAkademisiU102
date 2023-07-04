using ScriptableObjectArchitecture;
using StarterAssets;
using UnityEngine;

public class RiffleWeapon : BaseWeapon
{
    [SerializeField] private int damage = 10;
    [SerializeField] private IntReference currentBulletCount;
    [SerializeField] private IntReference totalBulletCount;

    public override void Shoot()
    {
        if(currentBulletCount.Value>0)
        {
            currentBulletCount.Value--;
            PlayShootSound();
            PlayShootEffect();

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
           if(totalBulletCount.Value>=30)
            {
                currentBulletCount.Value += 30;
                totalBulletCount.Value -= 30;
            }

           else
            {
                currentBulletCount.Value += totalBulletCount.Value;
                totalBulletCount.Value = 0;
            }
        }

       
    }

}
