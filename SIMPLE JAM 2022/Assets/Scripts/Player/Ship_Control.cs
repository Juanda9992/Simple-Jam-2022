using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Control : MonoBehaviour
{   
    private Rigidbody rb;
    private bool clicked = false;

    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    Vector3 nextRotation;
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
        RotateShip();

        

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

    private void RotateShip()
    {
        if(Input.GetKey(KeyCode.W))
        {
            nextRotation.x += 2;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            nextRotation.x -= 2;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            nextRotation.y -= 2;
            nextRotation.z = -45;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            nextRotation.y += 2;
            nextRotation.z = 45;
        }

        transform.rotation = Quaternion.Euler(nextRotation);

    }
}
