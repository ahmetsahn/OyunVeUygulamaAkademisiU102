using ScriptableObjectArchitecture;
using UnityEngine;

public class AlienFarm : MonoBehaviour
{

    [SerializeField] private IntReference currentDiamond;
    private Alien alien;

    private void Awake()
    {
        alien = GetComponent<Alien>();
    }

    public void IncreaseHitOnRockCounter()
    {
        if (alien.isMine)
            currentDiamond.Value++;
    }
}
