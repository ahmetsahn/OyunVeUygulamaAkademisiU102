using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform spawnBulletPosition;
    
    public virtual void Shoot()
    {
        
    }

    public virtual void PlayShootSound()
    {

    }
}
