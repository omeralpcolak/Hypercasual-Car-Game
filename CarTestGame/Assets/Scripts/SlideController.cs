using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideController : MonoBehaviour
{
    public float moveX = 0 ;    
    
    public RectTransform positioner ;
    private float prevPosX = 0f ;
    
    public void onControllerPressDown(BaseEventData _e) {
        PointerEventData _p = _e as PointerEventData ;
        positioner.position = _p.position ;
        prevPosX = positioner.anchoredPosition.x ;
    }
    public void onControllerPressDrag(BaseEventData _e) {
        PointerEventData _p = _e as PointerEventData ;
        positioner.position = _p.position ;

        moveX = (positioner.anchoredPosition.x - prevPosX) ;
        prevPosX = positioner.anchoredPosition.x ;        
        
    }
    public void onControllerPressUp(BaseEventData _e) {
        PointerEventData _p = _e as PointerEventData ;
        moveX = 0;
    }
    
    void FixedUpdate() {
        moveX = 0f ;
    }
}
