using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    protected readonly StateMachineData Data;
    
    public RunState(StateMachineData data)
    {
        Data = data;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}
