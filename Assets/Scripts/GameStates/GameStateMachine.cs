using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : IStateSwitcher
{
    private List<IState> _states = new List<IState>();
    private IState _currentState;

    public GameStateMachine(CharacterController character)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new PreparingState(data, character)
        };
        
        _currentState = _states[0];
        _currentState.Enter();
    }
    
    public void SwitchState<T>() where T : IState
    {
        throw new System.NotImplementedException();
    }
    
    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
