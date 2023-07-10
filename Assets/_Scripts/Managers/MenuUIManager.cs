using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    // Settings Menu
    [SerializeField] private AudioMixer audioMixer;

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Cikis()
    {
        Application.Quit();
    }
}
