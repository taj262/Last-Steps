using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When bullet is instantiated, travel forward very fast. If you hit somthing damageable, damage it.
/// </summary>
public class Bullet : MonoBehaviour
{
    public int BulletVelocity = 1000;
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

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit somthing");
        BulletMesh.enabled = false;
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1);
        }
        rb.isKinematic = true;

        // Create the hit effect at the collision point
        if (hitEffectPrefab != null)
        {
            ContactPoint contact = collision.contacts[0]; // Get the first contact point
            Quaternion rotation = Quaternion.LookRotation(contact.normal); // Orient the particle system based on the normal
            Vector3 spawnPosition = contact.point + contact.normal * 0.01f;
            GameObject hitEffect = Instantiate(hitEffectPrefab, spawnPosition, rotation);

            // You may want to destroy the hitEffect after its particle system finishes playing
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
