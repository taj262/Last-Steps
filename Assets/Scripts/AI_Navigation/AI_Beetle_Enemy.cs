using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI_Beetle_Enemy : MonoBehaviour
{

    public Transform Player;
    NavMeshAgent agent;
    public float maxDist = 10f;
    RaycastHit hit;
    public LayerMask player,ground;
    bool inRange;
    Vector3 setPoint;
    Vector3 walkPoint,tempPoint;
    bool walkPointSet,isAwayFromTarget,isGrounded;
    public float walkPointRange = 5f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        walkPoint = transform.position;
        walkPointSet = false;
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position,Player.position);
        if(LevelState.BossEvent || distance > maxDist *3) 
        {
            agent.destination = Player.position;
            return;
        }
        inRange = Physics.CheckSphere(agent.transform.position,maxDist,player);
        Patroling();
 
        setPoint = Player.position;
        bool patrol = !inRange && walkPointSet;
        if(inRange) agent.destination = setPoint;
        if(patrol) agent.destination = walkPoint;
        
        transform.LookAt(agent.destination);
        
    }
    private void Patroling()
    {
        if(!walkPointSet) walkPoint = SearchWalkPoint();

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        isAwayFromTarget = distanceToWalkPoint.magnitude - agent.stoppingDistance > 1f ;
        walkPointSet = isAwayFromTarget && isGrounded;
    }
    private Vector3 SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float newXpos = transform.position.x -  randomX ;
        float newZpos =  transform.position.z - randomZ;

        tempPoint = new Vector3(newXpos, transform.position.y,newZpos);
        isGrounded = Physics.Raycast(tempPoint, -transform.up, 2f, ground);
        if(!isGrounded) 
        {   
            tempPoint = Player.position;
        }
        return tempPoint;
    }

}
