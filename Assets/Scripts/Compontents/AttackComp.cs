using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class AttackComp: MonoBehaviour // Has the ability to attack
{
    public float damage;
    private void OnTriggerEnter(Collider collision)
    {;
        attackObject(collision.gameObject);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        attackObject(collision.gameObject);
        
    }
    public void attackObject(GameObject other)
    {
        IHealthInteraction player = other.GetComponent<IHealthInteraction>();
        if(player != null )
        {
            player.TakeDamage(damage);
        }
    }

}
