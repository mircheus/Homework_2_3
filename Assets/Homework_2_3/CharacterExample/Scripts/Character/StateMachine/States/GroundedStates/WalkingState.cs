using UnityEngine.InputSystem;

public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher,
        data, character) => _config = character.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.WalkSpeed;
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
        Input.Movement.Walk.canceled += OnWalkKeyReleased;
    }
    
    protected override void RemoveInputActionsCallbacks()
    {
        Input.Movement.Walk.canceled -= OnWalkKeyReleased;
    }

    private void OnWalkKeyReleased(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();
}
