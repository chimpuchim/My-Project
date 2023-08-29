public class UnitMeleeIdleState : IUnitState
{
    private UnitMeleeController unitMeleeController;

    public UnitMeleeIdleState(UnitMeleeController unitMeleeController)
    {
        this.unitMeleeController = unitMeleeController;
    }
    
    public void Enter()
    {
        unitMeleeController.UnitMeleeModel.ChangeAnimation("Idle", 1);
    }

    public void Update()
    {
        
    }

    public void FixUpdate()
    {
        if (GameController.Instance.IsStartBattle)
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeRunState(unitMeleeController));
        }
    }

    public void Exit()
    {
        
    }
}
