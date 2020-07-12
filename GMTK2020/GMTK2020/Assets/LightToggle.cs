using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightToggle : MonoBehaviour, UpdateableEntity
{
    Light2D lightglobal;
    public float NormalLight;
    public float lightLight;
    public float darkLight;

    private int mode = 1;
    // Start is called before the first frame update
    void Start()
    {
        lightglobal = GetComponent<Light2D>();
        FindObjectOfType<CardManager>().AddObserver(this);
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

    public void ReceiveUpdate(Card activeCard)
    {
        switch(activeCard.cardType)
        {
            case CardType.EnvironmentMakeBrighter:
                if (mode == 0)
                {
                    NormalTheme();
                    mode++;
                }
                else if (mode == 1)
                {
                    lightTheme();
                    mode++;
                }
                break;
            case CardType.EnvironmentMakeDarker:
                if(mode == 2)
                {
                    NormalTheme();
                    mode--;
                }
                else if(mode == 1)
                {
                    DarkTheme();
                    mode--;
                }
                break;
        }
    }
}
