using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fish;

    SphereScript sphereScript;
    CastScript castScript;
    public bool fishWait = false;
    float fishChance = 0.2f;

    [SerializeField]
    Button reelButton;
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GetComponentInParent<SphereScript>();

        castScript = sphereScript.gameObject.GetComponentInParent<CastScript>();

        Debug.Log(castScript.fishReset + " " + sphereScript.isCastedCorrectly + " " + sphereScript.sphereInPlace + " " + fishWait);
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
        //Debug.Log("Starting Coroutine");
        yield return new WaitForSeconds(1f);
        float chance = Random.Range(0f, 1f);

        if(chance>fishChance)
        {
            Debug.Log("Fish Not Caught. Wait some more!");
            StartCoroutine(RandomFish());
        }
        else
        {
            Debug.Log("Fish Caught!");
            reelButton.interactable = true;
            //StopAllCoroutines();
            StopCoroutine(RandomFish());

            CatchFish();

            //Reel();
        }

        yield return new WaitForSeconds(1f);

    }

    void CatchFish()
    {
        //choose which fish to catch
        float fishGOChance = Random.Range(1, fish.Count);
        int fishSelected = (int)fishGOChance;
        //Debug.Log("Fish Chosen:" + fishSelected);
        Instantiate(fish[fishSelected], transform);

        Handheld.Vibrate();
    }

    public void Reel()
    {
        Debug.Log("Reel");
        Transform rod = transform.parent.transform.parent;

        //play reel animation
        CastScript castScript = rod.GetComponent<CastScript>();
        castScript.fishReset = true;

        rod.gameObject.GetComponent<Animator>().enabled = true;

        rod.gameObject.GetComponent<Animator>().SetTrigger("ReelTrigger");
        //rod.gameObject.GetComponent<Animation>().Play("ReelRod");

        FishingRestart();
    }

    void FishingRestart()
    {
        if(transform.childCount>0)
        {
            //Debug.Log("We've got a fish!");
            //Debug.Log(castScript.fishReset+" " + sphereScript.isCastedCorrectly +" "+ sphereScript.sphereInPlace +" " +fishWait);
            //falsify all booleans

            //castScript.fishReset = false;
            //castScript.fishReset = true;
            //castScript.animator.enabled = true;
            //castScript.animator.Play("IdleRod");

            sphereScript.isCastedCorrectly = false;
            //sphereScript.sphereInPlace = false;

            //fishWait = false;
        }
    }

    /*public void FishDisappear()
    {
        GameObject fishObject = gameObject.transform.GetChild(0).gameObject;

        //fishObject.GetComponent<>
    }*/
}
