using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrScreenshotMaker : Singleton<ScrScreenshotMaker>
{
    public void GetScreenShot(string str)
    {
        DateTime dt =DateTime.Now;
        string strName = $"scrShot_{str}_{dt.ToString("yyyy''MM''dd'_'HH'_'mm'_'ss'_'fff")}.png";
        ScreenCapture.CaptureScreenshot(strName);
    }
}

