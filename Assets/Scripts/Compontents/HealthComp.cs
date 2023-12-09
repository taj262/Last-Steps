using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComp:MonoBehaviour, IHealthInteraction  // Anything that can take dammage
{
    public float health;
    public float MaxHealth;
    IReactToDamage entity ;

    private void Awake()
    {
        health = MaxHealth;
        entity = GetComponent<IReactToDamage>();
    }

    public void SetHealth(float damage)
    {
        health-=damage;
    }

    public bool checkIfDead() 
    {
        return health <= 0;
    }

    public float CurrentHealthPercent() {
        return health / MaxHealth;
    }
    public void TakeDamage(float damage) {
        SetHealth(damage);
        entity.isHit();
        if(checkIfDead())
        {
            entity.isDead();
        }
    }

}
