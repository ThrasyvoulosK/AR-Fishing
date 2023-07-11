using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> fish;

    [SerializeField]
    List<FishSO> fishSOs;

    public Dictionary<GameObject,FishSO> fishDB=new Dictionary<GameObject, FishSO>();

    SphereScript sphereScript;
    CastScript castScript;
    public bool fishWait = false;
    float fishChance = 0.2f;

    [SerializeField]
    Button reelButton;

    public GameObject currentFish;
    // Start is called before the first frame update
    void Start()
    {
        sphereScript = GetComponentInParent<SphereScript>();

        castScript = sphereScript.gameObject.GetComponentInParent<CastScript>();

        //Debug.Log(castScript.fishReset + " " + sphereScript.isCastedCorrectly + " " + sphereScript.sphereInPlace + " " + fishWait);
        InitialiseDictionary();

        currentFish = null;
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

        if(transform.childCount>0)
        {
            Debug.Log("Error, Fish already caught!");
            yield return null;
        }
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

        currentFish = fish[fishSelected];

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

        //Fishing Restart
        if (transform.childCount > 0)
            sphereScript.isCastedCorrectly = false;
    }

    void InitialiseDictionary()
    {
        for(int i=0;i<fish.Count;i++)
        {
            //Debug.Log(i);
            //Debug.Log(fish.Count);
            //Debug.Log(fishDB.Count);
            fishDB.Add(fish[i], fishSOs[i]);
            //Debug.Log(fishDB[fish[i]].weight);
            Debug.Log(fish[i].name);
            Debug.Log(fishSOs[i].weight);
        }
    }

}
