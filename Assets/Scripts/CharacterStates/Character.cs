using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Settings: ")]
    [SerializeField] private float _steeringLimitValue = 1.5f;
    [SerializeField] private float _moveSpeed = 1.5f;
    [Header("References: ")]
    [SerializeField] private CharacterView _view;
    [SerializeField] private CharacterTrigger _characterTrigger;

    private CharacterStateMachine _stateMachine;
    private PlayerInput _input;

    public CharacterView View => _view;
    public PlayerInput Input => _input;
    public float SteeringLimitValue => _steeringLimitValue;
    public float MoveSpeed => _moveSpeed;

    public event Action FinishReached;
    
    private void Awake()
    {
        _view.Initialize();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }
    
    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();        
    }

    private void OnEnable()
    {
        _input.Enable();
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        _input.Disable();
        UnsubscribeFromEvents();
    }
    
    private void SubscribeToEvents()
    {
        _characterTrigger.PickupTriggered += OnPickupTriggered;
    }
    
    private void UnsubscribeFromEvents()
    {
        _characterTrigger.PickupTriggered -= OnPickupTriggered;
    }
    
    private void OnPickupTriggered(int pointsValue, PickupType pickupType)
    {
        _view.OnPickupTriggered(pickupType);
    }
}
