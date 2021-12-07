using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public float impactForce = 30f;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            EnemyScript enemyScript = hit.transform.GetComponent<EnemyScript>();
            if (enemyScript != null){
                enemyScript.TakeDamage(damage);
                hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce);
            }
        }

        GameObject currentBullet = Instantiate(bullet, gameObject.transform.position, transform.rotation, transform);
        Destroy(currentBullet,0.1f);
    }


}
