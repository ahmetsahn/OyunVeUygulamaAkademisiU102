using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Events;

public class AlienFarm : MonoBehaviour
{

    [SerializeField] private IntReference currentDiamond;
    [SerializeField] private UnityEvent UpdateUI;
    private Alien alien;

    private void Awake()
    {
        alien = GetComponent<Alien>();
    }

    public void IncreaseHitOnRockCounter()
    {
        if (alien.isMine)
        {
            currentDiamond.Value++;
            UpdateUI.Invoke();
        }
            
    }
}
