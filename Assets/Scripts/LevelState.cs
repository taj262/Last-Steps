using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public bool BossEvent = false;
    public float BossTime = 0f;
    public float BossTimeEnd = 10f;
    public bool Spawning = true;
    public float LevelSpawnRate = 1f;
    public float SpawnIncreaseRate = 0.005f;



    void Start()
    {
        if (BossEvent)
        {
            Debug.Log("Boss Event has started");
        }
        
    }

    void Update()
    {

        // Boss Event is over
        if (BossTime >= BossTimeEnd)
        {
            // end the boss event
            BossEvent = false;
            // Turn spawning off
            Spawning = false;
        }


        // Boss Event is happening
        if (BossEvent)
        {
            // Boss event start
            if (BossTime == 0)
            {
                // up the spawn rate
                LevelSpawnRate *= 2f;
            }
            // start boss timer
            BossTime += Time.deltaTime;

        }


        // normal level 

        // as the level begins there are few zombies but as time continues, difficulty increases
        
        Debug.Log(Time.deltaTime);
        
        LevelSpawnRate += (SpawnIncreaseRate * Time.deltaTime);
        
        



    }
}
