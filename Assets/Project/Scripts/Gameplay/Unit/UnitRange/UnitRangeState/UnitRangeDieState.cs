public class UnitRangeDieState : IUnitState
{
    private UnitRangeController unitRangeController;

    public UnitRangeDieState(UnitRangeController unitRangeController)
    {
        this.unitRangeController = unitRangeController;
    }
    
    public void Enter()
    {
        unitRangeController.UnitRangeModel.ChangeAnimation("Die", 1f);
        unitRangeController.UnitRangeModel.BoxCollider2D.enabled = false;
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
