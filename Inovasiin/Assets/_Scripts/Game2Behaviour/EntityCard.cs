using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class EntityCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public EndemicInformation information{
        get{return _information;}
        set{
            cardImage.sprite = value.entitySprite;
            _information = value;
        }
    }
    EndemicInformation _information;
    public RectTransform rectTransform;
    [HideInInspector] public RectTransform placeholder = null;
    [HideInInspector] public EndemikHolder holder;
    
    [Header("Properties")]
    public Image cardImage;

    private bool isStick = true;
    private Vector2 _currentVelo;

    private void Update() {
        if(isStick && placeholder != null){
            rectTransform.anchoredPosition = 
                Vector2.SmoothDamp(rectTransform.anchoredPosition, placeholder.anchoredPosition, ref _currentVelo, 0.2f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.rotation = Quaternion.identity;
        placeholder.gameObject.SetActive(false);
        isStick = false;
        EndemikHolder.CardHolded = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(holder.CheckMap()){
            Release();
            holder.Success(eventData.position, information.information);
            SoundSystem.Instance.Play(AudioType.Success);
        }else{
            SoundSystem.Instance.Play(AudioType.Lose);
            Back();
        }
        EndemikHolder.CardHolded = null;
    }

    void Back(){
        placeholder.gameObject.SetActive(true);
        isStick = true;
    }

    internal void Release()
    {
        placeholder.gameObject.SetActive(false);
        holder.DrawMore();
        Destroy(gameObject);
    }
}
