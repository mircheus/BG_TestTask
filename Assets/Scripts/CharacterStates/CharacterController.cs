using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private InputActionAsset _playerControls;
    [SerializeField] private float _limitValue;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private ParticleSystem _moneyVfx;
    [SerializeField] private ParticleSystem _bottleVfx;

    private CharacterTrigger _characterTrigger;
    private InputAction _steerAction;
    private InputAction _clickAction;

    public event UnityAction FinishReached;

    public InputAction ClickAction => _clickAction;
    public float MoveSpeed => moveSpeed;

    private void OnEnable()
    {
        _steerAction.Enable();
        _clickAction.Enable();
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        _steerAction.Disable();
        _clickAction.Disable(); 
        UnsubscribeFromEvents();
    }
    
    private void Update()
    {
        float xPosition = CalculateXPosition();
        _characterTransform.transform.localPosition = new Vector3(xPosition, 0, 0);
    }

    public void Init()
    {
        var playerActionMap = _playerControls.FindActionMap("Player");
        _characterTrigger = GetComponentInChildren<CharacterTrigger>();
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
    
    private void SubscribeToEvents()
    {
        _characterTrigger.FinishTriggered += OnFinishReached;
        _characterTrigger.PickupTriggered += OnPickupTriggered;
    }
    
    private void UnsubscribeFromEvents()
    {
        _characterTrigger.FinishTriggered -= OnFinishReached;
        _characterTrigger.PickupTriggered -= OnPickupTriggered;
    }
    
    private void OnFinishReached()
    {
        FinishReached?.Invoke();
    }
    
    private void OnPickupTriggered(int points, PickupType pickupType)
    {
        switch (pickupType)
        {
            case PickupType.Money:
                _moneyVfx.Play();
                break;
            
            case PickupType.Bottle:
                _bottleVfx.Play();
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
