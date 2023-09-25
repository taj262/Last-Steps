using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When bullet is instantiated, travel forward very fast. If you hit somthing damageable, damage it.
/// </summary>
public class Bullet : MonoBehaviour
{
    int speed = 1000;
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
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb.AddForce(rb.transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit somthing");
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(1);
        }
        rb.isKinematic = true;
        Destroy(gameObject, trailRenderer.time);
    }

}
