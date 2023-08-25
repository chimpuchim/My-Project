using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitRangeController : UnitController
{
    [SerializeField] private UnitRangeAttack unitRangeAttack;
    public UnitRangeAttack UnitRangeAttack
    {
        get => unitRangeAttack;
    }
    
    [SerializeField] private UnitModel unitModel;
    public UnitModel UnitModel
    {
        get => unitModel;
    }
    
    private void Start()
    {
        DetectTargetPos();
    }
    
    private void Update()
    {
        CheckRotateModel();
    }

    private void DetectTargetPos()
    {
        Transform nearestObject = null;
        float closestDistance = Mathf.Infinity;
    
        List<Transform> targetTransforms = unitModel.gameObject.CompareTag("Player") ?
            EnemyController.Instance.EnemyUnits.ConvertAll(enemy => enemy.transform) :
            PlayerController.Instance.PlayerUnits.ConvertAll(player => player.transform);

        foreach (Transform targetTransform in targetTransforms)
        {
            float distance = Vector3.Distance(unitModel.transform.position, targetTransform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestObject = targetTransform;
            }
        }

        targetPos = nearestObject;
    }

    private void CheckRotateModel()
    {
        if (targetPos != null)
        {
            float direction = Mathf.Sign(targetPos.position.x - unitModel.transform.position.x);
            string side = direction > 0 ? "right" : "left";
    
            if (side == "left")
            {
                unitModel.transform.localScale = new Vector3(-Mathf.Abs(unitModel.transform.localScale.x), unitModel.transform.localScale.y, unitModel.transform.localScale.z);
            }
            else
            {
                unitModel.transform.localScale = new Vector3(Mathf.Abs(unitModel.transform.localScale.x), unitModel.transform.localScale.y, unitModel.transform.localScale.z);
            }
        }
    }
}
