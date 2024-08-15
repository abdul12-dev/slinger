using UnityEngine;

public class Tower: MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab to instantiate
    [SerializeField] private float fireRate = 1.0f; // How often to fire (in seconds)
    [SerializeField] private float shootingAngleRange = 30.0f; // Range of angles (degrees) from the tower's forward direction
    [SerializeField] private float projectileSpeed = 10.0f; // Speed of the projectile

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireProjectile()
{
    Debug.Log("Firing Projectile"); // Add this line for debugging

    // Calculate a random angle within the shooting range
    float randomAngle = Random.Range(-shootingAngleRange / 2f, shootingAngleRange / 2f);
    Quaternion rotation = Quaternion.Euler(0f, 0f, randomAngle);
    
    // Instantiate the projectile
    GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);
    
    // Add force to the projectile to make it move
    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.velocity = rotation * Vector2.right * projectileSpeed;
    }
}

}
