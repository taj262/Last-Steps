using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemy : MonoBehaviour, IReactToDamage
{   
    Material mat;
    HealthComp currentHealth;
    private void Start()
    {
        currentHealth = GetComponent<HealthComp>();
        mat = GetComponent<MeshRenderer>().materials[0];
    }
    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        Destroy(gameObject);
    }
}
