using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("raiseDiffculty",60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void raiseDiffculty()
    {
        SpawnerController.CAPACITY += 20f;
        Invoke("raiseDiffculty",60f);
    }
}
