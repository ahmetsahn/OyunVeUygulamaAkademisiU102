using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private Rig aimRig;
    [SerializeField] UnityEvent OnActiveAim;
    [SerializeField] UnityEvent OnDeactiveAim;
    [SerializeField] private Transform debugTransform;
    
    private Vector3 mouseWorldPosition;
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
        RaycastHit();
        Aim();

    }

    private void RaycastHit()
    {
        Vector2 screenCenterPoint = new(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f))
        {
            mouseWorldPosition = hit.point;
            debugTransform.position = hit.point;
        }
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
        aimRig.weight = Mathf.Lerp(aimRig.weight, 1f, Time.deltaTime * 10f);
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        if (starterAssetsInputs.shoot)
        {
            weapon.Shoot();
            weapon.PlayShootSound();
            starterAssetsInputs.shoot = false;
        }
    }

    private void DeactiveAim()
    {
        animator.SetBool("Aim", false);
        aimRig.weight = Mathf.Lerp(aimRig.weight, 0f, Time.deltaTime * 10f);
    }

}
