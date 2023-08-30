public class UnitMeleeRunState : IUnitState
{
    private UnitMeleeController unitMeleeController;

    public UnitMeleeRunState(UnitMeleeController unitMeleeController)
    {
        this.unitMeleeController = unitMeleeController;
    }
    
    public void Enter()
    {
        unitMeleeController.UnitMeleeModel.ChangeAnimation("Run", 1);
        unitMeleeController.UnitMeleeModel.Agent.enabled = true;
    }

    public void Update()
    {
        if (unitMeleeController.IsDead)
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeDieState(unitMeleeController));
        }
    }

    public void FixUpdate()
    {
        if (unitMeleeController.DistanceToTarget > unitMeleeController.DistanceAttack)
        {
            unitMeleeController.UnitMeleeMovement.Movement(unitMeleeController.TargetPos.position);
        }
        else
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeAtkState(unitMeleeController));
            unitMeleeController.UnitMeleeModel.Agent.enabled = false;
        }
    }

    public void Exit()
    {
        
    }
}
