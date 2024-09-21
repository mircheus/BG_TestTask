using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : CharacterState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;
    protected readonly Character Character;
    
    protected CharacterView View => Character.View;
    
    public IdleState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        Character = character;
    }
    
    public override void Enter()
    {
        View.StartIdling();
        AddInputActionsCallbacks();
    }

    public override void Exit()
    {
        View.StopIdling();
        RemoveInputActionsCallbacks();
    }
    
    protected override void AddInputActionsCallbacks()
    {
        Character.Input.Player.Click.performed += OnClick;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        Character.Input.Player.Click.performed -= OnClick;
    }
    
    private void OnClick(InputAction.CallbackContext obj)
    {
        Debug.Log("Clicked!");
        StateSwitcher.SwitchState<MoveState>();
    }
}
