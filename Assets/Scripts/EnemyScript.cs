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
    public GameObject smoke;

    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Shoot", Random.Range(0.5f, 1.5f), 2f);
    }

    void Update()
    {
        Move();
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
            transform.LookAt(enemyDestination.transform.position);
            if (distanceToPlayer <= 10) theAgent.SetDestination(transform.position);
            //Shoot();
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15f))
        {

            PlayerController playerScript = hit.transform.GetComponent<PlayerController>();

            if (playerScript != null){
                playerScript.TakeDamage(10);
                //hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce);
            }
            GameObject currentSmoke = Instantiate(smoke, gameObject.transform.position, transform.rotation, transform);
            Destroy(currentSmoke,0.2f);

        }
    }


}
