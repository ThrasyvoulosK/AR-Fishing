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
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        sphereScript = GetComponentInChildren<SphereScript>();

        castButton = GameObject.Find("Canvas").transform.Find("CastButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCast() == false)
            castButton.interactable = false;
        else
            castButton.interactable = true;

        StopAnimation();
        ResetAnimation(fishReset);
    }

    bool checkCast()
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
                if(transform.Find("Sphere").transform.Find("Fish").childCount>0)
                {
                    Debug.Log("Ending Condition");
                    transform.Find("Sphere").transform.Find("Fish").GetComponent<FishScript>().fishWait = false;
                    sphereScript.isCastedCorrectly = false;
                    fishReset = false;

                    //Destroy(transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject);

                }
            }
            /*else if (animatorClipInfo[0].clip.name == "ReelRodEnd")
            {
                Debug.Log("Reeling");
                //animator.enabled = true;
                //sphereScript.isCastedCorrectly = false;
            }*/
            else if(animatorClipInfo[0].clip.name == "PullRod")
            {
                if (transform.Find("Sphere").transform.Find("Fish").childCount > 0)
                    Destroy(transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject);
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
}
