using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Settings: ")]
    [SerializeField] private float _steeringLimitValue = 1.5f;
    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private int _requiredPointsFor1stLvlUp = 10;
    [SerializeField] private int _requiredPointsFor2ndLvlUp = 20;
    [SerializeField] private int _requiredPointsFor3ndLvlUp = 20;
    
    
    [Header("References: ")]
    [SerializeField] private CharacterView _view;
    [SerializeField] private CharacterTrigger _characterTrigger;

    private CharacterStateMachine _stateMachine;
    private PlayerInput _input;
    private int _points;

    public CharacterView View => _view;
    public PlayerInput Input => _input;
    public CharacterTrigger CharacterTrigger => _characterTrigger;
    public float SteeringLimitValue => _steeringLimitValue;
    public float MoveSpeed => _moveSpeed;

    public event Action FinishReached;
    public event Action<int> PointsChanged;
    
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
        _characterTrigger.FinishTriggered += OnFinishTriggered;
    }
    
    private void UnsubscribeFromEvents()
    {
        _characterTrigger.PickupTriggered -= OnPickupTriggered;
        _characterTrigger.FinishTriggered -= OnFinishTriggered;
    }
    
    private void OnPickupTriggered(int pointsValue, PickupType pickupType)
    {
        _view.OnPickupTriggered(pickupType);
        _points += pointsValue;
        PointsChanged?.Invoke(_points);
        ChangeSkinIfRequired(_points);
    }

    private void OnFinishTriggered()
    {
        FinishReached?.Invoke();
    }
    
    private void ChangeSkinIfRequired(int currentPoints)
    {
        if (currentPoints >= _requiredPointsFor1stLvlUp)
        {
            _view.ChangeToNextSkin();
        }
        
        if (currentPoints >= _requiredPointsFor2ndLvlUp)
        {
            _view.ChangeToNextSkin();
        }
        
        if (currentPoints >= _requiredPointsFor3ndLvlUp)
        {
            _view.ChangeToNextSkin();
        }
    }
}
