using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    //public float waterHeight = 2.39f;
    public float waterHeight = 2f;
    public bool isCastedCorrectly=false;
    // Start is called before the first frame update
    void Start()
    {
         waterHeight = 2f;
     isCastedCorrectly = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isCastedCorrectly && gameObject.transform.position.y > waterHeight)
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        else if (isCastedCorrectly && gameObject.transform.position.y < waterHeight)
            gameObject.transform.Translate(Vector3.up * Time.deltaTime);
        
        //Debug.Log("tp"+transform.position);
        //Debug.Log("tpl"+transform.localPosition);
    }
}
