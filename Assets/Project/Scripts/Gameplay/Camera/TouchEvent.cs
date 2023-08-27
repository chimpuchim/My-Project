using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lean.Touch;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    [SerializeField] private LeanSelectByFinger pressToSelect;
    [SerializeField] private Transform objSelected;
    [SerializeField] private Transform yardTouch;
    
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
                    foreach (GameObject playerYard in PlayerYardController.Instance.PlayerYards)
                    {
                        if (playerYard.name != hit.collider.gameObject.name)
                        {
                            playerYard.GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }

                    yardTouch = hit.transform;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    public void Selected()
    {
        objSelected = pressToSelect.Selectables[0].gameObject.transform;
        YardControl(true);
    }
    
    public void DeSelected()
    {
        objSelected.localPosition = Vector2.zero;
        YardControl(false);
        SwitchUnitYard();
        PlayerYardController.Instance.YardEmptyToList();
    }

    private void SwitchUnitYard()
    {
        PlayerYard playerYard = yardTouch.GetComponent<PlayerYard>();

        SwitchUnitToEmpty(objSelected.parent.name, playerYard);
        SwitchUnitToNoneEmpty(objSelected.parent, playerYard);
    }

    private void SwitchUnitToEmpty(string objectSelectedName, PlayerYard playerYard)
    {
        if (CheckYardTouchEmpty(yardTouch))
        {
            SwitchUnitVisibility(playerYard.MeleeUnits, objectSelectedName);
            SwitchUnitVisibility(playerYard.RangeUnits, objectSelectedName);
        }
    }
    
    private void SwitchUnitToNoneEmpty(Transform objectSelected, PlayerYard playerYard)
    {
        if (!CheckYardTouchEmpty(yardTouch) && yardTouch.gameObject.name != objSelected.parent.parent.parent.name)
        {
            SwitchUnitMerge();
        }
    }
    
    private void SwitchUnitMerge()
    {
        PlayerYard playerYard = yardTouch.GetComponent<PlayerYard>();
        if (playerYard.UnitActive != null)
        {
            if (playerYard.UnitActive.name == objSelected.parent.name)
            {
                string numberUnit = Regex.Match(objSelected.parent.name, @"\d+").Value;
                string typeUnit = objSelected.parent.name.Substring(0, Mathf.Min(5, objSelected.parent.name.Length));
                
                if (typeUnit == "Melee")
                {
                    if (int.Parse(numberUnit) >= playerYard.MeleeUnits.Count)
                    {
                        Debug.Log("Max level");
                        return;
                    }
                    
                    playerYard.MeleeUnits[int.Parse(numberUnit)].SetActive(true);
                    playerYard.MeleeUnits[int.Parse(numberUnit) - 1].SetActive(false);
                    objSelected.parent.gameObject.SetActive(false);
                }
                
                if (typeUnit == "Range")
                {
                    if (int.Parse(numberUnit) >= playerYard.RangeUnits.Count)
                    {
                        Debug.Log("Max level");
                        return;
                    }
                    
                    playerYard.RangeUnits[int.Parse(numberUnit)].SetActive(true);
                    playerYard.RangeUnits[int.Parse(numberUnit) - 1].SetActive(false);
                    objSelected.parent.gameObject.SetActive(false);
                }
            }
        }
    }
    
    private void SwitchUnitVisibility(List<GameObject> units, string objectSelectedName)
    {
        foreach (GameObject unit in units)
        {
            if (objectSelectedName == unit.name)
            {
                unit.SetActive(true);
                objSelected.parent.gameObject.SetActive(false);
                return;
            }
        }
    }

    private bool CheckYardTouchEmpty(Transform yardTouch)
    {
        foreach (GameObject playerYardEmpty in PlayerYardController.Instance.PlayerYardsEmpty)
        {
            if (yardTouch.gameObject.name == playerYardEmpty.gameObject.name)
            {
                return true;
            }
        }
        
        return false;
    }

    private void YardControl(bool switchable)
    {
        foreach (GameObject playerYard in PlayerYardController.Instance.PlayerYards)
        {
            playerYard.GetComponent<BoxCollider2D>().enabled = switchable;
            playerYard.GetComponent<SpriteRenderer>().enabled = switchable;
        }
    }
}