using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float fadeDuration = 0.1f;
    public Image fadeImage;
    private bool isFading = false;
    private float fadeTarget = 0f;

    void Update()
    {
        if (isFading && fadeImage != null)
        {
            float alpha = Mathf.MoveTowards(fadeImage.color.a, fadeTarget, Time.deltaTime / fadeDuration);
            if (fadeImage != null) 
            {
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            }

            if (alpha == fadeTarget)
            {
                isFading = false;
            }
        }
    }
    public void FadeInAndOut()
    {
        FadeOut();
        Invoke("FadeIn", fadeDuration); 
    }
    public void FadeIn()
    {
        fadeTarget = 0f;
        isFading = true;
    }

    public void FadeOut()
    {
        fadeTarget = 1f;
        isFading = true;
    }
}
