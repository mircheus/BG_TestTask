using UnityEngine;
using UnityEngine.InputSystem;

public class PreparingState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character character;
    
    public PreparingState(IStateSwitcher stateSwitcher, StateMachineData data, Character characterControllerRefactoring)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        character = characterControllerRefactoring;
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
        character.Input.Player.Click.performed += OnClicked;
    }
    
    protected virtual void RemoveInputActionsCallbacks()
    {
        character.Input.Player.Click.performed -= OnClicked;
    }
    
    private void OnClicked(InputAction.CallbackContext context)
    {
        StateSwitcher.SwitchState<RunState>();
    }
}
