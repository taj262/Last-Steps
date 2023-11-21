using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.AI;

public class FinalBoss : MonoBehaviour, IReactToDamage
{   
    Material mat;
    HealthComp currentHealth;
    Transform childObject;
    Transform eye;
    Transform otherEye;
    Transform mainEye;
    public GameObject bombPrefab ; 
    NavMeshAgent agent;
    public LayerMask player;
    public float raycastDist = 40f;
    public float waitSeconds = 2.5f;
    public GameObject bullet;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        eye = transform.Find("eye");
        otherEye = transform.Find("otherEye");
        mainEye = transform.Find("mainEye");
        childObject = transform.Find("Head");
        if( childObject != null )
        {
            mat = childObject.GetComponent<MeshRenderer>().materials[0];

        }
        currentHealth = GetComponent<HealthComp>();
        Invoke("finalBossAttack",waitSeconds);
    }

    void finalBossAttack()
    {
        if(didPlayerGetAttacked())
        {
            Debug.Log("fired project");
            Instantiate(bullet,eye.position , eye.rotation);
            //this is for final boss
            if(otherEye != null && mainEye != null )
            {
                Instantiate(bullet,otherEye.position , otherEye.rotation);
                Instantiate(bullet,mainEye.position , mainEye.rotation);

            }
            if(bombPrefab != null )
            {
                Instantiate(bombPrefab,transform.position , transform.rotation);
            } 
            

        }
        Invoke("finalBossAttack",waitSeconds);

    }
    bool didPlayerGetAttacked()
    {

        return Physics.Raycast(transform.position,transform.forward,raycastDist,player);
    }
    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        Destroy(gameObject);
    }
}
