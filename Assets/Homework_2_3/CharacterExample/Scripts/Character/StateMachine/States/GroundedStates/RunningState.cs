using UnityEngine.InputSystem;

public class RunningState : GroundedState
{
    private readonly RunningStateConfig _config;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit(); 

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();
        
        Input.Movement.Sprint.started += OnSprintKeyPressed;
        Input.Movement.Walk.started += OnWalkKeyPressed;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        base.RemoveInputActionsCallbacks();
        
        Input.Movement.Sprint.started -= OnSprintKeyPressed;
        Input.Movement.Walk.started -= OnWalkKeyPressed;
    }


    private void OnSprintKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<SprintState>();
    private void OnWalkKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<WalkingState>();
}
