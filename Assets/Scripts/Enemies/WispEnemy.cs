using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispEnemy : MonoBehaviour, IReactToDamage
{   
    Material mat;
    HealthComp currentHealth;
    Transform childObject;
    private void Start()
    {
        childObject = transform.Find("Head");
        if( childObject != null )
        {
            mat = childObject.GetComponent<MeshRenderer>().materials[0];

        }
        currentHealth = GetComponent<HealthComp>();
    }
    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        Destroy(gameObject);
    }
}
