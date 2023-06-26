using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletCountText;
    [SerializeField] private IntReference currentAmmo;

    private void Update()
    {
        bulletCountText.text = currentAmmo.Value.ToString() + " / 3";
    }

}
