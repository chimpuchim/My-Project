using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerYard : MonoBehaviour
{
    [SerializeField] private List<GameObject> meleeUnits;
    public List<GameObject> MeleeUnits
    {
        get => meleeUnits;
    }
    [SerializeField] private List<GameObject> rangeUnits;
    public List<GameObject> RangeUnits
    {
        get => rangeUnits;
    }

    [SerializeField] private GameObject unitActive;
    public GameObject UnitActive
    {
        get => unitActive;
    }


    public bool CheckEmpty()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (Transform child in transform.GetChild(i))
            {
                if (child.gameObject.activeSelf)
                {
                    unitActive = child.gameObject;
                    return false;
                }
            }
        }

        unitActive = null;
        return true;
    }
}
