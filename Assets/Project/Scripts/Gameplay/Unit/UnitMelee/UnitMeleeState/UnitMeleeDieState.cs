public class UnitMeleeDieState : IUnitState
{
    private UnitMeleeController unitMeleeController;

    public UnitMeleeDieState(UnitMeleeController unitMeleeController)
    {
        this.unitMeleeController = unitMeleeController;
    }
    
    public void Enter()
    {
        unitMeleeController.UnitMeleeModel.ChangeAnimation("Die", 1f);
        unitMeleeController.UnitMeleeModel.BoxCollider2D.enabled = false;
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
