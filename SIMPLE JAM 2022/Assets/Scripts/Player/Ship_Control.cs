using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Control : MonoBehaviour
{   
    private Rigidbody rb;
    private bool clicked = false;

    [SerializeField]
    private float maxSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            clicked = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity =Vector3.ClampMagnitude(rb.velocity,maxSpeed);
            
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Rotate(2,0,0);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-2,0,0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-2,0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,2,0);
        }
    }

    void FixedUpdate()
    {
        if(clicked)
        {
            GoForward();
        }
    }

    private void GoForward()
    {
        rb.AddForce(transform.forward * 10);
    }
}
