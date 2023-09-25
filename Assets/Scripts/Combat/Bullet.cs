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
    Rigidbody rb;
    TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // every frame go forward
        if (!rb.isKinematic)
        {
            rb.velocity = (rb.transform.forward * BulletVelocity);
        }
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
        Destroy(gameObject, trailRenderer.time);
    }

}
