using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateMachine : IStateSwitcher
{
    private List<IState> _states = new List<IState>();
    private IState _currentState;

    public GameStateMachine(Character character)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new PreparingState(this, data, character),
            new RunState(this, data, character),
            new EndState(this, data, character)
        };
        
        _currentState = _states[0];
        _currentState.Enter();
    }
    
    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
    
    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
