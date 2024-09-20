using UnityEngine;
using UnityEngine.InputSystem;

public class PreparingState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly CharacterController character;
    
    public PreparingState(IStateSwitcher stateSwitcher, StateMachineData data, CharacterController characterController)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        character = characterController;
    }

    public void Enter()
    {
        AddInputActionsCallbacks();
    }

    public void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public void HandleInput()
    {
    }

    public void Update()
    {
    }
    
    protected virtual void AddInputActionsCallbacks()
    {
        character.ClickAction.performed += OnInteracted;
    }
    
    protected virtual void RemoveInputActionsCallbacks()
    {
        character.ClickAction.performed -= OnInteracted;
    }
    
    private void OnInteracted(InputAction.CallbackContext context)
    {
        StateSwitcher.SwitchState<RunState>();
    }
}
