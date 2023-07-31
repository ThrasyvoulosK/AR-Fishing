using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//set and resets physics regarding 'sphere' gameobject,
//based on relative position to water and 'cast' status
public class SphereScript : MonoBehaviour
{
    public float waterHeight = 2f;
    public float heightFactor = 0.1f;
    public bool isCastedCorrectly = false;
    public bool sphereInPlace = false;

    Rigidbody rb;
    public float force = 2000f;

    Transform origin;

    public bool shootBool = true;

    public Vector3 properPosition;

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
    void FixedUpdate()
    {        
        //Debug.Log(force);
        //Debug.Log("tp" + gameObject.transform.position.y);

        if (isCastedCorrectly && (gameObject.transform.position.y > (waterHeight + heightFactor))&&shootBool==true)
        {
            //Debug.Log("SphereScript 1");
            //Debug.Log("y>water"+ (gameObject.transform.position.y > waterHeight));

            //if (shootBool)
            if(transform.localPosition.y<0.01&& transform.localPosition.z < 1.5&&shootBool==true)
            {
                ShootSphere();
                shootBool = false;
            }
            //gameObject.transform.Translate(transform.up * Time.deltaTime);
            //Debug.Log(force);
            //rb.AddForce(0,force,0);
            sphereInPlace = false;
            rb.isKinematic = false;
        }
        else if (isCastedCorrectly && (gameObject.transform.position.y < (waterHeight - heightFactor)))
        {
            //Debug.Log("SphereScript 2");
            //Debug.Log("y<water" + (gameObject.transform.position.y < waterHeight));
            gameObject.transform.Translate(-transform.up * Time.deltaTime*1);
            sphereInPlace = false;

            //Debug.Log("Don't use Gravity");
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else if (isCastedCorrectly)
        {
            //Debug.Log("SphereScript 3");
            if ((gameObject.transform.position.y <= (waterHeight + heightFactor)) && (gameObject.transform.position.y >= (waterHeight - heightFactor)))
            {
                //Debug.Log("Stable Sphere");
                //isCastedCorrectly = false;
                sphereInPlace = true;

                //Debug.Log("Don't use Gravity");
                rb.useGravity = false;
                rb.isKinematic = true;

                Vector3 currentTransform = gameObject.transform.position;
                properPosition = currentTransform;

            }
        }
        else if (isCastedCorrectly == false)
        {
            //Debug.Log("SphereScript 4");
            sphereInPlace = false;
            rb.isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.Find("RodEnd").transform.position, Time.deltaTime);
        }

        //Debug.Log("tp"+transform.position);
        //Debug.Log("tpl"+transform.localPosition);
        
    }

    //initial force for when 'sphere' is 'cast'
    void ShootSphere()
    {
        float shootFactor = 15;
        float shootForce = shootFactor * force;

        //Debug.Log("Shoot Sphere with a force of: "+shootForce);
        //rb.AddRelativeForce(new Vector3(0, force, 0));
        rb.AddRelativeForce(new Vector3(0, 0, shootForce));
        //rb.AddRelativeForce(transform.forward * force);
        //rb.AddRelativeForce(transform.position.z*force);
        shootBool = false;
    }
}
