using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Habit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public HabitCode code;
    public RectTransform rectTransform;
    public Outline outline;

    public void Failure(){
        LeanTween.value(gameObject, Color.clear, Color.red, 0.5f)
            .setLoopPingPong(1)
            .setEaseOutSine()
            .setOnUpdateColor((color)=>{
                outline.effectColor = color;
            });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
        EndemikHolder.habitHovered = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
        EndemikHolder.habitHovered = null;
    }

    public void Success(){
        LeanTween.value(gameObject, Color.clear, Color.green, 0.5f)
            .setLoopPingPong(1)
            .setEaseOutSine()
            .setOnUpdateColor((color)=>{
                outline.effectColor = color;
            });
    }
}
