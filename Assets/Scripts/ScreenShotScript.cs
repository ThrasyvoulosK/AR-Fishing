using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CaptureScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png");
    }
}
