using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public KeyCode pickup_dropKey;
    public KeyCode throwKey;
    [Space]
    public Transform holdPos;
    public Transform playerCam;
    public GameObject targetObject;
    public Rigidbody rb;

    [HideInInspector]
    public bool isHolding;

    public float distance;
    public float posLerp = 9f;
    public float throwForce = 800f; //change it to adjust forve based on mouse hold time

    private void Update()
    {
        if (Input.GetKeyDown(pickup_dropKey) && targetObject != null && !isHolding)
        {
            rb = targetObject.GetComponent<Rigidbody>();
            Destroy(rb);
            targetObject.GetComponent<BoxCollider>().enabled = false;
            isHolding = true;
        }
        else if(Input.GetKeyDown(pickup_dropKey) && isHolding) 
        {
            rb = targetObject.AddComponent<Rigidbody>();
            rb.mass = 1.1f;
            targetObject.GetComponent<BoxCollider>().enabled = true;
            isHolding = false;
        }
        else if(Input.GetKeyDown(throwKey) && isHolding)
        {
            rb = targetObject.AddComponent<Rigidbody>();
            rb.mass = 1.1f;
            targetObject.GetComponent<BoxCollider>().enabled = true;
            isHolding = false;
            Throw();
        }

        if (isHolding)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, holdPos.position, posLerp * Time.deltaTime);
        }
    }
    private void Throw()
    {
        rb.AddForce(playerCam.forward * throwForce);
    }
}
