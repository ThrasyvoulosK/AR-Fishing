using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMouse : MonoBehaviour
{

    //Transform Parent;
    RectTransform Parent;
    //Transform Obj;
    RectTransform Obj;
    public float Radius = 2.4f;
    float Dist ;
    Vector3 MousePos;
    Vector3 ScreenMouse  ;
    Vector3 MouseOffset;

    public Camera cameraMain;

    public List<Vector3> checkPoints;
    public List<bool> checkPointsPassed;

    int numberOfCircles = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Obj = transform;
        Obj = GetComponent<RectTransform>();
        //Parent = transform.parent;
        Parent = transform.parent.GetComponent<RectTransform>();
        Debug.Log(cameraMain.name);

        //Radius = 125f;
        GenerateCheckPoints();
    }

    

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        //Debug.Log("mouse pos"+MousePos);

        float radiusFactor = Radius*2f;
        if (Input.GetMouseButton(0))
        {
            if (((MousePos.x <= Parent.position.x + radiusFactor) && (MousePos.y <= Parent.position.y + radiusFactor)) && ((MousePos.x >= Parent.position.x - radiusFactor) && (MousePos.y >= Parent.position.y - radiusFactor)))
            {
                //Debug.Log("parent rect" + Parent.rect);
                //Debug.Log(Obj.position);
                //Debug.Log(cameraMain.transform.position);
                ScreenMouse = cameraMain.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Obj.position.z - cameraMain.transform.position.z));
                //Debug.Log("screen mouse pos" + ScreenMouse);
                ///MouseOffset = ScreenMouse - Parent.position;
                MouseOffset = MousePos - Parent.position;
                //Debug.Log("mouse offset" + MouseOffset);
                //Obj.position.Set(ScreenMouse.x, ScreenMouse.y,Obj.position.z);

                Dist = Vector2.Distance(new Vector2(Obj.position.x, Obj.position.y), new Vector2(Parent.position.x, Parent.position.y));
                //Debug.Log("Dist: " + Dist);
                Vector3 newPos;

                //Debug.Log(Dist > Radius);
                var norm = MouseOffset.normalized;
                newPos = new Vector3(norm.x * Radius + Parent.position.x, norm.y * Radius + Parent.position.y, Obj.transform.position.z);
                Obj.position = newPos;

                //check if the handle passes through a checkpoint
                CheckPoint();
                //Check if a circle has been completed
                CheckCircle();
            }
        }
    }

    private void GenerateCheckPoints()
    {
        //add checkpoints to pass
        //checkPoints.Add(new Vector3(0, Radius, 0));
        //checkPoints.Add(new Vector3(Radius, 0, 0));
        //checkPoints.Add(new Vector3(0, -Radius, 0));
        //checkPoints.Add(new Vector3(-Radius, 0, 0));
        float parX = Parent.position.x;
        float parY = Parent.position.y;
        checkPoints.Add(new Vector3(parX, parY+Radius, 0));
        checkPoints.Add(new Vector3(parX+Radius, parY, 0));
        checkPoints.Add(new Vector3(parX, parY-Radius, 0));
        checkPoints.Add(new Vector3(parX-Radius, parY, 0));

        ResetCheckpoints();
    }
    private void CheckPoint()
    {
        float dist;
        int i = 0;
        foreach(Vector3 checkpoint in checkPoints)
        {
            dist = Vector3.Distance(Obj.position, checkpoint);
            //Debug.Log(dist);
            if(dist<Radius/5&& checkPointsPassed[i] == false)
            {
                checkPointsPassed[i] = true;
                return;
            }
            i++;
        }
    }
    private void CheckCircle()
    {
        //throw new NotImplementedException();
        foreach(bool bol in checkPointsPassed)
        {
            if (bol == false)
                return;
        }
        Debug.Log("Circle Completed!");
        ResetCircle();
    }

    

    private void ResetCheckpoints()
    {
        checkPointsPassed.Clear();

        //initialise passed checkpoints as false
        for (int i = 0; i < 4; i++)
            checkPointsPassed.Add(false);
    }
    
    private void ResetCircle()
    {
        ResetCheckpoints();

        numberOfCircles++;
        Debug.Log("Number Of Circles " + numberOfCircles);
    }
}
