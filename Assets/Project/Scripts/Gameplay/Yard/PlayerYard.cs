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


    public bool CheckEmpty()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (Transform child in transform.GetChild(i))
            {
                if (child.gameObject.activeSelf)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
