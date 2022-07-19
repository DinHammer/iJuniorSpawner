using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScrScreenshotMaker))]
public class EdtScreenshotMaker : UnityEditor.Editor
{
    private string strName = string.Empty;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScrScreenshotMaker screenshotMaker = (ScrScreenshotMaker) target;

        strName = GUILayout.TextField(strName, 25); 
        
        if (GUILayout.Button("GetScreenshot"))
        {
            Debug.Log($"MakeScreenshot with name: {strName}");
            screenshotMaker.GetScreenShot(strName);
        }
        
        
    }
}
