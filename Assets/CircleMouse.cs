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

    // Start is called before the first frame update
    void Start()
    {
        //Obj = transform;
        Obj = GetComponent<RectTransform>();
        //Parent = transform.parent;
        Parent = transform.parent.GetComponent<RectTransform>();
        Debug.Log(cameraMain.name);

        //Radius = 125f;
    }

    // Update is called once per frame
    void Update()
    {
        MousePos = Input.mousePosition;
        Debug.Log("mouse pos"+MousePos);
        //Debug.Log(Obj.position);
        //Debug.Log(cameraMain.transform.position);
        ScreenMouse = cameraMain.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, Obj.position.z - cameraMain.transform.position.z));
        Debug.Log("screen mouse pos" + ScreenMouse);
        ///MouseOffset = ScreenMouse - Parent.position;
        MouseOffset = MousePos - Parent.position;
        Debug.Log("mouse offset" + MouseOffset);
        //Obj.position.Set(ScreenMouse.x, ScreenMouse.y,Obj.position.z);

        Dist = Vector2.Distance(new Vector2(Obj.position.x, Obj.position.y), new Vector2(Parent.position.x, Parent.position.y));
        Debug.Log("Dist: "+ Dist);
        Vector3 newPos;
        /*if (Dist > Radius)
        {*/
            Debug.Log(Dist > Radius);
            var norm = MouseOffset.normalized;
            newPos= new Vector3(norm.x * Radius + Parent.position.x, norm.y* Radius +Parent.position.y,Obj.transform.position.z);
            //Obj.position.Set(norm.x * Radius + Parent.position.x, norm.y * Radius + Parent.position.y,Obj.transform.position.z);
            Obj.position = newPos;
        /*}*/
    }
}
