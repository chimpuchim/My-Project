using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page1 : MonoBehaviour
{
    public void OnBuyPack(int money)
    {
        MoneyManager.Instance.AddMoney(money);
    }
}
