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
        health = MaxHealth;
        entity = GetComponent<IReactToDamage>();
    }

    public void SetHealth(int damage)
    {
        health-=damage;
    }

    public bool checkIfDead() 
    {
        return health <= 0;
    }

    public float CurrentHealthPercent() {
        return (float)health / (float)MaxHealth;
    }
    public void TakeDamage(int damage) {
        SetHealth(damage);
        entity.isHit();
        if(checkIfDead())
        {
            entity.isDead();
        }
    }

}
