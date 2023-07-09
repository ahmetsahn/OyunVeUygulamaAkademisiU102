using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class AlienCollectorWeapon : BaseWeapon
{
    [SerializeField] private IntReference currentAmmo;
    [SerializeField] private int maxAmmo = 3;
    

    private void Start()
    {
        canReload = false;
    }

    public override void Shoot()
    {

        if (MousePosition.Instance.GetMousePos() != Vector3.zero)
        {
            if (MousePosition.Instance.hit.collider.gameObject.GetComponent<Alien>() != null)
            {
                if (currentAmmo.Value < maxAmmo)
                {
                    currentAmmo.Value++;
                    MousePosition.Instance.hit.collider.gameObject.GetComponent<Alien>().HandleGoInsideGunMovement();
                    PlayShootSound();
                    PlayShootEffect();
                    base.Shoot();
                }
            }

            if (MousePosition.Instance.hit.collider.gameObject.name=="Plane")
            {
                if (currentAmmo.Value > 0)
                {
                    currentAmmo.Value--;
                    GetAlien();
                    base.Shoot();
                }
            }


        }
    }

    private void GetAlien()
    {
        var alien = AlienPool.Instance.Get();
        alien.transform.SetPositionAndRotation(MousePosition.Instance.GetMousePos(), Quaternion.identity);
        alien.gameObject.SetActive(true);
        alien.GetComponent<Alien>().HandleGoOutsideGunMovement();
    }

}
