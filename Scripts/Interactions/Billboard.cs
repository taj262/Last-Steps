using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("CameraHolder");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Camera.transform);
    }

}
