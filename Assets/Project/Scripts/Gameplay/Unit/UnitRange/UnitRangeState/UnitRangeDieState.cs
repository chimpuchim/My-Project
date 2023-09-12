using System.Collections;
using UnityEngine;


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
        
        unitRangeController.StartCoroutine(TurnOffGameObjectAfterDelay(1f));

        if (unitRangeController.UnitRangeModel.CompareTag("Enemy"))
        {
            GameController.Instance.CoinLevel += unitRangeController.UnitMoney.Money;
        }
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
    
    private IEnumerator TurnOffGameObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        unitRangeController.UnitRangeModel.gameObject.SetActive(false);
        PlayerController.Instance.FindAndAddPlayers();
        EnemyController.Instance.FindAndAddEnemies();
    }
}
