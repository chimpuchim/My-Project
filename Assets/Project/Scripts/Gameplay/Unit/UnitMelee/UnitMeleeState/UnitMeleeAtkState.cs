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
        unitMeleeController.UnitMeleeModel.Agent.enabled = false;
    }

    public void Update()
    {
        
    }

    public void FixUpdate()
    {
        if (unitMeleeController.DistanceToTarget > unitMeleeController.DistanceAttack)
        {
            unitMeleeController.StateMachine.ChangeState(new UnitMeleeRunState(unitMeleeController));
        }
        else
        {
            unitMeleeController.UnitMeleeAttack.AttackNor();
        }
    }

    public void Exit()
    {
        
    }
}
