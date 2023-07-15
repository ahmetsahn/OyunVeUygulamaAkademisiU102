using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OlumPanel : MonoBehaviour
{
    private void Start()
    {
        var image = GetComponent<Image>();
        image.DOFade(0, 0.5f).From();
    }
}
