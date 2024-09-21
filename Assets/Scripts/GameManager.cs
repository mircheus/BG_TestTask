using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private PointsView _pointsView;
    
    private PlayerInput _input;
    private GameStateMachine _gameStateMachine;
    
    public PlayerInput Input => _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _gameStateMachine = new GameStateMachine(_character);
    }
    
    private void Update()
    {
        _gameStateMachine.HandleInput();
        _gameStateMachine.Update();
    }

    private void OnEnable()
    {
        SubscribeToEvents();
    }
    
    private void OnDisable()
    {
        UnsuscribeFromEvents();
    }

    private void SubscribeToEvents()
    {
        _character.PointsChanged += OnPointsChanged;
    }
    
    private void UnsuscribeFromEvents()
    {
        _character.PointsChanged -= OnPointsChanged;
    }

    private void OnPointsChanged(int points)
    {
        _pointsView.SetPoints(points);
    }
}
