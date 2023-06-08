using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastScript : MonoBehaviour
{
    bool goodCast = false;
    Animator animator;

    SphereScript sphereScript;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        sphereScript = GetComponentInChildren<SphereScript>();
    }

    // Update is called once per frame
    void Update()
    {
        StopAnimation();
        ResetAnimation(fishReset);
    }

    bool checkCast()
    {
        if (gameObject.transform.parent.rotation.x >= 30||gameObject.transform.parent.rotation.x <= -30)
            return false;
        return true;
    }

    void StopAnimation()
    {
        
        
        //AnimationState animationState= animator.animatio;
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
        AnimatorClipInfo[] animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(animatorClipInfo[0].clip.name);
        if(animatorClipInfo[0].clip.name=="PushRodEnd")
        {
            animator.StopPlayback();
            animator.enabled = false;

            sphereScript.isCastedCorrectly = true;
        }
        else if(animatorClipInfo[0].clip.name == "IdleRod")
        {
            fishReset = false;
        }
    }
    public bool fishReset = false;
    void ResetAnimation(bool fishReset)
    {
        if(fishReset)
            animator.enabled = true;
    }
}
