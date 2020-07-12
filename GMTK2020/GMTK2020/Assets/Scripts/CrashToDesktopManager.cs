using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashToDesktopManager : MonoBehaviour
{
    public float showDuration = 4f;
    public float fadeDuration = 1f;
    public Text pauseText;

    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FlashText(pauseText));
        }
    }

    private IEnumerator FlashText(Text text)
    {
        isAnimating = true;
        pauseText.gameObject.SetActive(true);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
        yield return new WaitForSecondsRealtime(showDuration);
        float lerpProgress = 0f;
        float lerpStartTime = Time.time;
        while(lerpProgress < fadeDuration)
        {
            lerpProgress += Time.time;
            float alpha = Mathf.Lerp(1, 0, lerpProgress / fadeDuration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return new WaitForEndOfFrame();
        }
        isAnimating = false;
        text.gameObject.SetActive(false);
        yield return null;
    }
}
