using UnityEngine;

public class CurrencyConverter : MonoBehaviour
{
    public static CurrencyConverter Instance;
    
    public static CurrencyConverter GetInstance()
    {
        if (Instance is null)
        {
            Instance = new CurrencyConverter();
        }
        return Instance;
    }
    
    
    public string ConvertMoney(int amount)
    {
        string convertedMoney = "";

        if (amount >= 1000000)
        {
            int millions = amount / 1000000;
            convertedMoney = millions + "m";
        }
        else if (amount >= 1000)
        {
            int thousands = amount / 1000;
            convertedMoney = thousands + "k";
        }
        else
        {
            convertedMoney = amount.ToString();
        }

        return convertedMoney;
    }
}