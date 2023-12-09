using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.isPaused = true;
        Invoke("disableStart",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void disableStart()
    {
        gameObject.SetActive(false);
        UIManager.isPaused = false;


    }
}
