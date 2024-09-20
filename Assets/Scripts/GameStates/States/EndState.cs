using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly CharacterController Character;
    
    public EndState(IStateSwitcher stateSwitcher, StateMachineData data, CharacterController characterController)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = characterController;
    }
    
    public void Enter()
    {
        Debug.Log("enter EndState");
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
