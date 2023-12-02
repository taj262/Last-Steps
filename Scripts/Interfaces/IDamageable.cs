using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable // Anything that can take dammage
{
    int health { get; set; }
    public void TakeDamage(int damage);

}
