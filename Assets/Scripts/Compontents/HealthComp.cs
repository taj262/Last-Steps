using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComp:MonoBehaviour, IHealthInteraction  // Anything that can take dammage
{
    public int health;
    public int MaxHealth;
    IReactToDamage entity ;

    private void Awake()
    {
        entity = GetComponent<IReactToDamage>();
    }

    public void setHeatlh(int damage)
    {
        health-=damage;
    }

    public bool checkIfDead() 
    {
        return health <= 0;
    }

    public float currentHealthPercent() {
        return (float)health / (float)MaxHealth;
    }
    public void initHealth(int healthPoints) {
        health = healthPoints;
        MaxHealth = healthPoints;
    }
    public void TakeDamage(int damage) {
        Debug.Log(health);
        setHeatlh(damage);
        entity.isHit();
        if(checkIfDead())
        {
            entity.isDead();
        }
    }

}
