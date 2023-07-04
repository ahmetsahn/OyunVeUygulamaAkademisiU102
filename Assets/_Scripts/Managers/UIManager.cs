using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectorBulletCountText;
    [SerializeField] private IntReference currentCollectorBulletCount;

    [SerializeField] private TextMeshProUGUI riffleBulletCountText;
    [SerializeField] private IntReference currentRiffleBulletCount;
    [SerializeField] private IntReference magazineBulletCapacity;
    [SerializeField] private IntReference totalRiffleBulletCount;
    [SerializeField] private IntReference totalRiffleBulletCapacity;

    [SerializeField] private TextMeshProUGUI diamondCountText;
    [SerializeField] private IntReference currentDiamond;

    [SerializeField] private Image healthBar;
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;

    private void Start()
    {
        currentCollectorBulletCount.Value = 0;
        currentRiffleBulletCount.Value = magazineBulletCapacity.Value;
        totalRiffleBulletCount.Value = totalRiffleBulletCapacity.Value;
        currentDiamond.Value = 0;
    }

    private void Update()
    {
        collectorBulletCountText.text = currentCollectorBulletCount.Value.ToString() + " / 3";
        riffleBulletCountText.text = currentRiffleBulletCount.Value.ToString() + " / " + totalRiffleBulletCount.Value.ToString();
        diamondCountText.text = currentDiamond.Value.ToString();
        healthBar.fillAmount = currentHealth.Value / maxHealth.Value;
    }

}
