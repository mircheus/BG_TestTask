using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceState : CharacterState
{
    public DanceState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
    
    public override void Enter()
    {
        Character.View.StartDancing();
    }
    
    public override void Exit()
    {
        Character.View.StopDancing();
    }
    
    public override void HandleInput()
    {
    }
    
    public override void Update()
    {
    }
}