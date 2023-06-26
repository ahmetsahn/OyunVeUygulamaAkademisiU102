using UnityEngine;

public class AlienSound : MonoBehaviour
{
    [SerializeField] private AudioClip hitOnRockSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayHitOnRockSound()
    {
        audioSource.PlayOneShot(hitOnRockSound);
    }
}
