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
        }
    }

    public void Exit()
    {
        
    }
}
