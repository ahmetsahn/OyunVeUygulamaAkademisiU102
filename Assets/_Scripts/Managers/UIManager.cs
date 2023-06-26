using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletCountText;
    [SerializeField] private IntReference currentAmmo;

    [SerializeField] private TextMeshProUGUI diamondCountText;
    [SerializeField] private IntReference currentDiamond;

    private void Start()
    {
        currentAmmo.Value = 0;
        currentDiamond.Value = 0;
    }

    private void Update()
    {
        bulletCountText.text = currentAmmo.Value.ToString() + " / 3";
        diamondCountText.text = currentDiamond.Value.ToString();
    }

}
