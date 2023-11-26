using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDampFollow : MonoBehaviour
{
    [Tooltip("What to follow and look at")]
    public Transform target;

    [Tooltip("Smoothness of dampening")]
    public float smoothTime = 0.3f;

    [Tooltip("Constant position away from the target")]
    public Vector3 offset;

    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {   
        // start our camera at the target offset
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        // if our target exists
        if (target != null)
        {
            // calculate out wanted offset position
            Vector3 offsetPosition = target.position + offset;

            // set our position to the offset position smoothly
            transform.position = Vector3.SmoothDamp(transform.position, offsetPosition, ref velocity, smoothTime);

            // always be looking at the player
            transform.LookAt(target, Vector3.up);

        }
    }
}
