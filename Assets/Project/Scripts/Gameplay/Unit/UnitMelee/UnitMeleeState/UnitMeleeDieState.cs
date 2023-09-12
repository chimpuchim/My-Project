using System.Collections;
using UnityEngine;

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
        
        unitMeleeController.StartCoroutine(TurnOffGameObjectAfterDelay(1f));

        if (unitMeleeController.UnitMeleeModel.CompareTag("Enemy"))
        {
            GameController.Instance.CoinLevel += unitMeleeController.UnitMoney.Money;
        }

        unitMeleeController.UnitMeleeModel.Agent.speed = 0;
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
        unitMeleeController.UnitMeleeModel.gameObject.SetActive(false);
        PlayerController.Instance.FindAndAddPlayers();
        EnemyController.Instance.FindAndAddEnemies();
    }
}
