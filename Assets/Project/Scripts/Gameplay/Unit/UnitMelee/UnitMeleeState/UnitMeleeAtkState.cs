public class UnitMeleeAtkState : IUnitState
{
    private UnitMeleeController unitMeleeController;

    public UnitMeleeAtkState(UnitMeleeController unitMeleeController)
    {
        this.unitMeleeController = unitMeleeController;
    }
    
    public void Enter()
    {
        unitMeleeController.UnitMeleeModel.ChangeAnimation("Attack", 1f);
    }

    public void Update()
    {
        if (unitMeleeController.DistanceToTarget > unitMeleeController.DistanceAttack)
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeRunState(unitMeleeController));
        }

        if (unitMeleeController.IsDead)
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeDieState(unitMeleeController));
        }
    }

    public void FixUpdate()
    {
        
    }

    public void Exit()
    {
        
    }
}
