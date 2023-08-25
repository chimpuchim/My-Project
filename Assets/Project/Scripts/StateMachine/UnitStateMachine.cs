public class UnitStateMachine
{
    private IUnitState currentState;

    public void ChangeState(IUnitState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    public void UpdateCurrentState()
    {
        if (currentState != null)
            currentState.Update();
    }
}
