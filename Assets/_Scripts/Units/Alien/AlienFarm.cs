using ScriptableObjectArchitecture;
using UnityEngine;

public class AlienFarm : MonoBehaviour
{

    [SerializeField] private IntReference currentDiamond;

    public void IncreaseHitOnRockCounter()
    {
        currentDiamond.Value++;
    }
}
