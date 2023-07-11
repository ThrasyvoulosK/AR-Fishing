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
    //Button reelButton;

    [SerializeField]
    Material material;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        sphereScript = GetComponentInChildren<SphereScript>();

        castButton = GameObject.Find("Canvas").transform.Find("CastButton").GetComponent<Button>();
        //reelButton = GameObject.Find("Canvas").transform.Find("ReelButton").GetComponent<Button>();

        //allow cast button only on idle rod
        castButton.interactable = false;

        PrevPos = transform.position;
        NewPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        ResetAnimation(fishReset);
    }

    //Check the camera Rotation along the x and z axes for proper casting
    bool CheckCastRotation()
    {
        Quaternion cameraRotation = gameObject.transform.parent.rotation;
        if (cameraRotation.x >= 0.1f||cameraRotation.x <= -0.1f|| cameraRotation.z >= 0.1f || cameraRotation.z <= -0.1f)
            return false;
        return true;
    }

    //Check the animation state of the rod in the animator and act accordingly
    void CheckAnimation()
    {
        AnimatorClipInfo[] animatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        string clipName = null;// animatorClipInfo[0].clip.name;

        if (animatorClipInfo.Length > 0)
        {
            clipName =  animatorClipInfo[0].clip.name;
            //Debug.Log(clipName);

            if (clipName == "PushRodEnd 2")//&animator.enabled==true)
            {
                //Debug.Log("PushRodEnd");
                //animator.StopPlayback();
                //animator.enabled = false;

                ////sphereScript.isCastedCorrectly = true;

                //Debug.Log("Use Gravity");
                ////transform.Find("Sphere").GetComponent<Rigidbody>().useGravity = true;                
            }
            else if (clipName == "PushRodEnd 1")
            {
                animator.StopPlayback();
                animator.enabled = false;
            }
            else if(clipName == "PushRod 1")
            {
                NewPos = transform.position;  // each frame track the new position
                ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
                PrevPos = NewPos;  // update position for next frame calculation

                //Rigidbody rb = GetComponent<Rigidbody>();
                //Debug.Log("PushRod animation speed: "+animatorClipInfo[0].clip.averageSpeed);
                //Debug.Log("PushRod rb speed: "+rb.velocity);
                //Debug.Log("PushRod angular velocity: "+rb.angularVelocity);
                //Debug.Log("prevPoss "+PrevPos + "\n" +"NewPos "+ NewPos + "\n ObjVelocity" + ObjVelocity);
                //Debug.Log(ObjVelocity.magnitude);

                //
                sphereScript.isCastedCorrectly = true;
                transform.Find("Sphere").GetComponent<Rigidbody>().useGravity = true;

                //Debug.Log("ShootBool");
                sphereScript.shootBool = true;
            }
            else if (clipName == "IdleRod")
            {
                //Debug.Log("IdleRod");
                //fishReset = false;

                //reeling not needed
                ////reelButton.interactable = false;

                //allow rod to be cast
                if (CheckCastRotation() == false)
                    castButton.interactable = false;
                else
                    castButton.interactable = true;

                if (transform.Find("Sphere").transform.Find("Fish").childCount == 1)
                {
                    Debug.Log("Ending Condition");
                    transform.Find("Sphere").transform.Find("Fish").GetComponent<FishScript>().fishWait = false;
                    sphereScript.isCastedCorrectly = false;
                    fishReset = false;

                    StartCoroutine(Invisivise());

                }
                else
                {
                    StopCoroutine(Invisivise());
                }
            }
            /*else if (clipName == "ReelRodEnd")
            {
                Debug.Log("Reeling");
                //animator.enabled = true;
                //sphereScript.isCastedCorrectly = false;
            }*/
            else if (clipName == "PullRod")
            {                
                castButton.interactable = false;
            }
            else
                Debug.Log("Other animation name: "+ clipName);
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

    IEnumerator Invisivise()
    {
        if (transform.Find("Sphere").transform.Find("Fish").childCount <= 0)
        {
            Debug.Log("No fish");
            yield return null;
        }
        //Debug.Log("Invisivise "+ transform.Find("Sphere").transform.Find("Fish").childCount);
        GameObject fishy = transform.Find("Sphere").transform.Find("Fish").GetChild(0).gameObject;

        Renderer renderer = fishy.GetComponent<Renderer>();
        renderer.material = material;
        Color color = renderer.material.color;

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

            //destroy the fish created if it is nearly invisible
            if(color.a<=0.08)
            {
                Destroy(fishy);
                transform.Find("Sphere").transform.Find("Fish").GetComponent<FishScript>().currentFish = null;
                StopAllCoroutines();
                yield return null;
            }

            yield return null;
        }
    }
}
