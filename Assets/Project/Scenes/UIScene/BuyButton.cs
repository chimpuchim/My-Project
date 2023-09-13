using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI moneyText;
    
    void Update()
    {
        if(int.Parse(moneyText.text) > MoneyManager.Instance.Money)
        {
            buyButton.interactable = false;
            return;
        }
        
        buyButton.interactable = true;
    }
    
    public void OnBuyUnit(string name)
    {
        PlayerYardController.Instance.BuyUnit(name);
        MoneyManager.Instance.SpendMoney(int.Parse(moneyText.text));
        moneyText.text = (int.Parse(moneyText.text) + 100).ToString();
    }
}
