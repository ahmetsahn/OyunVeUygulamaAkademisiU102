using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float donusHizi = 3f;

    private Rigidbody rb;
    private Vector2 hareketInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 hareket = new Vector3(hareketInput.x, 0f, hareketInput.y) * hareketHizi * Time.deltaTime;
        rb.MovePosition(transform.position + hareket);

        if (hareket != Vector3.zero)
        {
            Quaternion yeniRotasyon = Quaternion.LookRotation(hareket);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, yeniRotasyon, donusHizi * Time.deltaTime));
        }
    }

    public void OnHareketInput(InputAction.CallbackContext context)
    {
        hareketInput = context.ReadValue<Vector2>();
    }

}
