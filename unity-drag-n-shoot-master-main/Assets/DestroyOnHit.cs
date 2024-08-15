using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;  // Sound effect to play on collision
    [SerializeField] private GameObject explosionEffect;  // Explosion effect prefab
    private AudioSource audioSource;
    private int hitCount = 0;  // Counter to track number of hits
    public int hitsToDestroy = 10;  // Number of hits required to destroy the object

    void Awake()
    {
        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    void HandleCollision(GameObject hitObject)
    {
        // Debug logs
        Debug.Log("Collision Detected with: " + hitObject.name);

        // Play the sound effect when a collision occurs
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
            Debug.Log("Playing hit sound");
        }
        else
        {
            Debug.LogWarning("AudioSource or HitSound not assigned.");
        }

        // Check if the hit object is a projectile
        if (hitObject.CompareTag("Projectile"))
        {
            hitCount++;
            Debug.Log("Hit Count: " + hitCount);

            // Always instantiate explosion effect on collision
            if (explosionEffect != null)
            {
                GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Debug.Log("Explosion effect instantiated at: " + transform.position);

                // Optionally check if the effect has a ParticleSystem and log its status
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    Debug.Log("ParticleSystem found in explosion effect.");
                }
                else
                {
                    Debug.LogWarning("No ParticleSystem found in explosion effect.");
                }
            }
            else
            {
                Debug.LogWarning("Explosion Effect prefab not assigned.");
            }

            if (hitCount >= hitsToDestroy)
            {
                Destroy(gameObject);  // Destroy the tower after the required number of hits
            }
            Destroy(hitObject);  // Destroy the projectile
        }

        // Destroy projectile when it hits the ground
        if (hitObject.CompareTag("Ground"))
        {
            Destroy(hitObject);  // Destroy the ground or whatever the projectile hits
        }
    }
}
