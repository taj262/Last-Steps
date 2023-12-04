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
        Debug.Log("CAPACITY: "+ SpawnerController.CAPACITY + "Num of Enmies: "+ SpawnerController.NUM_OF_ENEMIES);
        SpawnerController.CAPACITY +=20f % 100f;
        Invoke("raiseDiffculty",60f);
    }
}
