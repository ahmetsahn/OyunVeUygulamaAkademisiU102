using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void Start()
    {
        StartCoroutine(ReturnToPoolDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }

        EnemyBulletPool.Instance.ReturnToPool(this);
    }

    IEnumerator ReturnToPoolDelay()
    {
        yield return new WaitForSeconds(2f);
        EnemyBulletPool.Instance.ReturnToPool(this);
    }
}
