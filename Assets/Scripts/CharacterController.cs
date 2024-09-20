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

    private void Awake()
    {
        var playerActionMap = _playerControls.FindActionMap("Player");
        _steerAction = playerActionMap.FindAction("Steering");
    }
    
    private void OnEnable()
    {
        _steerAction.Enable();
    }

    private void OnDisable()
    {
        _steerAction.Disable();
    }
    
    private void Update()
    {
        float xPosition = CalculateXPosition();
        _characterTransform.transform.localPosition = new Vector3(xPosition, 0, 0);
    }

    private float CalculateXPosition()
    {
        float xPos = _steerAction.ReadValue<Vector2>().x;
        float halfScreen = Screen.width / 2;
        float inputValue = (xPos - halfScreen) / halfScreen;
        float resultXPosition = Mathf.Clamp(inputValue * _limitValue, -_limitValue, _limitValue);
        Debug.Log("X Position: " + inputValue);
        return resultXPosition;
    }
}
