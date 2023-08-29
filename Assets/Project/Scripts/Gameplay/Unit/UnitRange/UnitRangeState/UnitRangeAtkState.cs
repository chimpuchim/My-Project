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
        
    }

    public void FixUpdate()
    {
        unitRangeController.UnitRangeAttack.AttackNor();
    }

    public void Exit()
    {
        
    }
}
