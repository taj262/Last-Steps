using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour, IReactToDamage
{   
    Material mat;
    HealthComp currentHealth;
    Transform childObject;
    Transform eye;
    Transform otherEye;
    Transform mainEye;
    public LayerMask player;
    public float raycastDist = 40f;
    public float waitSeconds = 2.5f;
    public GameObject bullet;
    private void Start()
    {
        eye = transform.Find("eye");
        otherEye = transform.Find("otherEye");
        mainEye = transform.Find("mainEye");
        childObject = transform.Find("Head");
        if( childObject != null )
        {
            mat = childObject.GetComponent<MeshRenderer>().materials[0];

        }
        currentHealth = GetComponent<HealthComp>();
        Invoke("attackPlayer",waitSeconds);
    }

    void attackPlayer()
    {

        finalBossAttack(); 
        Invoke("attackPlayer",waitSeconds);
    }
    void finalBossAttack()
    {

            Instantiate(bullet,eye.position , eye.rotation);
            //this is for final boss
            if(otherEye != null && mainEye != null )
            {
                Instantiate(bullet,otherEye.position , otherEye.rotation);
                Instantiate(bullet,mainEye.position , mainEye.rotation);

            }
            
    }

    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        LevelState.BossEvent = false;
        LevelState.Spawning =false;
        Destroy(gameObject);
    }

}
