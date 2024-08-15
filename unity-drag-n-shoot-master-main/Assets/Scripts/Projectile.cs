using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab; // The hit effect prefab

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate hit effect on collision
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destroy the projectile after collision
        Destroy(gameObject);
    }
}
