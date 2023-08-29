public class UnitRangeIdleState : IUnitState
{
    private UnitRangeController unitRangeController;

    public UnitRangeIdleState(UnitRangeController unitRangeController)
    {
        this.unitRangeController = unitRangeController;
    }
    
    public void Enter()
    {
        unitRangeController.UnitRangeModel.ChangeAnimation("Idle", 1);
    }

    public void Update()
    {
        
    }

    public void FixUpdate()
    {
        if (GameController.Instance.IsStartBattle)
        {
            unitRangeController.StateMachine.ChangeState(new UnitRangeAtkState(unitRangeController));
        }
    }

    public void Exit()
    {
        
    }
}
