using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] float raycastLenght;
    [SerializeField] float jumpSpeed;
    private Vector3 moveDirection;
    public float playerSpeed;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }


    void Move(){

        // We get platform-independet user input
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Then we update the player's position
        transform.position += moveDirection * Time.deltaTime * playerSpeed; //Updates position, Time.deltaTime is time between frames
    
        if (Input.GetAxis("Mouse X") > 0){

        }
    
    }

    bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, raycastLenght + 0.1f);
    }

    void Jump(){
        if (IsGrounded() && Input.GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
        }
    }
}
