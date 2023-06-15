using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastScript : MonoBehaviour
{
    public Animator animator;
    public bool fishReset = false;

    SphereScript sphereScript;
    Button castButton;
    Button reelButton;

    [SerializeField]
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        sphereScript = GetComponentInChildren<SphereScript>();

        castButton = GameObject.Find("Canvas").transform.Find("CastButton").GetComponent<Button>();
        reelButton = GameObject.Find("Canvas").transform.Find("ReelButton").GetComponent<Button>();

        //allow cast button only on idle rod
        castButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (checkCast() == false)
        {
            if(castButton.interactable==true)
                castButton.interactable = false;
        }
        else
            castButton.interactable = true;*/

        StopAnimation();
        ResetAnimation(fishReset);
    }

    bool CheckCastRotation()
    {
        if (gameObject.transform.parent.rotation.x >= 0.1f||gameObject.transform.parent.rotation.x <= -0.1f)
            return false;
        return true;
    }

    void StopAnimation()
    {
        AnimatorClipInfo[] animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);

        if (animatorClipInfo.Length > 0)
        {
            //Debug.Log(animatorClipInfo[0].clip.name);
            if (animatorClipInfo[0].clip.name == "PushRodEnd")
            {
                //Debug.Log("PushRodEnd");
                animator.StopPlayback();
                animator.enabled = false;

                sphereScript.isCastedCorrectly = true;
            }
            else if (animatorClipInfo[0].clip.name == "IdleRod")
            {
                //Debug.Log("IdleRod");
                //fishReset = false;

                //reeling not needed
                reelButton.interactable = false;
                //allow rod to be cast
                if (CheckCastRotation() == false)
                    castButton.interactable = false;
                else
                    castButton.interactable = true;

                if (transform.Find("Sphere").transform.Find("Fish").childCount > 0)
                {
                    Debug.Log("Ending Condition");
                    transform.Find("Sphere").transform.Find("Fish").GetComponent<FishScript>().fishWait = false;
                    sphereScript.isCastedCorrectly = false;
                    fishReset = false;

                    //Destroy(transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject);
                    StartCoroutine(Invisivise());

                }
                else
                    StopCoroutine(Invisivise());
            }
            /*else if (animatorClipInfo[0].clip.name == "ReelRodEnd")
            {
                Debug.Log("Reeling");
                //animator.enabled = true;
                //sphereScript.isCastedCorrectly = false;
            }*/
            else if(animatorClipInfo[0].clip.name == "PullRod")
            {                
                castButton.interactable = false;
            }
            else
                Debug.Log(animatorClipInfo[0].clip.name);
        }
        else
        {
            /*Debug.Log("Reeling");
            //animator.Play("ReelRod");
            //Debug.Log(animator.GetNextAnimatorClipInfo(0)[0].clip.name);

            //animator.StopPlayback();
            animator.enabled = true;

            sphereScript.isCastedCorrectly = false;*/
        }
    }
    
    void ResetAnimation(bool fishReset)
    {
        if(fishReset)
            animator.enabled = true;
    }

    /*public void ToggleFishReset()
    {
        fishReset=!fishReset;
    }*/

    IEnumerator Invisivise()
    {
        if (transform.Find("Sphere").transform.Find("Fish").childCount <= 0)
        {
            Debug.Log("No fish");
            yield return null;
        }
        //Debug.Log("Invisivise "+ transform.Find("Sphere").transform.Find("Fish").childCount);
        GameObject fishy = transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject;
        //Destroy(transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject);
        Renderer renderer = fishy.GetComponent<Renderer>();
        //renderer.material.renderingMode
        renderer.material = material;
        Color color = renderer.material.color;
        /*if(color.a==0)
        {
            Destroy(fishy);
            yield return null;
        }*/
        //for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        for (float alpha = 1f; alpha >= 0; alpha -= 0.05f)
        {
            //Debug.Log("Alpha " + alpha);
            color.a = alpha;
            if (fishy == null)
            {
                //Debug.Log(fishy == null);
                yield return null;
            }
            else
                renderer.material.color = color;
            if(color.a<=0.08)
            {
                Destroy(fishy);
                yield return null;
            }
            //renderer.material.color = color;
            yield return null;
        }
        //renderer.material.color = color;
    }
}
