using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotScript : MonoBehaviour
{
    //save a screenshot
    public void CaptureScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png");
    }
}
