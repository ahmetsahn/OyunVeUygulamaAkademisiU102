using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float upThrust;
    private float upDown;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (upDown > 0.1f || upDown < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown * upThrust * Time.fixedDeltaTime);
        }

        else
        {
            rb.AddRelativeForce(Vector3.up * upDown * upThrust * Time.fixedDeltaTime);
        }
    }
    
    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown = context.ReadValue<float>();
    } 
}
