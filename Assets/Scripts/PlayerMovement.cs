using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public int numberOfControllerActivated; // 1 - swipe, 2 - keyboard, 3 - drag
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;
    private bool keyboardIsActivated;
    private bool swipeControlIsActivated;
    private bool dragControlIsActivated;
    
    private void SetDefaultValues()
    {
        ActivateKeyboardControl();
        keyboardIsActivated = true;
        swipeControlIsActivated = false;
        dragControlIsActivated = false;
    }

    /// <summary>
    /// To clean all the settings about the previous movement control
    /// </summary>
    private void DecontrolPlayerMovement()
    {
        if (keyboardIsActivated)
        {
            KeyPressedDetection.KeyPressedEvent -= Move;
            keyboardIsActivated = false;
        }
        if (swipeControlIsActivated)
        {
            SwipeDetection.SwipeEvent -= Move;
            swipeControlIsActivated = false;
        }
        if(dragControlIsActivated)
        {
            DragDetection.DragEvent -= Move;
            dragControlIsActivated = false;
        }
    }

    void Start()
    {
        SetDefaultValues();
    }

    public void ActivateKeyboardControl()
    {
        DecontrolPlayerMovement();
        KeyPressedDetection.KeyPressedEvent += Move;
        keyboardIsActivated = true;
        numberOfControllerActivated = 2;
    }

    public void ActivateSwipeCondrol()
    {
        DecontrolPlayerMovement();
        SwipeDetection.SwipeEvent += Move;
        swipeControlIsActivated = true;
        numberOfControllerActivated = 1;
    }

    public void ActivateDragControl()
    {
        DecontrolPlayerMovement();
        DragDetection.DragEvent += Move;
        dragControlIsActivated = true;
        numberOfControllerActivated = 3;
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        numberOfControllerActivated = data.numberOfControllerActicated;
        ApplyChangesToControllerSettings();
    }

    private void ApplyChangesToControllerSettings()
    {
        if(numberOfControllerActivated == 1)
        {
            ActivateSwipeCondrol();
        }
        else if(numberOfControllerActivated == 2)
        {
            ActivateKeyboardControl();
        }
        else if(numberOfControllerActivated ==3)
        {
            ActivateDragControl();
        }
    }

    private void Move(Vector2 direction)
    {
        if ((_target.position.x < 6) && (_target.position.x > -6))
        {
            _target.transform.position = Vector2.MoveTowards(_target.transform.position, (Vector2)_target.transform.position + direction, 1f);
        }
        else if(_target.position.x >= 6)
        {
            _target.transform.position = Vector2.right * 5f;
        }
        else if(_target.position.x <= -6)
        {
            _target.transform.position = Vector2.left * 5f;
        }
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
    }

    
}
