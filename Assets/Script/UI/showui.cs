using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showui : MonoBehaviour
{
    public float changeTimeSeconds = 5; 
    public float startAlpha = 0; 
    public float endAlpha = 1; 
    float changeRate = 0; 
    float timeSoFar = 0; 
    bool fading = false;
    public CanvasGroup canvasGroup; 
    void Start() 
    {
        canvasGroup = this.GetComponent<CanvasGroup>(); 
        if (canvasGroup == null) 
        { 
            Debug.Log("Must have canvas group attached!");
            this.enabled = false;
        }
        SetAlpha(0);
    }
    public void FadeIn() 
    {
        startAlpha = 0;
        endAlpha = 1;
        timeSoFar = 0;
        fading = true;
        changeTimeSeconds = 1;
        StartCoroutine(FadeCoroutine());
    }
    public void FadeOut()
    {
        startAlpha = 1;
        endAlpha = 0;
        timeSoFar = 0; 
        fading = true;
        changeTimeSeconds = 5;
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine() {
        changeRate = (endAlpha - startAlpha) / changeTimeSeconds;
        SetAlpha(startAlpha);
        while (fading)
        {
            timeSoFar += Time.deltaTime;
            if (timeSoFar > changeTimeSeconds)
            {
                fading = false; 
                SetAlpha(endAlpha);
                if(endAlpha == 1)
                {
                    FadeOut();
                }
                yield break;
                
            } 
            else 
            { 
                SetAlpha(canvasGroup.alpha + (changeRate * Time.deltaTime));
            } 
            yield return null;
        }
    }
    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = Mathf.Clamp(alpha, 0, 1); 
    }

}
