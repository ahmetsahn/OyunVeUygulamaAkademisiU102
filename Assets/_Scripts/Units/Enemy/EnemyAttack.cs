using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target; // Hedef nesne (sizin karakteriniz)
    public float shootingInterval = 1f; // Ate� aral���
    public float bulletSpeed = 50f; // Mermi h�z�
    public Transform spawnPoint; // Mermi prefab�
    [SerializeField][Range(0, 20f)] private float randomAngleRange;
    private float nextShotTime;

    
    public void Attack()
    {
        if (target != null && CanShoot())
        {
            Shoot();
            nextShotTime = Time.time + shootingInterval;
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextShotTime;
    }

    private void Shoot()
    {
        GetBullet();
    }
        

    private void GetBullet()
    {
        Vector3 targetDirection = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        float randomAngle = Random.Range(-randomAngleRange, randomAngleRange);
        Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f) * rotation;
        
        var bullet = EnemyBulletPool.Instance.Get();
        bullet.transform.SetPositionAndRotation(spawnPoint.transform.position, randomRotation);
        bullet.gameObject.SetActive(true);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = randomRotation * Vector3.forward * bulletSpeed;
    }

}
