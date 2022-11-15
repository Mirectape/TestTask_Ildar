using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetection : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public static Action<Vector2> SwipeEvent;

    private bool _isSwiping;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isSwiping = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isSwiping)
        {
            if (SwipeEvent != null)
            {
                SwipeEvent(eventData.delta.x > 0 ? Vector2.right : Vector2.left);
                _isSwiping = false;
            }
        }
    }
}
