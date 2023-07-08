using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject hazirlayanlarPanel;

    public void YeniOyun()
    {
        SceneManager.LoadScene("Game");
    }

    public void Haz�rlayanlar()
    {
        hazirlayanlarPanel.SetActive(true);    
    }
}
