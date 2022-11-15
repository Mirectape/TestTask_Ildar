using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressedDetection : MonoBehaviour
{
    public static Action<Vector2> KeyPressedEvent;

    private void OnKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            KeyPressedEvent(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            KeyPressedEvent(Vector2.right);
        }
    }

    private void Update()
    {
        OnKeyPressed();
    }
}
