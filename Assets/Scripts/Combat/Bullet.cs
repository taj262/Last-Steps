using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When bullet is instantiated, travel forward very fast. If you hit somthing damageable, damage it.
/// </summary>
public class Bullet : MonoBehaviour
{
    public int BulletVelocity = 300;
    public MeshRenderer BulletMesh;
    public GameObject hitEffectPrefab;
    Rigidbody rb;
    TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody>();
        rb.velocity = (rb.transform.forward * BulletVelocity);
        trailRenderer = GetComponent<TrailRenderer>();

        

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if collides with another bullet, if not, proceed
        if (other.GetComponent<Bullet>() == null)
        {
            Debug.Log("Hit: " + other.gameObject.name);
            BulletMesh.enabled = false;
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(1);
            }
            rb.isKinematic = true;

            // Create the hit effect at a position near the collider's bounds
            Vector3 spawnPosition = other.ClosestPointOnBounds(transform.position);

            // Orient the hit effect based on the collision normal (assuming it's a projectile hitting a surface)
            Quaternion rotation = Quaternion.LookRotation(transform.position - spawnPosition);

            // Instantiate the hit effect
            if (hitEffectPrefab != null)
            {
                GameObject hitEffect = Instantiate(hitEffectPrefab, spawnPosition, rotation);

                // Destroy the hit effect after its particle system finishes playing
                ParticleSystem particleSystem = hitEffect.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    Destroy(hitEffect, particleSystem.main.duration);
                }
                else
                {
                    // If the hitEffect doesn't have a particle system, destroy it after a certain time
                    Destroy(hitEffect, 2f); // Adjust the time as needed
                }
            }

            Destroy(gameObject, trailRenderer.time);
        }
    }



}
