using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour {

    public CanvasGroup fadeElement;
    private float _time = 1f;

    public float time
    {
        get
        {
            return _time;
        }

        set
        {
            _time = value;
        }
    }

    public void FirstTimeFade()
    {
        Debug.Log("First time fade panel");
        StartCoroutine(FadeCanvasGroup(fadeElement, fadeElement.alpha, 1f, 0,InformationShowAndHide.Instance.beginLocation,InformationShowAndHide.Instance.endLocation,1,0));

    }
    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(fadeElement, fadeElement.alpha,1f, time, InformationShowAndHide.Instance.beginLocation, InformationShowAndHide.Instance.endLocation,0,1));
    }
    public void FadeOut()
    {

        StartCoroutine(FadeCanvasGroup(fadeElement, fadeElement.alpha, 0f,time, InformationShowAndHide.Instance.endLocation, InformationShowAndHide.Instance.beginLocation, 1,0));
    }
   
   
    public IEnumerator FadeCanvasGroup(CanvasGroup cg,float start,float end,float lerpTime,Vector3 beginLoc,Vector3 endLoc,float scaleBegin,float scaleEnd)
    {
        Debug.Log("start point: " + beginLoc.x + "/" + beginLoc.y + "/" + beginLoc.z);
        Debug.Log("end point: " + endLoc.x + "/" + endLoc.y + "/" + endLoc.z);
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
      
        while(true)
        {
             timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;
            float currentValue = Mathf.Lerp(start, end, percentageComplete);
            float currentScale = Mathf.Lerp(scaleBegin, scaleEnd, percentageComplete);
            Vector3 currentPos = new Vector3  (Mathf.Lerp(beginLoc.x, endLoc.x, percentageComplete), Mathf.Lerp(beginLoc.y, endLoc.y, percentageComplete),Mathf.Lerp(beginLoc.z, endLoc.z, percentageComplete));
            cg.alpha = currentValue;
            cg.transform.position = currentPos;
            cg.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            
                if (percentageComplete >= 1) break;
            yield return new WaitForEndOfFrame();
        }
    }
}
