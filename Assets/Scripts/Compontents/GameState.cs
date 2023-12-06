using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("raiseDiffculty",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void raiseDiffculty()
    {
        SpawnerController.CAPACITY +=1f % 100f;
        Invoke("raiseDiffculty",3f);
    }
}
