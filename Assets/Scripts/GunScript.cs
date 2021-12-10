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
    public Vector3 bulletPosition;
    public Vector3 bulletRotation;

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
                print("YAHHHHHHH");
                enemyScript.TakeDamage(damage);
                hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * impactForce);
            }
        }

        Quaternion rotation = Quaternion.Euler(-30f, 0f, 94.5f);

        GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation, transform);
        currentBullet.transform.localRotation = rotation;
        currentBullet.transform.localPosition = new Vector3(-0.0738f, 0.0406f, 0.0017f);
        currentBullet.transform.localScale = new Vector3(0.01f, 2f, 0.01f);
        Destroy(currentBullet,0.1f);
    }


}
