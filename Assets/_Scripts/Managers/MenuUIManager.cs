using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public void YeniOyun()
    {
        SceneManager.LoadScene("GameScene");
    }
}
