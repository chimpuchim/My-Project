using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    [SerializeField] private LeanSelectByFinger pressToSelect;
    [SerializeField] private Transform objSelected;
    
    public void DetectCastObj()
    {
        RaycastHit2D[] hits;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        hits = Physics2D.RaycastAll(mousePosition, Vector2.zero, Mathf.Infinity);

        if (hits.Length > 0)
        {
            List<GameObject> hitObjects = new List<GameObject>();

            foreach (RaycastHit2D hit in hits)
            {
                hitObjects.Add(hit.collider.gameObject);
            }

            Debug.Log("Hit objects count: " + hitObjects.Count);
        }
    }

    public void DeSelected()
    {
        objSelected.localPosition = Vector2.zero;
        SwitchColliderYard(false);
    }

    public void Selected()
    {
        objSelected = pressToSelect.Selectables[0].gameObject.transform;
        SwitchColliderYard(true);
    }

    private void SwitchColliderYard(bool switchable)
    {
        foreach (BoxCollider2D playerYard in YardPlayerController.Instance.PlayerYards)
        {
            playerYard.enabled = switchable;
        }
    }
}