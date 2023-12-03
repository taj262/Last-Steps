using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour, IReactToDamage
{
    static public int health = 100;
    HealthComp mainHealth;
    void Awake()
    {
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
