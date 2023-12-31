using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ThirdPersonShooterController : MonoBehaviour
{
    
    [SerializeField] private Transform aimTargetTranform;
    [SerializeField] UnityEvent OnActiveAim;
    [SerializeField] UnityEvent OnDeactiveAim;
    [SerializeField] private BaseWeapon[] weapons;
    [SerializeField] private GameObject[] weaponsUIPanel;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;


    private int currentWeaponIndex;
    private int nextWeaponIndex;



    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentWeaponIndex = 0;
        nextWeaponIndex = 1;
    }



    private void Update()
    {
        SetAimTargetTransform();
        Aim();

        if (starterAssetsInputs.swapWeapon && weapons[nextWeaponIndex].isHave.Value)
        {
            animator.SetTrigger("SwapWeapon");
            starterAssetsInputs.swapWeapon = false;
            starterAssetsInputs.AimInput(false);
        }

        else { starterAssetsInputs.swapWeapon = false; }

        if (starterAssetsInputs.reloadBullet && weapons[currentWeaponIndex].canReload)
        {
            ReloadBullet();
            weapons[currentWeaponIndex].PlayReloadSound();
            starterAssetsInputs.reloadBullet = false;
        }

        else { starterAssetsInputs.reloadBullet = false; }
       
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
            starterAssetsInputs.shoot = false;
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
        weapons[currentWeaponIndex].SetWeaponAimRigActive();
        Vector3 worldAimTarget = aimTargetTranform.position;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

        if (starterAssetsInputs.shoot)
        {
            weapons[currentWeaponIndex].Shoot();
            starterAssetsInputs.shoot = false;
        }
    }

    private void DeactiveAim()
    {
        animator.SetBool("Aim", false);
        weapons[currentWeaponIndex].SetWeaponAimRigDeactive();
    }

    public void SwapWeapon()
    {
        weaponsUIPanel[currentWeaponIndex].SetActive(false);
        weapons[currentWeaponIndex].gameObject.SetActive(false);
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        nextWeaponIndex = (nextWeaponIndex + 1) % weapons.Length;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
        weaponsUIPanel[currentWeaponIndex].SetActive(true);

    }

    private void ReloadBullet()
    {
        animator.SetTrigger("Reload");
        starterAssetsInputs.AimInput(false);
    }

    public void UpdateBulletCount()
    {
        weapons[currentWeaponIndex].UpdateBulletCount();
    }
    

}
