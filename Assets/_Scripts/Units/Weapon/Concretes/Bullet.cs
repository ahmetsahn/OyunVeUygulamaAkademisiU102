using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float damage;
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

        if (other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damage);
        }

        BulletPool.Instance.ReturnToPool(this);
    }

    private void GetHitEffect()
    {
        var hitEffect = HitEffectPool.Instance.Get();
        hitEffect.transform.position = transform.position;
        hitEffect.gameObject.SetActive(true);
    }

}
