using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character Character;
    
    public RunState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }

    public void Enter()
    {
        Debug.Log("Enter RunState");
        SubscribeToCharacterEvents();
    }

    public void Exit()
    {
        UnsubscribeFromCharacterEvents();
    }

    public void HandleInput()
    {
    }

    public void Update()
    {
    }
    
    private void SubscribeToCharacterEvents()
    {
        Character.FinishReached += OnFinishReached;
    }
    
    private void UnsubscribeFromCharacterEvents()
    {
        Character.FinishReached -= OnFinishReached;
    }

    private void OnFinishReached()
    {
        StateSwitcher.SwitchState<EndState>();
    }
}
