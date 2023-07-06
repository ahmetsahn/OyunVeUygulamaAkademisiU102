using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Transform engines;
    [SerializeField] private float upThrust;
    [SerializeField] private float strafeThrust;
    [SerializeField] private float frontThrust;
    [SerializeField] private UnityEvent OnExitShipEvent;
    private bool exitShip;
    
    private float upDown;
    private float strafe;
    private float frontBack;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (exitShip)
        {
            OnExitShipEvent.Invoke();
            StartCoroutine(DelayCameraTransition());
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        // Up/Down

        if (upDown > 0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown * upThrust * Time.fixedDeltaTime);
          
            engines.transform.DOLocalRotate(new Vector3(180, engines.transform.localRotation.y, engines.transform.localRotation.z), 1f);

        }

        if(upDown < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown * upThrust * Time.fixedDeltaTime);

            engines.transform.DOLocalRotate(new Vector3(360, engines.transform.localRotation.y, engines.transform.localRotation.z), 1f);
        }

        if (upDown == 0)
        {
            engines.transform.DOLocalRotate(new Vector3(-90, engines.transform.localRotation.y, engines.transform.localRotation.z), 1f);
        }

        // Strafe


        if (strafe > 0.1f)
        {
            transform.Rotate(Vector3.up * strafe * strafeThrust * Time.fixedDeltaTime);

            
        }

        if (strafe < -0.1f)
        {
            transform.Rotate(Vector3.up * strafe * strafeThrust * Time.fixedDeltaTime);

            
        }

        // Front/Back

        if (frontBack > 0.1f)
        {
            rb.AddRelativeForce(Vector3.forward * frontBack * frontThrust * Time.fixedDeltaTime);
        }

        if (frontBack < -0.1f)
        {
            rb.AddRelativeForce(Vector3.forward * frontBack * frontThrust * Time.fixedDeltaTime);
        }




    }

    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown = context.ReadValue<float>();
    }

    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafe = context.ReadValue<float>();
    }

    public void OnFrontBack(InputAction.CallbackContext context)
    {
        frontBack = context.ReadValue<float>();
    }

    public void OnExitShip(InputAction.CallbackContext context)
    {
        exitShip = context.ReadValue<float>() == 1;
    }

   
    IEnumerator DelayCameraTransition()
    {
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<Cinemachine.CinemachineBrain>().m_DefaultBlend.m_Time = 0.1f;
    }

}
