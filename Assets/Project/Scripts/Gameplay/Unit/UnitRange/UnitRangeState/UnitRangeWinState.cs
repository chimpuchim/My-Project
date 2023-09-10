public class UnitRangeWinState : IUnitState
{
    private UnitRangeController unitRangeController;

    public UnitRangeWinState(UnitRangeController unitRangeController)
    {
        this.unitRangeController = unitRangeController;
    }
    
    public void Enter()
    {
        unitRangeController.UnitRangeModel.ChangeAnimation("Win", 1f);
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
