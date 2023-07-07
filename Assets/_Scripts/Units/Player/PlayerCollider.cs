using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerEnterShipArea;
    [SerializeField] private UnityEvent OnTriggerStayShipAreaPressF;
    [SerializeField] private UnityEvent OnTriggerExitShipArea;
    private StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = GetComponent<StarterAssetsInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShipTriggerZone"))
        {
            OnTriggerEnterShipArea.Invoke();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ShipTriggerZone"))
        {
            if (inputs.enterShip)
            {
                Camera.main.GetComponent<Cinemachine.CinemachineBrain>().m_DefaultBlend.m_Time = 2;
                OnTriggerStayShipAreaPressF.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShipTriggerZone"))
        {
            OnTriggerExitShipArea.Invoke();
        }
    }

}
