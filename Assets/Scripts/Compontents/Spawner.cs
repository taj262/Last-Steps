using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float seconds = 10f;
    public List<GameObject> enemies;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void delaySpawn()
    {
        float randInterval = Random.Range(3,seconds);
        if(startUI.isLoading) randInterval = 3f;
        Invoke("spawnEnemy",randInterval);
    }
    public void spawnEnemy()
    {
            GameObject tEnemy;
            int randEnemies = Random.Range(0,enemies.Count);
            tEnemy = enemies[randEnemies];
            AI_Beetle_Enemy tAI = tEnemy.GetComponent<AI_Beetle_Enemy>();
            tAI.Player = player;
            Instantiate(tEnemy);
            tEnemy.transform.position = transform.position;
    }
}
