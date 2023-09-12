using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        MoneyManager.instance.MoneyChanged += UpdateMoneyUI;
        UpdateMoneyUI(MoneyManager.instance.Money);
    }

    private void UpdateMoneyUI(int newMoney)
    {
        moneyText.text = CurrencyConverter.GetInstance().ConvertMoney(newMoney);
    }

    private void OnDestroy()
    {
        MoneyManager.instance.MoneyChanged -= UpdateMoneyUI;
    }
}