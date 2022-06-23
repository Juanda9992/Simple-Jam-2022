using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ship_Control : MonoBehaviour
{   
    public delegate void onPackageDelivered();
    public static onPackageDelivered onDelivered;
    private Rigidbody rb;
    private bool clicked = false;

    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float xSensitivity,ySensitivity;

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
            nextRotation.x += xSensitivity;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            nextRotation.x -= xSensitivity;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            nextRotation.y -= xSensitivity;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            nextRotation.y += xSensitivity;
        }
        nextRotation.x = Mathf.Clamp(nextRotation.x,-60,60);
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(nextRotation),5);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Package"))
        {
            onDelivered?.Invoke();
        }
    }
}
