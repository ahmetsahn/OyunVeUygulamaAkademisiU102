using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform target; // Hedef nesne (sizin karakteriniz)
    [SerializeField] private float shootingInterval = 1f; // Ateþ aralýðý
    [SerializeField] private float bulletSpeed = 50f; // Mermi hýzý
    [SerializeField] private Transform spawnPoint; // Mermi prefabý
    [SerializeField][Range(0, 20f)] private float randomAngleRange;
    [SerializeField] private AudioClip shootSound;
    private float nextShotTime;
    private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


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
        PlayShootSound();
    }

    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
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
