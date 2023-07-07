using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform bound;
    [SerializeField] private RectTransform analog;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private MainInputController inputController;
    public void OnDrag(PointerEventData eventData){
        Vector2 _inputVal;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bound, eventData.position, eventData.pressEventCamera, out _inputVal)){
            inputController.moveInput = _inputVal / (bound.sizeDelta/2f);
            if(inputController.moveInput.magnitude >= 1f){
                inputController.moveInput = inputController.moveInput.normalized;
            }
            analog.anchoredPosition = new Vector2(
                inputController.moveInput.x * bound.sizeDelta.x/2f,
                inputController.moveInput.y * bound.sizeDelta.y/2f
                );
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        OnDrag(eventData);
        canvasGroup.alpha = 1f;
    }
    public void OnPointerUp(PointerEventData eventData){
        inputController.moveInput = Vector2.zero;
        analog.anchoredPosition = Vector2.zero;
        canvasGroup.alpha = 0.7f;
    }
}
