using StarterAssets;
using UnityEngine;

public class RiffleWeapon : BaseWeapon
{
    
    public override void Shoot()
    {
        GetBullet();
    }

    private void GetBullet()
    {
        Vector3 aimDir = (MousePosition.Instance.GetMousePos() - spawnBulletPosition.position).normalized;
        var bullet = BulletPool.Instance.Get();
        bullet.transform.SetPositionAndRotation(spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        bullet.gameObject.SetActive(true);
    }

   
}
