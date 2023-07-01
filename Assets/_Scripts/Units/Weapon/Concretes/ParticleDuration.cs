using UnityEngine;

public class ParticleDuration : MonoBehaviour
{
    private ParticleSystem particleSys;

    private void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
    }

    public void ParticleActiveControl()
    {
        gameObject.SetActive(false);
    }
}
