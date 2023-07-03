using StarterAssets;
using UnityEngine;

public class RiffleWeapon : BaseWeapon
{
    [SerializeField] private int damage = 10;

    public override void Shoot()
    {
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

}
