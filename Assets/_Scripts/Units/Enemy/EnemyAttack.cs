using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target; // Hedef nesne (sizin karakteriniz)
    public float shootingRange = 10f; // Ateþ menzili
    public float shootingInterval = 1f; // Ateþ aralýðý
    public float bulletSpeed = 50f; // Mermi hýzý
    public GameObject bulletPrefab; // Mermi prefabý
    public Transform spawnPoint; // Mermi prefabý

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
        float distance = Vector3.Distance(transform.position, target.position);
        return distance <= shootingRange && Time.time >= nextShotTime;
    }

    private void Shoot()
    {
        Vector3 targetDirection = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        float randomAngle = Random.Range(-30f, 30f);
        Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f) * rotation;

        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, randomRotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = randomRotation * Vector3.forward * bulletSpeed;
    }
}
