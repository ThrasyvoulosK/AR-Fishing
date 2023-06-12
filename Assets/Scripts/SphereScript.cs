using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    //public float waterHeight = 2.39f;
    public float waterHeight = 2f;
    public float heightFactor=0.1f;
    public bool isCastedCorrectly=false;
    public bool sphereInPlace = false;
    // Start is called before the first frame update
    void Start()
    {
         waterHeight = 2f;
        heightFactor = 0.1f;
        isCastedCorrectly = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("tp" + gameObject.transform.position.y);
        /*if (sphereInPlace == false)
        {*/
            if (isCastedCorrectly && (gameObject.transform.position.y > (waterHeight + heightFactor)))
            {
                //Debug.Log("y>water"+ (gameObject.transform.position.y > waterHeight));
                gameObject.transform.Translate(transform.up * Time.deltaTime);
                sphereInPlace = false;
            }
            else if (isCastedCorrectly && (gameObject.transform.position.y < (waterHeight - heightFactor)))
            {
                //Debug.Log("y<water" + (gameObject.transform.position.y < waterHeight));
                gameObject.transform.Translate(-transform.up * Time.deltaTime);
                sphereInPlace = false;
            }
            else if (isCastedCorrectly)
            {
                if ((gameObject.transform.position.y <= (waterHeight + heightFactor)) && (gameObject.transform.position.y >= (waterHeight - heightFactor)))
                {
                    //Debug.Log("Stable Sphere");
                    //isCastedCorrectly = false;
                    sphereInPlace = true;
                }
            }
        

        //Debug.Log("tp"+transform.position);
        //Debug.Log("tpl"+transform.localPosition);
    }
}
