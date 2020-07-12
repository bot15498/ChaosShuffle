using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightToggle : MonoBehaviour
{
    Light2D lightglobal;
    public float NormalLight;
    public float lightLight;
    public float darkLight;
    // Start is called before the first frame update
    void Start()
    {
        lightglobal = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DarkTheme()
    {
        lightglobal.intensity = darkLight;
    }

    public void NormalTheme()
    {
        lightglobal.intensity = NormalLight;
    }

    public void lightTheme()
    {
        lightglobal.intensity = lightLight;
    }
}
