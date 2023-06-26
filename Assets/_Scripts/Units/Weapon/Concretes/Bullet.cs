using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    
    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        GetHitEffect();
        
        BulletPool.Instance.ReturnToPool(this);
    }

    private void GetHitEffect()
    {
        var hitEffect = HitEffectPool.Instance.Get();
        hitEffect.transform.position = transform.position;
        hitEffect.gameObject.SetActive(true);
    }

}
