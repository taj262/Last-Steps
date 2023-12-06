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

    void Awake()
    {
        BossEvent = false;
        Spawning = true;
    }
    void Start()
    {

        
    }

    void FixedUpdate()
    {





        if (BossEvent)
        {

        }



        

        
    }

}
