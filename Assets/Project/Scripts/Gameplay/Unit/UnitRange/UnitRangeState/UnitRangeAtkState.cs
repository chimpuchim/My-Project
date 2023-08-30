using UnityEngine;

public class UnitRangeAtkState : IUnitState
{
    private UnitRangeController unitRangeController;

    public UnitRangeAtkState(UnitRangeController unitRangeController)
    {
        this.unitRangeController = unitRangeController;
    }
    
    public void Enter()
    {
        unitRangeController.UnitRangeModel.ChangeAnimation("Attack", 1);
    }

    public void Update()
    {
        if (unitRangeController.IsDead)
        {
            unitRangeController.StateMachine.ChangeState(new UnitRangeDieState(unitRangeController));
        }
    }

    public void FixUpdate()
    {
        
    }

    public void Exit()
    {
        
    }
}
