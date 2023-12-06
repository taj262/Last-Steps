using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<Spawner> spawners;
    static public float NUM_OF_ENEMIES = 0;
    public float capactiy = 20f;
    static public float CAPACITY = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        NUM_OF_ENEMIES = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(CAPACITY > NUM_OF_ENEMIES && LevelState.Spawning)
        {
            Spawner tSpawner;
            int chanceSpawn = Random.Range(0,spawners.Count);
            tSpawner = spawners[chanceSpawn];
            tSpawner.delaySpawn();
            NUM_OF_ENEMIES++;

        }
    }
}

