using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ReturnToPoolDelay());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyBulletPool.Instance.ReturnToPool(this);
        }
    }

    IEnumerator ReturnToPoolDelay()
    {
        yield return new WaitForSeconds(2f);
        EnemyBulletPool.Instance.ReturnToPool(this);
    }
}
