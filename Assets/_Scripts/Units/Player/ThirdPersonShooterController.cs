using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class ThirdPersonShooterController : MonoBehaviour
{
    
    [SerializeField] private Transform aimTargetTranform;
    [SerializeField] UnityEvent OnActiveAim;
    [SerializeField] UnityEvent OnDeactiveAim;
    
    private BaseWeapon weapon;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;



    private void Awake()
    {
        
        weapon = GetComponentInChildren<BaseWeapon>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

  


    private void Update()
    {
        SetAimTargetTransform();
        Aim();
    }

    private void SetAimTargetTransform()
    {
        aimTargetTranform.position = MousePosition.Instance.GetMousePos();
    }

    private void Aim()
    {
        if (starterAssetsInputs.aim)
        {
            OnActiveAim.Invoke();
            ActiveAim();

        }

        else
        {
            OnDeactiveAim.Invoke();
            DeactiveAim();
        }
    }

    private void ActiveAim()
    {
        
        float horizontal = Mathf.Lerp(animator.GetFloat("Horizontal"), starterAssetsInputs.move.x, 5 * Time.deltaTime);
        float vertical = Mathf.Lerp(animator.GetFloat("Vertical"), starterAssetsInputs.move.y, 5 * Time.deltaTime);
        animator.SetBool("Aim", true);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        weapon.SetWeaponAimRigActive();
        Vector3 worldAimTarget = aimTargetTranform.position;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        if (starterAssetsInputs.shoot)
        {
            weapon.Shoot();
            weapon.PlayShootSound();
            weapon.PlayShootEffect();
            starterAssetsInputs.shoot = false;
        }
    }

    private void DeactiveAim()
    {
        animator.SetBool("Aim", false);
        weapon.SetWeaponAimRigDeactive();
    }

}
