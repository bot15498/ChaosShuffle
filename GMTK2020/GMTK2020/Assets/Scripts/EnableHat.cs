using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class EnableHat : MonoBehaviour
{
    public float changeRate;
    SpriteRenderer sr;
    private float timer;
    private Color[] colours = new Color[7];
    public Light2D light;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = 0;
        colours[0] = Color.blue;
        colours[1] = Color.cyan;
        colours[2] = Color.green;
        colours[4] = Color.magenta;
        colours[5] = Color.red;
        colours[6] = Color.yellow;
        StartCoroutine(change());
    }

    // Update is called once per frame
    void Update()
    {

       
        /*timer += 1;
        if (timer >= changeRate)
        {

            ChangeColour();
            timer = 0;
        }*/
    }

    void ChangeColour()
    {
        sr.color = colours[Random.Range(0, colours.Length - 1)];
        if(light != null)
        {
            light.color = colours[Random.Range(0, colours.Length - 1)];
        }
    }


    public IEnumerator change()
    {
        while (true)
        {
            float currTime = 0f;
            while (currTime < changeRate)
            {
                currTime += Time.deltaTime;
                float h = Mathf.Lerp(0, 1, currTime / changeRate);
                sr.color = Color.HSVToRGB(h, 1, 1f);
                yield return null;
            }
        }
    }

    public void EnableHatSprite()
    {
        sr.enabled = true;
    }
}
