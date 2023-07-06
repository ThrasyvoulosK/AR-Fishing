using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelRotate : MonoBehaviour
{
    public Image Wheel; //the thing you're trying to rotate
    Vector2 dir;
    float dist;
    float check;
    private bool isRotating;
    private float angle;
    private bool checkPoint;

    void Update()
    {
        //is rotating is set true if mouse is down on the handle
        if (isRotating)
        {
            //Vector from center to mouse pos
            dir = (Input.mousePosition - Wheel.transform.position);
            //Distance between mouse and the center
            dist = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);

            //if mouse is not outside nor too inside the wheel
            if (dist < 350 && dist > 150)
            {
                angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg; //alien technology
                angle = (angle > 0) ? angle : angle + 360; //0 to 360 instead of -180 to 180

                //this if blocks going back or jumping too far
                if ((angle < check && check - angle < 90) || angle > 350)
                {
                    check = angle;
                    Wheel.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
                    //Vector3.back for counter clockwise, Vector3.forward for clockwise..I think
                }
            }
        }
        //to confirm if it has passed full circle
        if (angle > 160 && angle < 200)
        {
            checkPoint = true;
        }

        if (angle > 350 && checkPoint)
        {
            checkPoint = false;
            Debug.Log("SCORE++");
        }
    }

    public void BeginDrag()
    {
        isRotating = true;
    }
    public void EndDrag()
    {
        isRotating = false;
    }
}
