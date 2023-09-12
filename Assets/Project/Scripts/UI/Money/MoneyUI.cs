using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        MoneyManager.Instance.MoneyChanged += UpdateMoneyUI;
        UpdateMoneyUI(MoneyManager.Instance.Money);
    }

    private void UpdateMoneyUI(int newMoney)
    {
        moneyText.text = CurrencyConverter.GetInstance().ConvertMoney(newMoney);
    }
}