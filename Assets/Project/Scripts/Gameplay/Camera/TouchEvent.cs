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
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.tag == "Yard")
                {
                    foreach (GameObject playerYard in YardPlayerController.Instance.PlayerYards)
                    {
                        if (playerYard.name != hit.collider.gameObject.name)
                        {
                            playerYard.GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }
                    
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    public void DeSelected()
    {
        objSelected.localPosition = Vector2.zero;
        SwitchYard(false);
    }

    public void Selected()
    {
        objSelected = pressToSelect.Selectables[0].gameObject.transform;
        SwitchYard(true);
    }

    private void SwitchYard(bool switchable)
    {
        foreach (GameObject playerYard in YardPlayerController.Instance.PlayerYards)
        {
            playerYard.GetComponent<BoxCollider2D>().enabled = switchable;
            playerYard.GetComponent<SpriteRenderer>().enabled = switchable;
        }
    }
}