using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fish;

    SphereScript sphereScript;
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GetComponentInParent<SphereScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sphereScript.sphereInPlace==true)
        {
            //reset value so that it doesn't trigger many coroutines!
            sphereScript.sphereInPlace = false;

            StartCoroutine(RandomFish());
        }
    }

    IEnumerator RandomFish()
    {
        yield return new WaitForSeconds(1f);
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);
        if(chance<0.5f)
        {
            Debug.Log("Fish Caught!");

        }
        else
        {
            Debug.Log("Fish Not Caught. Wait some more!");
        }


    }
}
