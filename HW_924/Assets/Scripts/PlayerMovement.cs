using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb; //rigidbody variable
    public float moveSpeed = 1; //move variable
    public float jumpSpeed; //jump variable

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //grab rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //get Horizontal input
        float v = Input.GetAxis("Vertical"); //get Vertical input

        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed); //input times speed

        Ray r = new Ray(transform.position, Vector3.down); //create downwards ray

        Debug.DrawLine(r.origin, r.origin + (Vector3.down * 1)); //draw line

        RaycastHit hit; //hit variable

        if(Physics.Raycast(r, out hit, 1))
        {
            if(Input.GetButtonDown("Jump") && hit.transform.name == "Ground") //if jump input is pressed and rigidbody is hitting ground
            {
                Jump(); //call jump method
            }
        }
    }

    void Jump() //Jump method
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z); //jump velocity
    }
}
