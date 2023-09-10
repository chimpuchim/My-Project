using UnityEngine;

public class UnitMeleeWinState : IUnitState
{
    private UnitMeleeController unitMeleeController;

    public UnitMeleeWinState(UnitMeleeController unitMeleeController)
    {
        this.unitMeleeController = unitMeleeController;
    }
    
    public void Enter()
    {
        unitMeleeController.UnitMeleeModel.ChangeAnimation("Win", 1f);
    }

    public void Update()
    {
        
    }

    public void FixUpdate()
    {
        
    }

    public void Exit()
    {
        
    }
}
