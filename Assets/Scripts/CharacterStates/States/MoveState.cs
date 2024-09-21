using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveState : CharacterState
{
    protected CharacterView View => Character.View;
    
    private InputAction _steerAction;
    private float _limitValue;
    private float _xPosition;

    public MoveState(IStateSwitcher stateSwitcher, StateMachineData data, Character character): base(stateSwitcher, data, character)
    {
    }
    
    public override void Enter()
    {
        View.StartMoving();
        _limitValue = Character.SteeringLimitValue;
        _steerAction = Character.Input.Player.Steering;
        Character.CharacterTrigger.FinishTriggered += OnFinishTriggered;
    }

    public override void Exit()
    {
        View.StopMoving();
        Character.CharacterTrigger.FinishTriggered -= OnFinishTriggered;
    }

    public override void HandleInput()
    {
        _xPosition = CalculateXPosition();
    }

    public override void Update()
    {
        MoveAlongXAxis();
        MoveForward();
    }
    
    private float CalculateXPosition()
    {
        float xPos = _steerAction.ReadValue<Vector2>().x;
        float halfScreen = Screen.width / 2;
        float inputValue = (xPos - halfScreen) / halfScreen;
        float resultXPosition = Mathf.Clamp(inputValue * _limitValue, -_limitValue, _limitValue);
        return resultXPosition;
    }
    
    private void MoveAlongXAxis()
    {
        var transform = Character.transform;
        var localPosition = transform.localPosition;
        transform.localPosition = new Vector3(_xPosition, localPosition.y, localPosition.z);
    }
    
    private void MoveForward()
    {
        Character.transform.Translate(Vector3.forward * (Character.MoveSpeed * Time.deltaTime));
    }
    
    private void OnFinishTriggered()
    {
        StateSwitcher.SwitchState<DanceState>();
    }
}
