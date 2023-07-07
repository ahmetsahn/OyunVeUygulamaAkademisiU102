using DG.Tweening;
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

    private void Update()
    {
        collectorBulletCountText.text = currentCollectorBulletCount.Value.ToString() + " / 3";
        riffleBulletCountText.text = currentRiffleBulletCount.Value.ToString() + " / " + totalRiffleBulletCount.Value.ToString();
        diamondCountText.text = currentDiamond.Value.ToString();
        healthBar.fillAmount = currentHealth.Value / maxHealth.Value;

        if (isOpenMarket.Value)
        {
            
            marketPanel.SetActive(true);
            marketPanel.transform.DOScale(0.6f, 1f).SetEase(Ease.OutBack).onComplete += () => Time.timeScale = 0;
            isOpenMarket.Value = false;
        }

        if (isCloseMarket.Value)
        {
            Time.timeScale = 1;
            marketPanel.transform.DOScale(0f, 1f).SetEase(Ease.InBack).onComplete += () => 
            {
                
                marketPanel.SetActive(false);
                
            };
            isCloseMarket.Value = false;
        }


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

}
