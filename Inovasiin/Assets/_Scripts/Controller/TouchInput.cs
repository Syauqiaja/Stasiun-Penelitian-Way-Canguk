using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MainInputController mainInput;
    PointerEventData t_eventData = null;
    float HALF_SCREEN;

    public void OnPointerDown(PointerEventData eventData)
    {
       if(t_eventData != null) return;
        mainInput.isLooking = true;
        t_eventData = eventData;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(t_eventData.pointerId != eventData.pointerId) return;
        mainInput.isLooking = false;
        t_eventData = null;
    }
    private void Update() {
        if(t_eventData != null){
            if(t_eventData.IsPointerMoving()){
                mainInput.lookInput = t_eventData.delta;
            }else{
                mainInput.lookInput = Vector2.zero;
            }
        }
    }

    
    
    // private void Update() {
    //     for(int i=0; i<Input.touchCount; i++){
    //         Touch t = Input.GetTouch(i);
    //         switch (t.phase)
    //         {
    //             case TouchPhase.Began:
    //                 if(t.position.x > HALF_SCREEN&& !mainInput.isLooking){
    //                     rt_id = t.fingerId;
    //                     mainInput.isLooking = true;
    //                 }
    //                 break;
    //             case TouchPhase.Ended:
    //             case TouchPhase.Canceled:
    //                 if(t.fingerId == rt_id) mainInput.isLooking = false;
    //                 break;
    //             case TouchPhase.Moved:
    //                 if(t.fingerId == rt_id){
    //                     mainInput.lookInput = t.deltaPosition;
    //                 }
    //                 break;
    //             case TouchPhase.Stationary:
    //                 if(t.fingerId == rt_id){
    //                     mainInput.lookInput = Vector2.zero;
    //                 }
    //                 break;
    //         }
    //     }
    // }
    
}
