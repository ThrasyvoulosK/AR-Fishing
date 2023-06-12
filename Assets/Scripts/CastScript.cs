using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastScript : MonoBehaviour
{
    bool goodCast = false;
    Animator animator;

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
        //Debug.Log("cast rotation:"+gameObject.transform.parent.rotation.x);
        if (gameObject.transform.parent.rotation.x >= 0.1f||gameObject.transform.parent.rotation.x <= -0.1f)
            return false;
        return true;
    }

    void StopAnimation()
    {
        
        
        //AnimationState animationState= animator.animatio;
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
        AnimatorClipInfo[] animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(animatorClipInfo[0].clip.name);
        //Debug.Log(animatorClipInfo==null);
        //Debug.Log(animator.enabled);
        //Debug.Log(animator.GetCurrentAnimatorClipInfo(0));
        //Debug.Log(animatorClipInfo.Length);
        if (animatorClipInfo.Length > 0)
        {
            //Debug.Log(animatorClipInfo[0].clip.name);
            if (animatorClipInfo[0].clip.name == "PushRodEnd")
            {
                animator.StopPlayback();
                animator.enabled = false;

                sphereScript.isCastedCorrectly = true;
            }
            else if (animatorClipInfo[0].clip.name == "IdleRod")
            {
                fishReset = false;
            }
            /*else if (animatorClipInfo[0].clip.name == "ReelRodEnd")
            {
                Debug.Log("Reeling");
                //animator.enabled = true;
                //sphereScript.isCastedCorrectly = false;
            }*/
        }
        else
        {
            Debug.Log("Reeling");
            /*animator.Play("ReelRod");
            Debug.Log(animator.GetNextAnimatorClipInfo(0)[0].clip.name);*/
        }
    }
    public bool fishReset = false;
    void ResetAnimation(bool fishReset)
    {
        if(fishReset)
            animator.enabled = true;
    }

    public void ToggleFishReset()
    {
        fishReset=!fishReset;
    }
}
