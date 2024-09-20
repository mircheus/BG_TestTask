using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character Character;
    
    public EndState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }
    
    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void HandleInput()
    {
    }

    public void Update()
    {
    }
}
