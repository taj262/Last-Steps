using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable // Anything that can take dammage
{
    int health { get; set; }
    //this is the old version
    public void TakeDamage(int damage);

}
