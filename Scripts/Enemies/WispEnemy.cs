using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WispEnemy : MonoBehaviour, IReactToDamage
{   
    Material mat;
    HealthComp currentHealth;
    Transform childObject;
    Transform eye;
    NavMeshAgent agent;
    public LayerMask player;
    public float raycastDist = 20f;
    public float waitSeconds = 4f;
    public GameObject bullet;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        eye = transform.Find("eye");
        childObject = transform.Find("Head");
        if( childObject != null )
        {
            mat = childObject.GetComponent<MeshRenderer>().materials[0];

        }
        currentHealth = GetComponent<HealthComp>();
        Invoke("wispAttack",waitSeconds);
    }

    void wispAttack()
    {
        if(agent.remainingDistance - agent.stoppingDistance < 0 && didPlayerGetAttacked())
        {
            Debug.Log("fired project");
            Instantiate(bullet,eye.position , eye.rotation);
            

        }
        Invoke("wispAttack",waitSeconds);

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
