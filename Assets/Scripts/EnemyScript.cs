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
        Shoot();
    }

    public void TakeDamage(float ammout){
        health -= ammout;
        //print("Enemy has " + health + " points");
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
    }

    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15f)){
            //Debug.Log(hit.transform.name);

            /*
            EnemyScript enemyScript = hit.transform.GetComponent<EnemyScript>();
            if (enemyScript != null){
                enemyScript.TakeDamage(damage);
                hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce);
            }
            */
        }
    }


}
