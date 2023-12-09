using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour, IReactToDamage
{
    static public float health = 200;
    HealthComp mainHealth;
    void Awake()
    {
        Time.timeScale = 1;
        mainHealth = GetComponent<HealthComp>();
        mainHealth.health = health;
        Application.targetFrameRate = 60;
    }
    public void isHit()
    {       
        health = mainHealth.health;
    }

    public void isDead() {
        Invoke("loadGameOver",1f);
    }
    void loadGameOver()
    {
        Menu.loadGameOver();
    }
}
