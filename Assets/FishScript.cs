using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fish;

    SphereScript sphereScript;
    bool fishWait = false;
    float fishChance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GetComponentInParent<SphereScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sphereScript.sphereInPlace);
        if(sphereScript.sphereInPlace==true&&fishWait==false)
        {
            Debug.Log("If start");
            Debug.Log(sphereScript.transform.gameObject.name);
            //reset value so that it doesn't trigger many coroutines!
            //sphereScript.sphereInPlace = false;
            fishWait = true;

            StartCoroutine(RandomFish());
        }
    }

    IEnumerator RandomFish()
    {
        Debug.Log("Starting Coroutine");
        yield return new WaitForSeconds(1f);
        float chance = Random.Range(0f, 1f);
        Debug.Log(chance);
        /*if(chance<0.1f)
        {
            Debug.Log("Fish Caught!");
            //StopCoroutine(RandomFish());
            StopAllCoroutines();

        }
        else
        {
            Debug.Log("Fish Not Caught. Wait some more!");
        }*/
        if(chance>fishChance)
        {
            Debug.Log("Fish Not Caught. Wait some more!");
            //yield return new WaitForSeconds(1f);
            StartCoroutine(RandomFish());
        }
        else
        {
            Debug.Log("Fish Caught!");
            //StopCoroutine(RandomFish());
            StopAllCoroutines();

            //
            Instantiate(fish[0],transform);
        }

        yield return new WaitForSeconds(1f);
        //StartCoroutine(RandomFish());

    }
}
