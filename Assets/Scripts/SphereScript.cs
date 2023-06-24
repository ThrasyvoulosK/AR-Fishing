using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    //public float waterHeight = 2.39f;
    public float waterHeight = 2f;
    public float heightFactor = 0.1f;
    public bool isCastedCorrectly = false;
    public bool sphereInPlace = false;

    Rigidbody rb;
    public float force = 2000f;

    Transform origin;

    public bool shootBool = true;
    // Start is called before the first frame update
    void Start()
    {
        waterHeight = 2f;
        heightFactor = 0.1f;
        isCastedCorrectly = false;

        rb = GetComponent<Rigidbody>();

        origin = transform.parent.Find("RodEnd").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward*force);

        //if(transform==origin)
        
        //Debug.Log(force);
        //rb.AddForce(0,force,0);
        //Debug.Log("tp" + gameObject.transform.position.y);
        if (isCastedCorrectly && (gameObject.transform.position.y > (waterHeight + heightFactor)))
        {
            Debug.Log("y>water"+ (gameObject.transform.position.y > waterHeight));

            //if (shootBool)
            if(transform.localPosition.y<0.01&& transform.localPosition.z < 1.5)
            {
                ShootSphere();
                shootBool = false;
            }
            //gameObject.transform.Translate(transform.up * Time.deltaTime);
            //Debug.Log(force);
            rb.AddForce(0,force,0);
            sphereInPlace = false;
            rb.isKinematic = false;
        }
        else if (isCastedCorrectly && (gameObject.transform.position.y < (waterHeight - heightFactor)))
        {
            Debug.Log("y<water" + (gameObject.transform.position.y < waterHeight));
            gameObject.transform.Translate(-transform.up * Time.deltaTime*1);
            sphereInPlace = false;

            //Debug.Log("Don't use Gravity");
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else if (isCastedCorrectly)
        {
            if ((gameObject.transform.position.y <= (waterHeight + heightFactor)) && (gameObject.transform.position.y >= (waterHeight - heightFactor)))
            {
                Debug.Log("Stable Sphere");
                //isCastedCorrectly = false;
                sphereInPlace = true;

                //Debug.Log("Don't use Gravity");
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }
        else if (isCastedCorrectly == false)
        {
            sphereInPlace = false;
            rb.isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.Find("RodEnd").transform.position, Time.deltaTime);
        }

        Debug.Log("tp"+transform.position);
        Debug.Log("tpl"+transform.localPosition);
        
    }

    void ShootSphere()
    {
        Debug.Log("Shoot Sphere");
        //rb.AddRelativeForce(new Vector3(0, force, 0));
        rb.AddRelativeForce(new Vector3(0, 0, force*15));
        //rb.AddRelativeForce(transform.forward * force);
        //rb.AddRelativeForce(transform.position.z*force);
        shootBool = false;
    }
}
