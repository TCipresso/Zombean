using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
 * ImageFader is meant to handle the image fading and transitions.
 * This is what we got from class and it worked very well.
 */
public class ImageFader : MonoBehaviour
{
    Image image;
    public float fadeTime = 1;

    private void Start()
    {
        image = GetComponent<Image>();
    }


    public void FadeFromBlack()
    {
        StartCoroutine(FadeFromBlackCO());
    }
    public IEnumerator FadeFromBlackCO()
    {
        float timer = 0;// keep track of time that's passed.

        while(timer < fadeTime)
        {
            timer += Time.deltaTime;
            image.color = new Color(0, 0, 0, 1 - (timer / fadeTime));
            yield return null;
        }
        image.color = Color.clear;
        yield return null;
    }


    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackCO());
    }
    public IEnumerator FadeToBlackCO()
    {
        float timer = 0;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            image.color = new Color(0, 0, 0,(timer / fadeTime));
            yield return null;
        }
        image.color = Color.black;
        yield return null;
    }
}
