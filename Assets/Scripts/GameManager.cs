using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController _character;
    
    private PlayerInput _input;
    private GameStateMachine _gameStateMachine;
    
    public PlayerInput Input => _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _character.Init();
        _gameStateMachine = new GameStateMachine(_character);
    }
}
