using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character Character;
    
    protected CharacterView View => Character.View;
    
    public CharacterState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }
    
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void Update()
    {
    }
    
    protected virtual void AddInputActionsCallbacks() { }
    protected virtual void RemoveInputActionsCallbacks() { }
}
