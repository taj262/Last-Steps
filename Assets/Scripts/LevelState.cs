using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    public static bool BossEvent = false;
    public float BossTime = 0f;
    public float BossTimeEnd = 90f;
    public  static bool Spawning = true;
    public static float LevelSpawnRate = 1f;
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
        
        
        LevelSpawnRate += (SpawnIncreaseRate * Time.deltaTime);
        
        



    }
}
