using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IReactToDamage
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHit();
        } 
    }
    public void isHit() {
        Destroy(gameObject);
    }
    public void isDead() {
        Destroy(gameObject);
    }
}
