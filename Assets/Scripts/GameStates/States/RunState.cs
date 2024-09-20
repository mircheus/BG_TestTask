using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly CharacterController Character;
    
    public RunState(IStateSwitcher stateSwitcher, StateMachineData data, CharacterController characterController)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = characterController;
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
        MoveCharacter();
    }
    
    private void SubscribeToCharacterEvents()
    {
        Character.FinishReached += OnFinishReached;
    }
    
    private void UnsubscribeFromCharacterEvents()
    {
        Character.FinishReached -= OnFinishReached;
    }
    
    private void MoveCharacter()
    {
        Character.transform.Translate(Vector3.forward * (Character.MoveSpeed * Time.deltaTime));
    }
    
    private void OnFinishReached()
    {
        StateSwitcher.SwitchState<EndState>();
    }
}
