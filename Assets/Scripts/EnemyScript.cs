using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float health = 50f;
    public float viewDistance = 30f;
    public float attackDistance = 5f;

    public GameObject enemyDestination;
    NavMeshAgent theAgent;

    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Move();
    }

    public void TakeDamage(float ammout){
        health -= ammout;
        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void Move()
    {
        float distanceToPlayer = (enemyDestination.transform.position - transform.position).magnitude;
        if (distanceToPlayer <= 20)
        {
            if (distanceToPlayer >= 10) theAgent.SetDestination(transform.position);
            //TODO: attack logic
            transform.LookAt(enemyDestination.transform.position);
        }
                    
        if (distanceToPlayer <= 30 && distanceToPlayer > 20)
        {
            theAgent.SetDestination(enemyDestination.transform.position);
        }

        if (distanceToPlayer > 30)
        {
            return;
        }





        //theAgent.SetDestination(enemyDestination.transform.position);

        /*
        float distanceToDestination = Mathf.Abs((enemyDestination.transform.position - transform.position).magnitude);
        if (distanceToDestination <= viewDistance && distanceToDestination >= attackDistance)
        {
            theAgent.SetDestination(enemyDestination.transform.position);
        }
        if (distanceToDestination <= viewDistance && distanceToDestination <= attackDistance)
        {
            theAgent.SetDestination(transform.position);    //Stays on current position
            //TODO: attack logic
        }
        else
        {
            theAgent.SetDestination(transform.position);
        }
        */
    }



}
