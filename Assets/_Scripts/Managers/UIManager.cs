using DG.Tweening;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private Text collectorBulletCountText;
    [SerializeField] private IntReference currentCollectorBulletCount;

    [SerializeField] private Text riffleBulletCountText;
    [SerializeField] private IntReference currentRiffleBulletCount;
    [SerializeField] private IntReference magazineBulletCapacity;
    [SerializeField] private IntReference totalRiffleBulletCount;
    [SerializeField] private IntReference totalRiffleBulletCapacity;

    [SerializeField] private Text diamondCountText;
    [SerializeField] private IntReference currentDiamond;

    [SerializeField] private Image healthBar;
    [SerializeField] private FloatReference currentHealth;
    [SerializeField] private FloatReference maxHealth;

    [SerializeField] private BoolReference isOpenMarket;
    [SerializeField] private BoolReference isCloseMarket;
    [SerializeField] private BoolReference riffleIsHave;
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private IntReference rifflePrice;
    [SerializeField] private AudioClip buySound;
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentCollectorBulletCount.Value = 0;
        currentRiffleBulletCount.Value = magazineBulletCapacity.Value;
        totalRiffleBulletCount.Value = totalRiffleBulletCapacity.Value;
        currentDiamond.Value = 0;
        isOpenMarket.Value = false;
        isCloseMarket.Value = false;
        riffleIsHave.Value = false;
    }


    public void BuyRiffle()
    {
        if(currentDiamond.Value >= rifflePrice.Value)
        {
            riffleIsHave.Value = true;
            currentDiamond.Value -= rifflePrice.Value;
            audioSource.PlayOneShot(buySound);
            DOTween.To(() => currentDiamond.Value, x => currentDiamond.Value = x, currentDiamond.Value, 0.5f);
        }
       
    }

    public void UpdateCollectorBulletCountText()
    {
        collectorBulletCountText.text = currentCollectorBulletCount.Value.ToString() + " / 3";
    }

    public void UpdateRiffleBulletCountText()
    {
        riffleBulletCountText.text = currentRiffleBulletCount.Value.ToString() + " / " + totalRiffleBulletCount.Value.ToString();
    }

    public void UpdateDiamondCountText()
    {
        diamondCountText.text = currentDiamond.Value.ToString();
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth.Value / maxHealth.Value;
    }

    public void OpenMarketPanel()
    {
        marketPanel.SetActive(true);
        marketPanel.transform.DOScale(0.6f, 1f).SetEase(Ease.OutBack).onComplete += () => Time.timeScale = 0;
        isOpenMarket.Value = false;
    }

    public void CloseMarketPanel()
    {
        Time.timeScale = 1;
        marketPanel.transform.DOScale(0f, 1f).SetEase(Ease.InBack).onComplete += () =>
        {

            marketPanel.SetActive(false);

        };
        isCloseMarket.Value = false;
    }

}
