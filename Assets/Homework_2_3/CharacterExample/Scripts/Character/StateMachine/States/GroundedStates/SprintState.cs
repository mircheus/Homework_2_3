using UnityEngine;
using UnityEngine.InputSystem;

public class SprintState : GroundedState
{
    private readonly SprintStateConfig _config;

    public SprintState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher,
        data, character) => _config = character.Config.SprintStateConfig;
    
    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.SprintSpeed;
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
        }
    }

    protected override void AddInputActionsCallbacks()
    {
        Input.Movement.Sprint.canceled += OnSprintKeyReleased;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        Input.Movement.Sprint.canceled -= OnSprintKeyReleased;
    }
    
    private void OnSprintKeyReleased(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
}