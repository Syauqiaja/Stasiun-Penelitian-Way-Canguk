using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackingZoom : UITween
{
    public float startScale = 0.1f;
    public float targetScale = 1f;
    public float beforeHideDelay = 0f;
    
    public bool isAutoDelay = false;
    public bool onEnable = true;
    public bool isAutoHide = false;
    private void OnEnable() {
        if(onEnable) Show();
    }
    public override void Show()
    {
        LeanTween.cancel(gameObject);
        float preferedDelay = delay;
        if(isAutoDelay){
            preferedDelay = transform.GetSiblingIndex() * delay;
        }
        transform.localScale = Vector3.one * startScale;
        LeanTween.scale(gameObject, Vector2.one * targetScale, leanTime).setEaseOutBack().setDelay(preferedDelay).setIgnoreTimeScale(true).setOnComplete(()=>{
            if(isAutoHide){
                Invoke("Hide", beforeHideDelay);
            }
        });
    }

    public override void Hide()
    {
        LeanTween.cancel(gameObject);
        float preferedDelay = delay;
        if(isAutoDelay){
            preferedDelay = transform.GetSiblingIndex() * delay;
        }
        transform.localScale = Vector3.one * targetScale;
        LeanTween.scale(gameObject, Vector2.one * 0, leanTime).setEaseInSine().setDelay(preferedDelay).setIgnoreTimeScale(true).setOnComplete(()=>{
            if(onEnable) gameObject.SetActive(false);
        });
    }
}
