using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bulletCountText;
    [SerializeField] private IntReference currentAmmo;

    [SerializeField] private TextMeshProUGUI diamondCountText;
    [SerializeField] private IntReference currentDiamond;

    [SerializeField] private Image healthBar;
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;

    private void Start()
    {
        currentAmmo.Value = 0;
        currentDiamond.Value = 0;
    }

    private void Update()
    {
        bulletCountText.text = currentAmmo.Value.ToString() + " / 3";
        diamondCountText.text = currentDiamond.Value.ToString();
        healthBar.fillAmount = currentHealth.Value / maxHealth.Value;
    }

}
