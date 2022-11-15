using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDetection : MonoBehaviour, IDragHandler
{
    public static Action<Vector2> DragEvent;

    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    private float _mouseXPosition;

    public void OnDrag(PointerEventData eventData)
    {
            _mouseXPosition = _camera.ScreenToWorldPoint(eventData.position).x;
            DragEvent(new Vector2(_mouseXPosition - _target.position.x, 0));
    }

}
