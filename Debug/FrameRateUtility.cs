using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class FrameRateUtility : MonoBehaviour
{
    //Quality manager related
    public bool m_showFPS = true;

    public int m_fontSize = 25;

    //FPS Related
    private float FPS = 0;
    private GUIStyle m_fpsStyle = new GUIStyle();
    private GUIStyle m_fpsShadowStyle = new GUIStyle();
    private Rect m_fpsLocation = new Rect(5, 5, 100, 25);

    //Initialization stuff
    void Start()
    {
        m_fpsStyle.fontSize = m_fontSize;
        m_fpsShadowStyle.fontSize = m_fontSize;
    }

    void OnGUI()
    {
        if (m_showFPS)
        {
            GUI.Label(m_fpsLocation, "FPS : " + FPS, m_fpsStyle);
        }
    }

    float elapsed = 0;
    int counter = 0;
    void Update()
    {
        elapsed += Time.deltaTime;
        counter++;

        if (elapsed >= 1)
        {
            FPS = counter;
            counter = 0;
            elapsed = 0;
            if (FPS < 80)
                m_fpsStyle.normal.textColor = Color.yellow;
            else if (FPS < 50)
                m_fpsStyle.normal.textColor = Color.red;
            else
                m_fpsStyle.normal.textColor = Color.green;
        }
    }
}
