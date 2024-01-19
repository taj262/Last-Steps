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
    public bool isBoss = false;
    NavMeshAgent agent;
    public LayerMask player;
    public float raycastDist = 20f;
    public float waitSeconds = 7f;
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

        Instantiate(bullet,eye.position , eye.rotation);
            
        waitSeconds = Random.Range(3f,8f);
    
        Invoke("wispAttack",waitSeconds);

    }
    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        if(isBoss)
        {
            LevelState.BossEvent = false;
            LevelState.Spawning =false;
        }
        else
        {
            SpawnerController.NUM_OF_ENEMIES--;
        }
        Destroy(gameObject);
    }
}
