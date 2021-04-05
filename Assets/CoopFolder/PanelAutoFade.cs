using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAutoFade : MonoBehaviour
{
    private bool mFaded = false;
    public float duration = .4f;

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        mFaded = !mFaded;
        GameObject.Find("UDLRManager").GetComponent<UDLRManager>().ChangeQuestions();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        mFaded = !mFaded;
        
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        
        while (counter<duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            
            yield return null;
        }
    }
}
