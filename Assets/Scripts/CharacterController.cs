using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private InputActionAsset _playerControls;
    [SerializeField] private float _limitValue;
    [SerializeField] private Transform _characterTransform;
    
    private InputAction _steerAction;
    private InputAction _clickAction;
    
    public InputAction ClickAction => _clickAction;
    
    private void OnEnable()
    {
        _steerAction.Enable();
        _clickAction.Enable();
    }

    private void OnDisable()
    {
        _steerAction.Disable();
        _clickAction.Disable();
    }
    
    private void Update()
    {
        float xPosition = CalculateXPosition();
        _characterTransform.transform.localPosition = new Vector3(xPosition, 0, 0);
    }

    public void Init()
    {
        var playerActionMap = _playerControls.FindActionMap("Player");
        _steerAction = playerActionMap.FindAction("Steering");
        _clickAction = playerActionMap.FindAction("Click");
    }

    private float CalculateXPosition()
    {
        float xPos = _steerAction.ReadValue<Vector2>().x;
        float halfScreen = Screen.width / 2;
        float inputValue = (xPos - halfScreen) / halfScreen;
        float resultXPosition = Mathf.Clamp(inputValue * _limitValue, -_limitValue, _limitValue);
        return resultXPosition;
    }
}
